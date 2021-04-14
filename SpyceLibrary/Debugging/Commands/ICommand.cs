using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Debugging.Commands
{
    /// <summary>
    /// Base class for all console commands.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command with the given arguments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="initializer"></param>
        public void Run(string sender, string[] args, Initializer initializer);

        /// <summary>
        /// The summary and syntax for what this command.
        /// </summary>
        /// <returns></returns>
        public string Help();
    }
}
