using System;
using System.Collections.Generic;
using System.Text;
namespace C6
{
    class Game
    {
        private int rounds = 30; // how many rounds
        private int score1 = 10; // both players cooperate
        private int score2 = 15; // one player betrays - winner
        private int score3 = -10; // one player betrays - loser
        private int score4 = -3; // both players betray
                                // note: it can be shown mathematically that this game is non-trivial if: 
                                // 1) score2 > score1 > score4 > score3, AND
                                // 2) 2*score1 > score2 + score3
        private Player player1, player2;
        private void PlayOneGame()
        {
            for (int i = 0; i < rounds; i++)
            {
                bool move1 = player1.GetNextMove();
                bool move2 = player2.GetNextMove();

                if (move1 && move2) // both players cooperated
                {
                    // update score
                    player1.Score += score1;
                    player2.Score += score1;
                    // update players' knowledge about their partner
                    player1.PartnerMoves.Add(true);
                    player2.PartnerMoves.Add(true);
                }
                else if (move1) // player2 betrayed player1
                {
                    player1.Score += score3;
                    player2.Score += score2;
                    player1.PartnerMoves.Add(false);
                    player2.PartnerMoves.Add(true);
                }
                else if (move2) // player1 betrayed player2
                {
                    player1.Score += score2;
                    player2.Score += score3;
                    player1.PartnerMoves.Add(true);
                    player2.PartnerMoves.Add(false);
                }
                else // both players betrayed
                {
                    player1.Score += score4;
                    player2.Score += score4;
                    player1.PartnerMoves.Add(false);
                    player2.PartnerMoves.Add(false);
                }
            }
            Console.WriteLine(player1.currentStrategy + "\t" + player1.Score + " points");
            Console.WriteLine(player2.currentStrategy + "\t" + player2.Score + " points");
            Console.WriteLine();
        }
        public void RunTournament()
        {
            player1 = new Player();
            player2 = new Player();
            List<IStrategy> strategies = new List<IStrategy>() { new StrategyAlwaysTrue(), new StrategyAlwaysFalse(),new StrategyRandom(),new StrategyRapaport(),new StrategyAlternate(),new StrategyTrueFalseToggle(), new StrategyBetrayal(), new StrategyFiftyFifty()};
            var results = new Dictionary<IStrategy, int>();
            
      
            foreach (IStrategy strategy in strategies)
            {
                results.Add(strategy, 0);
            }

            for (int i = 0; i < strategies.Count; i++)
            {
                for (int j = i + 1; j < strategies.Count; j++)
                {
                    IStrategy strategy1 = strategies[i];
                    IStrategy strategy2 = strategies[j];

                    player1.currentStrategy = strategy1;
                    player2.currentStrategy = strategy2;
                    PlayOneGame();

                    results[strategy1] += player1.Score;
                    results[strategy2] += player2.Score;
                    player1.Score = 0;
                    player2.Score = 0;
                }
            }
            foreach (IStrategy strategy in strategies)
            {
                Console.WriteLine($"{strategy} scored {results[strategy]} total points");
            }
        }
    }
}
