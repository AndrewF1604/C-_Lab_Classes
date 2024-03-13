using System;
using System.Collections.Generic;
using System.Text;
namespace C6
{
    class StrategyBetrayal : IStrategy
    {
        public bool GetNextMove(List<bool> knownMoves)
        {
            if (knownMoves.Capacity == 0)
            {
                return true;
            }
            if (knownMoves[knownMoves.Count - 1] == true && knownMoves[knownMoves.Count - 2] == true)
            {
                return false;
            }
            if (knownMoves[knownMoves.Count - 1] == false && knownMoves[knownMoves.Count - 2] == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}