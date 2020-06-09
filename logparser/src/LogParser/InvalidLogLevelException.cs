using System;

namespace LogParser
{
   public class InvalidLogLevelException : Exception
    {
        public InvalidLogLevelException()
        {

        }

        public InvalidLogLevelException(string level): base(String.Format($"Error: Invalid log level {level}"))
        {

        }
    }
}