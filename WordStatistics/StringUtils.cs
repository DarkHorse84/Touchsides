using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WordStatistics
{
    class StringUtils
    {
        public static string CleanUp(string word)
        {
            //Removes all non-alpha characters otherwise scrabble will fail
            Regex notAlpha = new Regex("[^a-zA-Z]"); //http://regexstorm.net/tester
            string line = notAlpha.Replace(word, "");
            return line;
        }

        public static string CleanUpLeadingAndTrailingOnly(string word)
        {
            /*removes non-alpha only at the begining and of the word, so that what gets displayed later can be searched to verify
             * like 'Hofs-kriegs-wurst-schnapps-Rath' for example
            */
            Regex notAlpha = new Regex("^[^a-zA-Z]*|[^a-zA-Z]*$"); //http://regexstorm.net/tester
            string line = notAlpha.Replace(word, "");
            return line;
        }
    }
}
