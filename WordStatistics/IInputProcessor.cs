using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordStatistics
{
    interface IInputProcessor
    {
        void Process();
        IStatsFinder GetStatsFinder();
    }
}
