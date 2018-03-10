using System;
using System.Collections.Generic;
using System.Text;

namespace WordStatistics
{
    class StatsHolder
    {
        public string Word { get; }
        public string DisplayWord { get; }
        private long Count;
        public long ScrabbleScore { get; set; }

        public StatsHolder(string word, string displayWord)
        {
            this.Word = word;
            this.DisplayWord = displayWord;
            Count = 1;
            ScrabbleScore = ScrabbleUtil.GetScore(word);
        }

        public void Increment()
        {
            Count++;
        }

        public long GetCount()
        {
            return Count;
        }
    }
}
