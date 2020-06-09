using System;
using System.Collections.Generic;

namespace LogParser
{
    public class CmdLineArgs
    {
        public string logDir { get; set; }
        public string csvFile { get; set; }
        public List<string> logLevel { get; set; }
        public bool isHelp;

        public CmdLineArgs()
        {
            isHelp = false;
            //logLevel = new List<string> {"INFO", "DEBUG", "WARN", "ERROR", "TRACE"};
        }
        
    }
}