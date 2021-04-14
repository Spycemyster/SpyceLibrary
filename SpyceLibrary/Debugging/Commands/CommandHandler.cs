using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Debugging.Commands
{
    /// <summary>
    /// Takes in full command lines and parses it into a command form.
    /// </summary>
    public class CommandHandler
    {
        #region Singleton
        /// <summary>
        /// Singleton access to the command handler.
        /// </summary>
        public static CommandHandler Instance
        {
            get
            {
                if (inst == null) inst = new CommandHandler();
                return inst;
            }
        }

        /// <summary>
        /// The name of the debug messages that originate from this class.
        /// </summary>
        public const string COMMAND_NAME = "CONSOLE";
        private static CommandHandler inst;
        private Initializer initializer;
        private CommandHandler()
        {
            commands = new Dictionary<string, ICommand>();
        }
        private Dictionary<string, ICommand> commands;
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the command handler.
        /// </summary>
        /// <param name="initializer"></param>
        public void Initialize(Initializer initializer)
        {
            this.initializer = initializer;
            commands.Add("echo", new EchoCommand());
            commands.Add("list", new ListCommand());
            commands.Add("exit", new ExitCommand());
        }

        /// <summary>
        /// Parses the arguments and executes the command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="command"></param>
        public void ParseCommand(string sender, string command)
        {
            string[] tokenized = TokenizeCommand(command);
            if (tokenized.Length == 0)
            {
                return;
            }
            ICommand exec = null;
            if (!commands.ContainsKey(tokenized[0]) && tokenized[0] != "help")
            {
                Debug.Instance.WriteLine(COMMAND_NAME, $"Command '{tokenized[0]}' could not be found... " +
                    $"(Type 'help' to see a list of all commands)");

                return;
            }
            if (tokenized[0] != "help")
            {
                exec = commands[tokenized[0]];
            }
            else if (tokenized.Length >= 2)
            {
                if (commands.ContainsKey(tokenized[1]))
                {
                    exec = commands[tokenized[1]];
                }
            }
            else
            {
                PrintHelp();
                return;
            }


            if (tokenized[0] != "help")
            {
                exec?.Run(sender, tokenized, initializer);
            }
            else
            {
                Debug.Instance.WriteLine(COMMAND_NAME, exec.Help());
            }

        }

        private void PrintHelp()
        {
            string help = "Here is a list of available commands: ";
            foreach (string c in commands.Keys)
            {
                help += $"{c} ";
            }
            Debug.Instance.WriteLine(COMMAND_NAME, help);
        }

        private string[] TokenizeCommand(string command)
        {
            List<string> tokens = new List<string>();
            string currentToken = "";
            bool quoteMode = false;
            for (int i = 0; i < command.Length; i++)
            {
                char c = command[i];
                if (quoteMode)
                {
                    if (c == '"')
                    {
                        quoteMode = false;
                        tokens.Add(currentToken);
                    }
                    else
                    {
                        currentToken += c;
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        quoteMode = true;
                    }
                    else if (c == ' ')
                    {
                        if (currentToken.Length > 0)
                        {
                            tokens.Add(currentToken);
                            currentToken = "";
                        }
                    }
                    else
                    {
                        currentToken += c;
                    }
                }
            }

            // adds the last token to the list
            if (currentToken.Length > 0)
            {
                tokens.Add(currentToken);
            }
            return tokens.ToArray();
        }
        #endregion
    }
}
