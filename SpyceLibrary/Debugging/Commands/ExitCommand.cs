using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Debugging.Commands
{
    /// <summary>
    /// Exits the game.
    /// </summary>
    public class ExitCommand : ICommand
    {
        /// <summary>
        /// The syntax of the command.
        /// </summary>
        /// <returns></returns>
        public string Help()
        {
            return "Exits the game.\n\n\t'exit'";
        }

        /// <summary>
        /// Runs the exit command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="initializer"></param>
        public void Run(string sender, string[] args, Initializer initializer)
        {
            Debug.Instance.WriteLine(CommandHandler.COMMAND_NAME, $"Exit request called from from {sender}.");
            Debug.Instance.Exit();
        }
    }
}
