using System;
using System.Collections.Generic;
using System.Text;

namespace C6
{
    class StrategyTrueFalseToggle : IStrategy
    {
        private bool previousDecision = true;
        public bool GetNextMove(List<bool> knownMoves)
        {
            if (previousDecision == true)
            {
                previousDecision = false;
                return true;
            }
            else
            {
                previousDecision = true;
                return false;
            }

        }
    }
}