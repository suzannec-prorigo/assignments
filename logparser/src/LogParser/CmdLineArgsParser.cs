using System;
using System.IO;

namespace LogParser
{
    public class CmdLineArgsParser
    {
        public CmdLineArgs ParseArguments(string[] args)
        {
            CmdLineArgs cmdLineArgs = new CmdLineArgs();
            if( args.Length != 0)
            {
                if (IfElementExist(args, "--help"))
                {
                    cmdLineArgs.isHelp = true; 
                }
                else if (args.Length % 2 != 0){
                    throw new ArgumentException("Error: Missing argument or value");
                }
                else{
                    for (var i=0; i < args.Length; i+=2)
                    {
                        switch(args[i])
                        {
                            case "--log-level":
                            ValidateLogLevelValue(args[i+1]);
                            cmdLineArgs.logLevel.Add(args[i+1]);
                            break;

                            case "--log-dir":
                            ValidateLogDir(args[i+1]);
                            cmdLineArgs.logDir = args[i+1];
                            break;

                            case "--csv":
                            cmdLineArgs.csvFile = args[i+1];
                            break;

                            default:
                            throw new ArgumentException($"Error: {args[i]} is not a valid argument!");
                        }
                    }
                }
            }
            else{
                throw new ArgumentException("Error: No arguments provided!");
            }
            return cmdLineArgs;
        }

        public void ValidateLogLevelValue(string logLevelValue)
            {
                var validLogLevels = new string[] {"info", "debug", "warn", "error"};
                if (! IfElementExist(validLogLevels, logLevelValue.ToLower()))
                {
                    throw new InvalidLogLevelException(logLevelValue);
                }
            }

        public void ValidateLogDir(string path)
            {
                if (! Directory.Exists(path))
                {
                    throw new DirectoryNotFoundException();
                }
            }
        
        public bool IfElementExist(string[] arr, string value)
            {
                if (Array.Exists(arr, element => element == value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    }
}