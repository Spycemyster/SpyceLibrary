﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Debugging.Commands
{
    /// <summary>
    /// Lists specific things in the game.
    /// </summary>
    public class ListCommand : ICommand
    {
        /// <summary>
        /// Runs the list command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="initializer"></param>
        public void Run(string sender, string[] args, Initializer initializer)
        {
            int num = -1;
            int page = 0;
            if (args.Length > 2)
            {
                num = int.Parse(args[2]);
            }
            if (args.Length > 3)
            {
                page = int.Parse(args[3]);
            }
            switch(args[1])
            {
                case "objects":
                    // list all objects
                    Dictionary<Guid, GameObject>.ValueCollection objects = SceneManager.Instance.CurrentScene.GameObjects.Values;
                    
                    foreach (GameObject obj in objects)
                    {
                        Debug.Instance.WriteLine(sender, obj.ToString());
                        num--;
                        if (num == 0)
                        {
                            break;
                        }
                    }
                    break;
                default:
                    Debug.Instance.WriteLine("List", $"Could not list type '{args[1]}'");
                    break;
            }
        }

        /// <summary>
        /// Gets the syntax for the command.
        /// </summary>
        /// <returns></returns>
        public string Help()
        {
            return "Prints out a list of the given type.\n\n'list <object type> <count> <page offset>'";
        }
    }
}
