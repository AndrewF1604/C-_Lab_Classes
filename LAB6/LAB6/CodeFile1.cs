using System;
using System.Collections.Generic;
using System.Text;
namespace C6
{
    class StrategyFiftyFifty : IStrategy
    {
        public bool GetNextMove(List<bool> knownMoves)
        {
            int FalseNumber = 0;
            int TrueNumber = 0;
            foreach (bool moves in knownMoves)
            {
                if (moves) TrueNumber++;
                else FalseNumber++;
            }

            if (FalseNumber >= TrueNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
