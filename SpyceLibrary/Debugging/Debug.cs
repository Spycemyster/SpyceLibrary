using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpyceLibrary.Debugging.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SpyceLibrary.Debugging
{
    /// <summary>
    /// Debugging and performance analysis tools. Singleton to be universally access throughout
    /// the game project.
    /// </summary>
    public class Debug
    {
        #region Events
        /// <summary>
        /// Delegate handler for each event that is relevant to the debug object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="contents"></param>
        public delegate void DebugEvent(string sender, string contents);

        /// <summary>
        /// When a new message is added to the debug log.
        /// </summary>
        public DebugEvent OnNewDebugMessage;

        /// <summary>
        /// When a line is sent through the command prompt.
        /// </summary>
        public DebugEvent OnCommandSend;

        /// <summary>
        /// When the logs are cleared.
        /// </summary>
        public DebugEvent OnLogsCleared;

        /// <summary>
        /// When the logs are saved
        /// </summary>
        public DebugEvent OnLogsSaved;
        #endregion

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
        /// The measured time (milliseconds) between a draw and update function.
        /// </summary>
        public long TickSpeed
        {
            get { return drawTickSpeed + updateTickSpeed; }
        }

        /// <summary>
        /// The time it takes to run the update loop.
        /// </summary>
        public long UpdateTime
        {
            get { return updateTickSpeed; }
        }

        /// <summary>
        /// The time it takes to run the draw loop.
        /// </summary>
        public long DrawTime
        {
            get { return drawTickSpeed; }
        }
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
        private readonly Stopwatch tickMeasurer;
        private long drawTickSpeed, updateTickSpeed;
        private Engine engine;
        private SpriteFont font;
        #endregion

        #region Constructor
        private Debug()
        {
            logs = new List<LogEntry>();
            tickMeasurer = new Stopwatch();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the in-game debugger.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="initializer"></param>
        public void Initialize(Engine engine, Initializer initializer)
        {
            this.engine = engine;
            font = engine.Content.Load<SpriteFont>("System/DebugFont");

            // TEMP
            CommandHandler.Instance.Initialize(null);
        }

        internal void Exit()
        {
            engine.Exit();
        }

        /// <summary>
        /// Clears all the logs.
        /// </summary>
        /// <param name="sender"></param>
        public void ClearLogs(string sender)
        {
            logs.Clear();
            OnLogsCleared?.Invoke(sender, "");
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

            OnNewDebugMessage?.Invoke(sender, message);
        }

        /// <summary>
        /// Saves the log to the logs folder as a timestamped file.
        /// </summary>
        /// <param name="sender"></param>
        public void SaveLog(string sender)
        {
            if (!Directory.Exists(LOGS_FOLDER))
            {
                Directory.CreateDirectory(LOGS_FOLDER);
            }
            string path = $"{LOGS_FOLDER}/{GetFormattedTime(DateTime.Now)}.{LOGS_FILE_EXTENSION}";
            SaveLog(sender, path);
        }

        private string GetFormattedTime(DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH-mm-ss");
        }

        /// <summary>
        /// Saves the log to the specified path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="path"></param>
        public void SaveLog(string sender, string path)
        {
            string file = "";
            for (int i = 0; i < logs.Count; i++)
            {
                file += $"{GetFormattedTime(logs[i].Time)} [{logs[i].Sender}] - {logs[i].Message}\n";
            }
            File.WriteAllText(path, file);
            WriteLine(SENDER, $"Saved log to the path \"{path}\"", ConsoleColor.Green);
            OnLogsSaved?.Invoke(sender, path);
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

        #region Command Handling
        /// <summary>
        /// Parses the given line to the command prompt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="toParse"></param>
        public void ParseCommand(string sender, string toParse)
        {
            OnCommandSend?.Invoke(sender, toParse);
            CommandHandler.Instance.ParseCommand(sender, toParse);

            //// separate the command into its arguments
            //string[] args = toParse.Split(' ');

            //// empty command, don't do anything
            //if (args.Length == 0)
            //{
            //    return;
            //}
            //WriteLine(sender, $"Executing command '{toParse}'");
            //// command name
            //string command = args[0].ToLower();
            //// TEMPORARY
            //switch(command)
            //{
            //    case "listobjects":
            //        listObjects(sender);
            //        break;
            //    case "quit":
            //        engine.Exit();
            //        break;
            //    default:
            //        WriteLine(sender, $"Command '{command}' not found...");
            //        break;
            //}
        }

        /// <summary>
        /// Starts counting the current cycle of the game loop.
        /// </summary>
        public void StartUpdateTick()
        {
            tickMeasurer.Start();
        }

        /// <summary>
        /// Ends the counting of the current cycle of the update.
        /// </summary>
        public void EndUpdateTick()
        {
            tickMeasurer.Stop();
            updateTickSpeed = tickMeasurer.ElapsedMilliseconds;
            tickMeasurer.Reset();
        }

        /// <summary>
        /// Starts counting the current cycle of the game loop.
        /// </summary>
        public void StartDrawTick()
        {
            tickMeasurer.Start();
        }

        /// <summary>
        /// Ends the counting of the current cycle of the update.
        /// </summary>
        public void EndDrawTick()
        {
            tickMeasurer.Stop();
            drawTickSpeed = tickMeasurer.ElapsedMilliseconds;
            tickMeasurer.Reset();
        }

        /// <summary>
        /// Lists all the objects within the current scene.
        /// </summary>
        /// <param name="sender"></param>
        private void listObjects(string sender)
        {
            if (SceneManager.Instance.CurrentScene == null)
            {
                WriteLine(sender, "Cannot list the game objects of the current scene" +
                    " because there is no scene currently loaded...");
                return;
            }

            Dictionary<Guid, GameObject> objects = SceneManager.Instance.CurrentScene.GameObjects;
            foreach (GameObject b in objects.Values)
            {
                WriteLine(sender, $"{b}");
            }
        }

        /// <summary>
        /// Gets the number of objects in the current scene.
        /// </summary>
        /// <returns></returns>
        private int GetCurrentSceneObjectCount()
        {
            return SceneManager.Instance.CurrentScene.GameObjects.Count;
        }

        /// <summary>
        /// Draws debug items to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, $"# of GameObjects: {GetCurrentSceneObjectCount()}",
                new Vector2(8, 8), Color.White);
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
