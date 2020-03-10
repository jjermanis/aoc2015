using System;
using System.Collections.Generic;

namespace AoC2015
{
    public class Day21 : DayMultiLineText, IDay
    {
        private readonly List<Item> _weapons = new List<Item>
        {
            new Item(8, 4, 0),  // Dagger
            new Item(10, 5, 0), // Shortsword
            new Item(25, 6, 0), // Warhammer
            new Item(40, 7, 0), // Longsword
            new Item(74, 8, 0), // Greataxe
        };

        // Unlike a weapon, armor is optional.  Include an option without
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
            Console.WriteLine($"Costliest victory: {CostliestLoss()}");
        }

        public int CheapestVictory()
        {
            return ScoreAllCombos(
                int.MaxValue,
                true,
                d => d.curr < d.best,
                d => Math.Min(d.best, d.curr));
        }

        public int CostliestLoss()
        {
            return ScoreAllCombos(
                0,
                false,
                d => d.curr > d.best,
                d => Math.Max(d.best, d.curr));
        }

        private int ScoreAllCombos(
            int startValue,
            bool isScoreWinners,
            Func<(int curr, int best), bool> IsCandidate,
            Func<(int curr, int best), int> UpdatedBestScore)
        {
            var bestScore = startValue;
            // Iterate through all combinations of weapon, armor and 2 rings
            foreach (var weapon in _weapons)
                foreach (var armor in _armor)
                    for (int ringIndex1 = 0; ringIndex1 < _rings.Count - 1; ringIndex1++)
                        for (var ringIndex2 = ringIndex1 + 1; ringIndex2 < _rings.Count; ringIndex2++)
                        {
                            var cost =
                                weapon.Cost + armor.Cost +
                                _rings[ringIndex1].Cost + _rings[ringIndex2].Cost;

                            // Only consider if this case would be a better score
                            if (IsCandidate((cost, bestScore)))
                            {
                                var d =
                                    weapon.Damage + armor.Damage +
                                    _rings[ringIndex1].Damage + _rings[ringIndex2].Damage;
                                var a =
                                    weapon.Armor + armor.Armor +
                                    _rings[ringIndex1].Armor + _rings[ringIndex2].Armor;
                                if (isScoreWinners == DoesPlayerWin(PLAYER_HP, d, a))
                                    bestScore = UpdatedBestScore((cost, bestScore));
                            }
                        }
            return bestScore;
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
        public override string ToString()
            => $"C: {Cost}, D: {Damage}, A: {Armor}";
    }
}
