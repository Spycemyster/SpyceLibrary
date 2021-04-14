using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Debugging.Commands
{
    /// <summary>
    /// A simple echo command that prints the text after the command.
    /// </summary>
    public class EchoCommand : ICommand
    {
        /// <summary>
        /// Runs the echo command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="initializer"></param>
        public void Run(string sender, string[] args, Initializer initializer)
        {
            Debug.Instance.WriteLine(sender, args[1]);
        }

        /// <summary>
        /// Prints out the syntax for the command.
        /// </summary>
        /// <returns></returns>
        public string Help()
        {
            return "Prints out the given screen to the console.\n\n'echo \"insert string here in quotes\"'";
        }
    }
}
