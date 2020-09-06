using System.Runtime.CompilerServices;
using Logger = System.Diagnostics.Debug;
using System;

namespace com.on.relax.your.eyes.logic
{
    public static class Log
    {
        private static void Report(string caller, int lineNum, string message, Exception e, [CallerMemberName] string category = "")
        {
            Logger.Write(caller + ":" + lineNum, category);
            Logger.Write(message, category);
            if(null != e)
            {
                Logger.Write(e.Source, category);
                Logger.Write(e.Message, category);
                Logger.WriteLine(e.StackTrace, category);
            }
        }

        public static void Warning(string message,
            Exception e = null,
            [CallerLineNumber] int callerLineNum = 0,
            [CallerMemberName] string callerName = null)
        {
            Report(callerName, callerLineNum, message, e);
        }
        public static void Error(string message,
            Exception e = null,
            [CallerLineNumber] int callerLineNum = 0,
            [CallerMemberName] string callerName = null)
        {
            Report(callerName, callerLineNum, message, e);
        }
        public static void Info(string message,
            [CallerLineNumber] int callerLineNum = 0,
            [CallerMemberName] string callerName = null)
        {
            Report(callerName, callerLineNum, message, null);
        }
    }
}
