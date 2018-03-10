using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordStatistics
{
    class InputProcessorFactory
    {
        public static IInputProcessor GetWordInputProcessor(string filename) 
        {
            StreamReader reader = new StreamReader(filename);
            return new WordInputProcessor(reader);
        }
    }
}
