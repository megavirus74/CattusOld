using System;

namespace Cattus.Utils {
    internal class Log {
        public static void Info(string text) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Print(text);
        }

        public static void Debug(string text) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Print(text);
        }

        private static void Print(string text) {
            string curTime = "";
            curTime = DateTime.Now.ToString("[HH:mm:ss]: ");

            Console.WriteLine(curTime + text);
        }
    }
}