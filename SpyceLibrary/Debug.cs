using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// Debugging and performance analysis tools. Singleton to be universally access throughout
    /// the game project.
    /// </summary>
    public class Debug
    {
        #region Singleton
        private static Debug inst;

        /// <summary>
        /// Accessor for the singleton.
        /// </summary>
        public static Debug Instance
        {
            get 
            { 
                if (inst == null)
                {
                    inst = new Debug();
                }
                return inst; 
            }
        }
        #endregion

        #region Fields
        /// <summary>
        /// The main folder where all the logs are saved to.
        /// </summary>
        public const string LOGS_FOLDER = "Logs";

        /// <summary>
        /// The file extension for the logs.
        /// </summary>
        public const string LOGS_FILE_EXTENSION = ".txt";
        private const string SENDER = "DEBUG";
        private readonly List<LogEntry> logs;
        #endregion

        #region Constructor
        private Debug()
        {
            logs = new List<LogEntry>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Clears all the logs.
        /// </summary>
        public void ClearLogs()
        {
            logs.Clear();

            WriteLine(SENDER, "Cleared the logs...", ConsoleColor.Green, ConsoleColor.Red);
        }

        /// <summary>
        /// Writes a new line to the debug log.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="senderColor"></param>
        /// <param name="messageColor"></param>
        public void WriteLine(string sender, string message, 
            ConsoleColor senderColor = ConsoleColor.White, 
            ConsoleColor messageColor = ConsoleColor.White)
        {
            Console.ResetColor();
            LogEntry entry = CreateEntry(sender, message);
            logs.Add(entry);
            Console.Write($"{ GetFormattedTime(entry.Time) } - ");
            Console.ForegroundColor = senderColor;
            Console.Write(sender);
            Console.ResetColor();
            Console.Write(" - ");
            Console.ForegroundColor = messageColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Saves the log to the logs folder as a timestamped file.
        /// </summary>
        public void SaveLog()
        {
            if (!Directory.Exists(LOGS_FOLDER))
            {
                Directory.CreateDirectory(LOGS_FOLDER);
            }
            string path = $"{LOGS_FOLDER}/{GetFormattedTime(DateTime.Now)}.{LOGS_FILE_EXTENSION}";
            SaveLog(path);
        }

        private string GetFormattedTime(DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH-mm-ss");
        }

        /// <summary>
        /// Saves the log to the specified path.
        /// </summary>
        /// <param name="path"></param>
        public void SaveLog(string path)
        {
            string file = "";
            for (int i = 0; i < logs.Count; i++)
            {
                file += $"{GetFormattedTime(logs[i].Time)} [{logs[i].Sender}] - {logs[i].Message}\n";
            }
            File.WriteAllText(path, file);
            WriteLine(SENDER, $"Saved log to the path \"{path}\"", ConsoleColor.Green);
        }

        private LogEntry CreateEntry(string sender, string message)
        {
            LogEntry l = new LogEntry
            {
                Sender = sender,
                Message = message,
                Time = DateTime.Now,
            };

            return l;
        }
        #endregion
    }

    internal struct LogEntry
    {
        /// <summary>
        /// The name of the sender.
        /// </summary>
        public string Sender;

        /// <summary>
        /// The content of the message.
        /// </summary>
        public string Message;

        /// <summary>
        /// The time the message was created.
        /// </summary>
        public DateTime Time;
    }
}
