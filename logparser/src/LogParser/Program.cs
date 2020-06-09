using System;
using System.Collections.Generic;
using System.IO;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            CmdLineArgsParser cmdArgParser = new CmdLineArgsParser();
            CmdLineArgs cmdLineArgs = new CmdLineArgs();
            try
            {
                cmdLineArgs = cmdArgParser.ParseArguments(args);
                if (cmdLineArgs.isHelp){
                    Console.WriteLine(Usage.usage());
                }
                else {
                    LogsToCSVConvertor logsToCSVConvertor = new LogsToCSVConvertor();
                    try {
                    logsToCSVConvertor.ConvertLogsToCsv(cmdLineArgs);
                    }
                    catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(Usage.usage());
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidLogLevelException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(Usage.usage());
            }
        }
    }
}
