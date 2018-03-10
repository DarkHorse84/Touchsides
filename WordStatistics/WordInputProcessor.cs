using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WordStatistics
{
    class WordInputProcessor : IInputProcessor
    {
        private IStatsFinder StatsFinder { get; set; } = new WordStatsFinder();

        private TextReader Reader;
        private long Total = 0;

        public WordInputProcessor(TextReader reader)
        {
            Reader = reader;
        }

        void IInputProcessor.Process()
        {
            string line = "";
            try
            {
                while ((line = Reader.ReadLine()) != null)
                {
                    line = line.ToLower();
                    string[] lines = line.Split(' ');
                    foreach (string word in lines)
                    {
                        Total++;
                        StatsFinder.Add(word);
                    }
                }
            }
            finally
            {
                Reader.Close();
            }
        }

        IStatsFinder IInputProcessor.GetStatsFinder()
        {
            return StatsFinder;
        }

        
    }
}
