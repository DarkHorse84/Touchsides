using System;
using System.Collections.Generic;
using System.Text;

namespace WordStatistics
{
    class ScrabbleUtil
    {
        private static Dictionary<char, int> scrabbleMap = new Dictionary<char, int>();
        static ScrabbleUtil()
        {
            scrabbleMap.Add('a', 1);
            scrabbleMap.Add('b', 3);
            scrabbleMap.Add('c',3);
            scrabbleMap.Add('d',2);
            scrabbleMap.Add('e',1);
            scrabbleMap.Add('f',4);
            scrabbleMap.Add('g',2);
            scrabbleMap.Add('h',4);
            scrabbleMap.Add('i',1);
            scrabbleMap.Add('j',8);
            scrabbleMap.Add('k',5);
            scrabbleMap.Add('l',1);
            scrabbleMap.Add('m',3);
            scrabbleMap.Add('n',1);
            scrabbleMap.Add('o',1);
            scrabbleMap.Add('p',3);
            scrabbleMap.Add('q',10);
            scrabbleMap.Add('r',1);
            scrabbleMap.Add('s',1);
            scrabbleMap.Add('t',1);
            scrabbleMap.Add('u',1);
            scrabbleMap.Add('v',4);
            scrabbleMap.Add('w',4);
            scrabbleMap.Add('x',8);
            scrabbleMap.Add('y',4);
            scrabbleMap.Add('z',10);
        }

        public static long GetScore(string word)
        {
            long score = 0;
            foreach(char c in word.ToLower())
            {
                score += scrabbleMap[c];
            }
            return score;
        }
    }
}
