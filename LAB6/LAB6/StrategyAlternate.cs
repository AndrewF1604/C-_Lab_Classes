using System;
using System.Collections.Generic;
using System.Text;
namespace C6
{
    class StrategyAlternate : IStrategy
    {
        // placeholder strategy - always cooperate (always return true)
        public bool GetNextMove(List<bool> knownMoves)
        {
            if (knownMoves.Capacity==0)
            {
                return true;
            }
            else if (knownMoves.Last() == false)
            return true;
            else
            return false;
        }
    }
}