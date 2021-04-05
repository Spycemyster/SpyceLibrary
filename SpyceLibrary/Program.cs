using System;
using System.Threading;

namespace SpyceLibrary
{
    public class Program
    {
        public static void Main()
        {
            Program p = new Program();
            p.Run();
        }

        private Thread gameThread, consoleThread;
        private bool isRunning;

        public const string NAME = "CONSOLE";
        public void Run()
        {
            Engine engine = new Engine();
            engine.Exiting += onExiting;
            isRunning = true;
            gameThread = new Thread(() => runGame(engine));
            gameThread.Start();
            consoleThread = new Thread(runConsole);
            consoleThread.Start();
        }

        private void runConsole()
        {
            while (isRunning)
            {
                string line = Console.ReadLine();
                Debug.Instance.ParseCommand(NAME, line);
            }
        }

        private void onExiting(object sender, EventArgs args)
        {
            isRunning = false;
        }

        private void runGame(Engine engine)
        {
            //try
            //{
                engine.Run();
            //}
            //catch (Exception e)
            //{
            //    Debug.Instance.WriteLine(NAME, $"Ran into a fatal error: {e.Message}\n{e.StackTrace}", ConsoleColor.Green, ConsoleColor.Red);
            //    Debug.Instance.SaveLog();
            //}
            Environment.Exit(0);
        }
    }
}
