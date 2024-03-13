using System;
using System.Collections.Generic;
using System.Text;

namespace C6
{
    class Player
    {
        public IStrategy currentStrategy; // the algorithm used to make moves
        public List<bool> PartnerMoves { get; set; } // true means cooperation, false means betrayal
        public int Score { get; set; } // game score
        public Player()
        {
            PartnerMoves = new List<bool>();
        }
        public Player(IStrategy initialStrategy)
        {
            PartnerMoves = new List<bool>();
            currentStrategy = initialStrategy;
        }
        public void SetStrategy(IStrategy newStrategy)
        {
            currentStrategy = newStrategy;
        }

        public bool GetNextMove()
        {
            return currentStrategy.GetNextMove(PartnerMoves);
        }

    }
}
