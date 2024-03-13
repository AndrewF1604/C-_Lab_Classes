using System;
using System.Collections.Generic;
using System.Text;

namespace C6
{
    interface IStrategy
    {
        bool GetNextMove(List<bool> knownMoves); // use this method to return your next move in game
    }
}
