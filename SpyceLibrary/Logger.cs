using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// Manages log entries for the console output. Provides a way to save log entries into a
    /// log file.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The text behind a warning message. This flags it as an "error" that isn't gamebreaking, 
        /// but should be an area of concern for the developer.
        /// </summary>
        public const string WARNING_HEADER = "WARNING: ";

        /// <summary>
        /// The text behind an error message. This flags it as an "error" that is gamebreaking and should 
        /// be immediately fixed.
        /// </summary>
        public const string ERROR_HEADER = "ERROR: ";

        private static string logData;
        private static int lineNumber = 0;

        /// <summary>
        /// Formats the given timestamp.
        /// </summary>
        /// <returns></returns>
        public static string GetTimestamp(DateTime val)
        {
            return val.ToString("MM-dd-yyyy HH-mm-ss-ffff tt");
        }

        /// <summary>
        /// Appends a new blobl of text to the log data.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textColor"></param>
        public static void Write(string text, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            logData += text;
            Console.ResetColor();
        }

        /// <summary>
        /// Writes a line to the log data and creates a new line.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="textColor"></param>
        public static void WriteLine(string line, ConsoleColor textColor = ConsoleColor.White)
        {
            string timestamp = GetTimestamp(DateTime.Now);
            Write($"[{timestamp}] ");
            Write(line + '\n', textColor);
        }

        /// <summary>
        /// Clears the logs (why would you ever do this, but it's here I guess).
        /// </summary>
        public static void Clear()
        {
            logData = "";
            WriteLine("Logs cleared...", ConsoleColor.Red);
        }

        /// <summary>
        /// Saves the log file named the current time.
        /// </summary>
        /// <returns></returns>
        public static string Save()
        {
            string path = $"Logs/{GetTimestamp(DateTime.Now)}.txt";
            Save(path);
            return path;
        }

        /// <summary>
        /// Saves the log file.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Save(string name)
        {
            if (!Directory.Exists("Logs"))
            {
                Directory.CreateDirectory("Logs");
            }

            WriteLine("Saving log to the path " + name, ConsoleColor.Green);
            
            if (File.Exists(name))
            {
                WriteLine($"{WARNING_HEADER} File {name} already exists. Overriding...", ConsoleColor.Yellow);
            }

            File.WriteAllText(name, logData);
            return name;
        }
    }
}
