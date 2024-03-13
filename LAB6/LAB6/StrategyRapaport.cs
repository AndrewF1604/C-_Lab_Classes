using System;
using System.Collections.Generic;
using System.Text;
namespace C6
{
    // jakis random z google 
    /*
     * Zwycięzcą okazała się strategia A. Rapaporta „wet-za-wet”
(tit-for-tat). Stosujący ją gracz rozpoczyna od kooperacji (strategia jest przyjazna), gdy
spotka się z jej brakiem, również zaczyna być nielojalny (strategia jest też odwetowa), gdy
zaś przeciwnik decyduje się jednak współpracować – w kolejnej grze wet-za-wet powraca
do współpracy (strategia jest przebaczająca).
      */
    class StrategyRapaport : IStrategy
    {
        public bool GetNextMove(List<bool> knownMoves)
        {
            if (knownMoves.Capacity == 0)
            {
                return true;
            }
            else if (knownMoves.Last() == false)
                return false;
            else return false;
        }
            
    }
}