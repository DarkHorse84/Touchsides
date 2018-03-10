using System;
using System.Collections.Generic;
using System.Text;

namespace WordStatistics
{
    interface IStatsFinder
    {
        void Add(string toCount);
        List<StatsHolder> GetMostUsed();
        List<StatsHolder> GetMostUsedByLength(int length);
        List<StatsHolder> GetHighestScrabbleCount();
        void PostProcess();
        List<StatsHolder> GetMostUsedPost();
        List<StatsHolder> GetHighestScrabbleCountPost();
        long getTotal();
    }
}
