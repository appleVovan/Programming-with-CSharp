using System;
using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.Common
{
    public static class LoggingService
    {
        public static void WriteToConsole(List<ILoggable> itemsToLog)
        {
            foreach(var item in itemsToLog)
            {
                Console.WriteLine(item.Log());
            }
        }
    }
}
