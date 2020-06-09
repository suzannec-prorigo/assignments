namespace LogParser
{
    public class Usage
    {
        public static string usage()
        {
            return @"Usage: logParser --log-dir <dir> --log-level <level> --csv <out>
                        --log-dir      Directory to parse recursively for .log files
                        --csv          Out file-path (absolute/relative). If file does not 
                                       exist then a new file will be generated.
                        --log-level    Possible values: INFO, DEBUG, ERROR, TRACE, WARN.
                                       Log with only the specfied level will be stored in the CSV file.
                                       If this option is not provided then by default all logs
                                       will be stored in the CSV file
                                       This option can be provided multiple times to provide multiple log levels";
        }
    }
}