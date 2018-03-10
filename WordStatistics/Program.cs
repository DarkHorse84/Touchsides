using System;
using System.Collections.Generic;

namespace WordStatistics
{
    class Program
    {
        private static string DEFAULT_FILE = "C:\\WarAndPeace\\2600.txt";
        private const int WORD_LENGTH = 7;

        static void Main(string[] args)
        {
            
            IInputProcessor processor = null;
            Console.WriteLine("Please enter the path to the book file (empty default is " + DEFAULT_FILE + "):");
            string filePath = Console.ReadLine();
            if (filePath.Length == 0)
            {
                filePath = DEFAULT_FILE;
            }
            try
            {
                Console.WriteLine("Reading: " + filePath);
                processor = InputProcessorFactory.GetWordInputProcessor(filePath);
            }
            catch (Exception)//Catch all here, the only thing I can see going wrong is that the user puts in the wrong file
            {
                Console.WriteLine("Invalid file path");
                return;
            }
            long startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            processor.Process();
            Console.WriteLine("TimeTaken (Reading the file) (s): " + ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime) / 1000);
            IStatsFinder statsFinder = processor.GetStatsFinder();
            if (statsFinder.getTotal() == 0)
            {
                Console.WriteLine("Ï have no words!");
                Console.Read();
                return;
            }
            startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            getStats(statsFinder);
            Console.WriteLine("TimeTaken (no post processing) (ms): " + ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime));
            startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            getStats(statsFinder);
            Console.WriteLine("TimeTaken (post processing) (ms): " + ((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime));
            Console.Read();
        }

        private static void getStats(IStatsFinder statsFinder)
        {
            List<StatsHolder> statsHolders = statsFinder.GetMostUsed();
            Console.Write("Most frequent word:");
            if (statsHolders.Count > 1)
            {
                Console.WriteLine("There is a tie for the most used words!");
                Console.Write("The words ");
                for (int i = 0; i < statsHolders.Count; i++)
                {
                    if (i == statsHolders.Count - 1)
                    {
                        Console.Write("and " + statsHolders[i].DisplayWord);
                    }
                    else
                    {
                        Console.Write(statsHolders[i].DisplayWord + ", ");
                    }
                }
                Console.WriteLine(" occured " + statsHolders[0].GetCount() + " times");
            }
            else
            {
                Console.WriteLine(statsHolders[0].DisplayWord + " occured " + statsHolders[0].GetCount() + " times"); //If the list is actually empty I've made a massive mistake and the program should abbend
            }


            statsHolders = statsFinder.GetMostUsedByLength(WORD_LENGTH);
            Console.Write("Most frequent " + WORD_LENGTH + "-character word:");
            if (statsHolders.Count > 1)
            {
                Console.WriteLine("There is a tie for the most used " + WORD_LENGTH + "-character word!");
                Console.Write("The words ");
                for (int i = 0; i < statsHolders.Count; i++)
                {
                    if (i == statsHolders.Count - 1)
                    {
                        Console.Write("and " + statsHolders[i].DisplayWord);
                    }
                    else
                    {
                        Console.Write(statsHolders[i].DisplayWord + ", ");
                    }
                }
                Console.WriteLine(" occured " + statsHolders[0].GetCount() + " times");
            }
            else
            {
                Console.WriteLine(statsHolders[0].DisplayWord + " occured " + statsHolders[0].GetCount() + " times"); //If the list is actually empty I've made a massive mistake and the program should abbend
            }

            statsHolders = statsFinder.GetHighestScrabbleCount();
            Console.Write("Highest scoring word(s) (according to Scrabble):");
            if (statsHolders.Count > 1)
            {
                Console.WriteLine("There is a tie for the highest scoring word!");
                Console.Write("The words ");
                for (int i = 0; i < statsHolders.Count; i++)
                {
                    if (i == statsHolders.Count - 1)
                    {
                        Console.Write("and " + statsHolders[i]);
                    }
                    else
                    {
                        Console.Write(statsHolders[i] + ", ");
                    }
                }
                Console.WriteLine(" have a score of " + statsHolders[0].ScrabbleScore);
            }
            else
            {
                Console.WriteLine(statsHolders[0].DisplayWord + " with a score os " + statsHolders[0].ScrabbleScore); //If the list is actually empty I've made a massive mistake and the program should abbend
            }
        }

        private static void getStatsPost(IStatsFinder statsFinder)
        {
            statsFinder.PostProcess();
            List<StatsHolder> statsHolders = statsFinder.GetMostUsedPost();
            Console.Write("Most frequent word:");
            if (statsHolders.Count > 1)
            {
                Console.WriteLine("There is a tie for the most used words!");
                Console.Write("The words ");
                for (int i = 0; i < statsHolders.Count; i++)
                {
                    if (i == statsHolders.Count - 1)
                    {
                        Console.Write("and " + statsHolders[i].DisplayWord);
                    }
                    else
                    {
                        Console.Write(statsHolders[i].DisplayWord + ", ");
                    }
                }
                Console.WriteLine(" occured " + statsHolders[0].GetCount() + " times");
            }
            else
            {
                Console.WriteLine(statsHolders[0].DisplayWord + " occured " + statsHolders[0].GetCount() + " times"); //If the list is actually empty I've made a massive mistake and the program should abbend
            }


            statsHolders = statsFinder.GetMostUsedByLength(WORD_LENGTH);
            Console.Write("Most frequent " + WORD_LENGTH + "-character word:");
            if (statsHolders.Count > 1)
            {
                Console.WriteLine("There is a tie for the most used " + WORD_LENGTH + "-character word!");
                Console.Write("The words ");
                for (int i = 0; i < statsHolders.Count; i++)
                {
                    if (i == statsHolders.Count - 1)
                    {
                        Console.Write("and " + statsHolders[i].DisplayWord);
                    }
                    else
                    {
                        Console.Write(statsHolders[i].DisplayWord + ", ");
                    }
                }
                Console.WriteLine(" occured " + statsHolders[0].GetCount() + " times");
            }
            else
            {
                Console.WriteLine(statsHolders[0].DisplayWord + " occured " + statsHolders[0].GetCount() + " times"); //If the list is actually empty I've made a massive mistake and the program should abbend
            }

            statsHolders = statsFinder.GetHighestScrabbleCountPost();
            Console.Write("Highest scoring word(s) (according to Scrabble):");
            if (statsHolders.Count > 1)
            {
                Console.WriteLine("There is a tie for the highest scoring word!");
                Console.Write("The words ");
                for (int i = 0; i < statsHolders.Count; i++)
                {
                    if (i == statsHolders.Count - 1)
                    {
                        Console.Write("and " + statsHolders[i]);
                    }
                    else
                    {
                        Console.Write(statsHolders[i] + ", ");
                    }
                }
                Console.WriteLine(" have a score of " + statsHolders[0].ScrabbleScore);
            }
            else
            {
                Console.WriteLine(statsHolders[0].DisplayWord + " with a score os " + statsHolders[0].ScrabbleScore); //If the list is actually empty I've made a massive mistake and the program should abbend
            }
        }
    }
}
