using System;
using System.Collections.Generic;

namespace AoC2015
{
    public class Day21 : DayMultiLineText, IDay
    {
        private readonly List<Item> _weapons = new List<Item>
        {
            new Item(0, 0, 0),  // Nothing
            new Item(8, 4, 0),  // Dagger
            new Item(10, 5, 0), // Shortsword
            new Item(25, 6, 0), // Warhammer
            new Item(40, 7, 0), // Longsword
            new Item(74, 8, 0), // Greataxe
        };

        private readonly List<Item> _armor = new List<Item>
        {
            new Item(0, 0, 0),  // Nothing
            new Item(13, 0, 1), // Leather
            new Item(31, 0, 2), // Chainmail
            new Item(53, 0, 3), // Splitmail
            new Item(75, 0, 4), // Bandedmail
            new Item(102, 0, 5),// Platemail
        };

        // Put two options for no ring. This gets the logic to consider the
        // empty hand cases with no extra logic
        private readonly List<Item> _rings = new List<Item>
        {
            new Item(0, 0, 0),  // Nothing
            new Item(0, 0, 0),  // Nothing
            new Item(25, 1, 0), // Damage +1
            new Item(50, 2, 0), // Damage +1
            new Item(100, 3, 0),// Damage +1
            new Item(20, 0, 1), // Defense +1
            new Item(40, 0, 2), // Defense +1
            new Item(80, 0, 3), // Defense +1
        };

        private const int PLAYER_HP = 100;

        private int _enemyHp;
        private int _enemyDamage;
        private int _enemyArmor;

        public Day21(string filename) : base(filename)
        {
            InitEnemy();
        }

        public Day21() : this("Day21.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Cheapest victory: {CheapestVictory()}");
        }

        public int CheapestVictory()
        {
            var cheapestVictory = int.MaxValue;
            foreach(var weapon in _weapons)
                foreach(var armor in _armor)
                    for (int ringIndex1=0; ringIndex1 < _rings.Count-1; ringIndex1++)
                        for (var ringIndex2=ringIndex1+1; ringIndex2 < _rings.Count; ringIndex2++)
                        {
                            var cost = 
                                weapon.Cost + armor.Cost + 
                                _rings[ringIndex1].Cost + _rings[ringIndex2].Cost;
                            if (cost < cheapestVictory)
                            {
                                var d = 
                                    weapon.Damage + armor.Damage +
                                    _rings[ringIndex1].Damage + _rings[ringIndex2].Damage;
                                var a = 
                                    weapon.Armor + armor.Armor + 
                                    _rings[ringIndex1].Armor + _rings[ringIndex2].Armor;
                                if (DoesPlayerWin(PLAYER_HP, d, a))
                                    cheapestVictory = Math.Min(cheapestVictory, cost);
                            }
                        }
            return cheapestVictory;
        }

        private bool DoesPlayerWin(
            int hp, 
            int damage, 
            int armor)
        {
            var currHp = hp;
            var currEnemyHp = _enemyHp;

            while (true)
            {
                currEnemyHp -= Math.Max(damage - _enemyArmor, 1);
                if (currEnemyHp <= 0)
                    return true;
                currHp -= Math.Max(_enemyDamage - armor, 1);
                if (currHp <= 0)
                    return false;
            }
        }

        private void InitEnemy()
        {
            foreach(var line in Data)
            {
                var tokens = line.Split(':');
                var val = int.Parse(tokens[1]);
                switch (tokens[0][0])
                {
                    case 'H':
                        _enemyHp = val;
                        break;
                    case 'D':
                        _enemyDamage = val;
                        break;
                    case 'A':
                        _enemyArmor = val;
                        break;
                    default:
                        throw new Exception($"Unexpected enemy attribute: {tokens[0]}");
                }
            }
        }
    }

    class Item
    {
        public Item(int cost, int damage, int armor)
        {
            Cost = cost;
            Damage = damage;
            Armor = armor;
        }
        public int Cost { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }
}
