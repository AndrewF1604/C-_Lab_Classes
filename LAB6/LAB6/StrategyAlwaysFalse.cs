using System;
using System.Collections.Generic;
using System.Text;

namespace C6
{
    class StrategyAlwaysFalse : IStrategy
    {
        // placeholder strategy - always cooperate (always return true)
        public bool GetNextMove(List<bool> knownMoves)
        {
            return false;
        }
    }
}
