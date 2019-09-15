using System;
using System.Collections.Generic;

namespace ITSolution.Framework.Core.BaseClasses
{
    public static class Utils
    {
        /// <summary>
        /// Get List of string exception stack
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>List of exception messages</returns>
        public static List<string> DecompileExceptionStack(Exception exception)
        {
            List<string> exceptionStack = new List<string>();
            exceptionStack.Add("Exception Message:");
            exceptionStack.Add(exception.Message);

            exceptionStack.Add("Exception Stack:");
            exceptionStack.Add(exception.StackTrace);

            exceptionStack.Add("InnerException:");
            if (exception.InnerException != null)
            {
                exceptionStack.Add("InnerException Message:");
                exceptionStack.Add(exception.InnerException.Message);

                exceptionStack.Add("InnerException Stack:");
                exceptionStack.Add(exception.InnerException.StackTrace);
            }
            exceptionStack.Add("End Exception Stack");
            return exceptionStack;
        }
        /// <summary>
        /// Gets exception stack
        /// </summary>
        /// <param name="exception">String of exception Stack</param>
        /// <returns></returns>
        public static string GetExceptionStack(Exception exception)
        {
            string stack = string.Empty;

            foreach (var ex in DecompileExceptionStack(exception))
            {
                stack += ex;
            }
            Console.WriteLine(stack);
            return stack;
        }

        /// <summary>
        /// Write exception stack on Console
        /// </summary>
        /// <param name="exception"></param>
        public static void ShowExceptionStack(Exception exception)
        {
            Console.WriteLine(GetExceptionStack(exception));
        }
    }
}
