using System;
using System.Collections.Generic;
using System.Text;

namespace C6
{
    class StrategyAlwaysTrue : IStrategy
    {
        // placeholder strategy - always cooperate (always return true)
        public bool GetNextMove(List<bool> knownMoves)
        {
            return true;
        }
    }
    
}
