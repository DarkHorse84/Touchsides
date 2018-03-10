using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordStatistics
{
    class WordStatsFinder : IStatsFinder
    {
        Dictionary<String, StatsHolder> wordDictionary = new Dictionary<string, StatsHolder>();
        private List<StatsHolder> MostUsedList;
        private List<StatsHolder> HighestScrabbleList;

        void IStatsFinder.Add(string toCount)
        {
            string tmpToCount = StringUtils.CleanUp(toCount);
            if (wordDictionary.ContainsKey(tmpToCount))
            {
                wordDictionary[tmpToCount].Increment();
            } else
            {
                StatsHolder statsHolder = new StatsHolder(tmpToCount, StringUtils.CleanUpLeadingAndTrailingOnly(toCount));
                wordDictionary[tmpToCount] = statsHolder;
            }
        }

        List<StatsHolder> IStatsFinder.GetMostUsed()
        {
            List<StatsHolder> valuesList = (from statsHolder in wordDictionary.Values select statsHolder).ToList(); //Using this as I can't get SelectMany to work and I have no idea why
            List<StatsHolder> returnList = GetMaxCount(valuesList);
            return returnList; // this should be O(3n) unless I've misunderstood linq
        }

        List<StatsHolder> IStatsFinder.GetMostUsedByLength(int length)
        {
            List<StatsHolder> valuesList = (from statsHolder in wordDictionary.Values select statsHolder)
                .Where(x =>x.Word.Length == length).ToList(); //Using this as I can't get SelectMany to work and I have no idea why
            List<StatsHolder> returnList = GetMaxCount(valuesList);
            return returnList;
        }



        List<StatsHolder> IStatsFinder.GetHighestScrabbleCount()
        {
            List<StatsHolder> valuesList = (from statsHolder in wordDictionary.Values select statsHolder).ToList();
            long maximumScore = valuesList.Max(x => x.ScrabbleScore);
            List<StatsHolder> returnList = valuesList.Where(s => s.ScrabbleScore == maximumScore).ToList();
            return returnList;
        }

        long IStatsFinder.getTotal()
        {
            return wordDictionary.Keys.Count;
        }

        private static List<StatsHolder> GetMaxCount(List<StatsHolder> valuesList)
        {
            long maximumCount = valuesList.Max(x => x.GetCount());
            List<StatsHolder> returnList = valuesList.Where(x => x.GetCount() == maximumCount).ToList();
            return returnList;
        }

        void IStatsFinder.PostProcess()
        {
            List<StatsHolder> valuesList = (from statsHolder in wordDictionary.Values select statsHolder).ToList();
            MostUsedList = new List<StatsHolder>();
            long highestCount = 0;
            HighestScrabbleList = new List<StatsHolder>();
            long highestScrabble = 0;
            foreach(StatsHolder stats in valuesList)
            {
                if(stats.GetCount() > highestCount)
                {
                    highestCount = stats.GetCount();
                    MostUsedList.Clear();
                    MostUsedList.Add(stats);
                } else if(stats.GetCount() == highestCount)
                {
                    HighestScrabbleList.Add(stats);
                }
                if (stats.ScrabbleScore > highestScrabble)
                {
                    highestScrabble = stats.ScrabbleScore;
                    HighestScrabbleList.Clear();
                    HighestScrabbleList.Add(stats);
                }
                else if (stats.ScrabbleScore == highestScrabble)
                {
                    HighestScrabbleList.Add(stats);
                }
            }
        }

        List<StatsHolder> IStatsFinder.GetMostUsedPost()
        {
            return MostUsedList;
        }

        List<StatsHolder> IStatsFinder.GetHighestScrabbleCountPost()
        {
            return HighestScrabbleList;
        }
    }
}
