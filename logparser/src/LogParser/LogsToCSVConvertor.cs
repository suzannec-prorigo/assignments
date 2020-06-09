using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace LogParser
{
    public class LogsToCSVConvertor
    {
        List<string> logFiles = new List<string>();
        string infoRegex = @"([0-9]{2}\/[0-9]{2})\s([0-9]{2}:[0-9]{2}:[0-9]{2})\s(INFO)\s(.*)";
        // string debugRegex = @"([0-9]{2}\/[0-9]{2})\s([0-9]{2}:[0-9]{2}:[0-9]{2})\s(DEBUG).*";
        // string errorRegex = @"([0-9]{2}\/[0-9]{2})\s([0-9]{2}:[0-9]{2}:[0-9]{2})\s(ERROR).*";
        // string warnRegex = @"([0-9]{2}\/[0-9]{2})\s([0-9]{2}:[0-9]{2}:[0-9]{2})\s(WARN).*";

        public void ConvertLogsToCsv(CmdLineArgs args)
        {
            ParseFiles(args.logDir);

            if ( logFiles.Count != 0 ){
                int counter = 0;  
                foreach ( string file in logFiles)
                {
                    using(StreamReader inFile = new StreamReader(file)) {  
                    string ln;  
                    
                    while ((ln = inFile.ReadLine()) != null) {  
                        Regex r = new Regex(infoRegex);
                        Match m = r.Match(ln);
                        if (m.Success)
                        {
                            Group date = m.Groups[1];
                            Group time = m.Groups[2];
                            Group level = m.Groups[3];
                            Group text = m.Groups[4];
                            counter++;

                            using(StreamWriter outFile = File.AppendText(args.csvFile))
                            {
                                outFile.WriteLine($"\"{counter}\",\"{date}\",\"{time}\",\"{level}\",\"{text}\"");
                            }
                        }
                    }  
                    }
                }
            }
            else {
                throw new Exception($"No log files found under directory {args.logDir}");
            }
        }

        public void ParseFiles(string dir)
        {
            
            if (Directory.GetFiles(dir).Length !=0)
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    logFiles.Add(f);
                }
            }
            if (Directory.GetDirectories(dir).Length != 0)
            {
                foreach (string d in Directory.GetDirectories(dir))
                {
                    ParseFiles(d);
                }
            }
        }
    }
}