using System;
using System.Collections.Generic;
using System.Text;
namespace C6
{
    class StrategyRandom : IStrategy
    {
        Random generator = new Random();

        public bool GetNextMove(List<bool> knownMoves)
        {
            int b = generator.Next();
            if(b%2==0)
            return true;
            else
            return false;
        }
    }
}
