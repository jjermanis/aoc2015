using System;
using System.Collections.Generic;

namespace AoC2015
{
    public class Day22 : DayMultiLineText, IDay
    {
        private const int PLAYER_HEALTH_START = 50;
        private const int PLAYER_MANA_START = 500;

        private int _startEnemyHealth;
        private int _startEnemyDamage;

        private int _cheapestVictory;

        public Day22(string filename) : base(filename)
        {
            InitEnemy();
        }

        public Day22() : this("Day22.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Cheapest victory: {CheapestVictory()}");
        }

        public int CheapestVictory()
        {
            var games = new List<GameState>();
            games.Add(new GameState
            {
                PlayerHealth = PLAYER_HEALTH_START,
                PlayerMana = PLAYER_MANA_START,
                EnemyHealth = _startEnemyHealth,
                EnemyDamage = _startEnemyDamage
            });

            return FindCheapestVictory(games);
        }

        private int FindCheapestVictory(List<GameState> games)
        {
            _cheapestVictory = int.MaxValue;

            while (games.Count > 0)
            {
                var curr = games[0];
                games.RemoveAt(0);

                // Try moves
                TrySpell(games, curr, CastMagicMissle);
                TrySpell(games, curr, CastDrain);
                TrySpell(games, curr, CastShield);
                TrySpell(games, curr, CastPoison);
                TrySpell(games, curr, CastRecharge);
            }

            return _cheapestVictory;
        }

        private void TrySpell(
            List<GameState> games,
            GameState game,
            Func<GameState, GameState> DoSpell)
        {
            game = HandleTimers(game, isPlayerTurn: true);
            try
            {
                game = DoSpell(game);
                if (game.PlayerMana < 0)
                    return;
            }
            catch
            {
                return;
            }
            if (game.EnemyHealth <= 0)
            {
                _cheapestVictory = Math.Min(_cheapestVictory, game.CummulativeManaSpent);
                return;
            }

            game = HandleTimers(game, isPlayerTurn: false);

            if (game.PlayerMana < 0 || game.PlayerHealth <= 0)
            {
                return;
            }

            if (game.CummulativeManaSpent < _cheapestVictory)
                games.Add(game);
        }

        private GameState HandleTimers(GameState game, bool isPlayerTurn)
        { 
            // Handle armor. Time runs every turn, but damage only accrues on 
            // enemy turn
            if (!isPlayerTurn)
               game.PlayerHealth -= game.EnemyDamage;
            if (game.ArmorTimer > 0)
            {
                game.ArmorTimer--;
                if (!isPlayerTurn)
                    game.PlayerHealth += 7;
            }

            if (game.PoisonTimer > 0)
            {
                game.EnemyHealth -= 3;
                game.PoisonTimer--;
            }

            if (game.RechargeTimer > 0)
            {
                game.PlayerMana += 101;
                game.RechargeTimer--;
            }

            return game;
        }

        private GameState CastMagicMissle(GameState game)
        {
            game.SpendMana(53);
            game.EnemyHealth -= 4;
            return game;
        }

        private GameState CastDrain(GameState game)
        {
            game.SpendMana(73);
            game.EnemyHealth -= 2;
            game.PlayerHealth += 2;
            return game;
        }

        private GameState CastShield(GameState game)
        {
            if (game.ArmorTimer > 0)
                throw new Exception();

            game.SpendMana(113);
            game.ArmorTimer = 6;
            return game;
        }

        private GameState CastPoison(GameState game)
        {
            if (game.PoisonTimer > 0)
                throw new Exception();

            game.SpendMana(173);
            game.PoisonTimer = 6;
            return game;
        }

        private GameState CastRecharge(GameState game)
        {
            if (game.RechargeTimer > 0)
                throw new Exception();

            game.SpendMana(229);
            game.RechargeTimer = 5;
            return game;
        }

        private void InitEnemy()
        {
            foreach (var line in Data)
            {
                var tokens = line.Split(':');
                var val = int.Parse(tokens[1]);
                switch (tokens[0][0])
                {
                    case 'H':
                        _startEnemyHealth = val;
                        break;
                    case 'D':
                        _startEnemyDamage = val;
                        break;
                    default:
                        throw new Exception($"Unexpected enemy attribute: {tokens[0]}");
                }
            }
        }
    }

    struct GameState
    {
        public int EnemyHealth { get; set; }
        public int EnemyDamage { get; set; }
        public int PlayerHealth { get; set; }
        public int PlayerMana { get; set; }
        public int CummulativeManaSpent { get; set; }
        public int ArmorTimer { get; set; }
        public int PoisonTimer { get; set; }
        public int RechargeTimer { get; set; }

        public void SpendMana(int cost)
        {
            PlayerMana -= cost;
            CummulativeManaSpent += cost;
        }
    }
}
