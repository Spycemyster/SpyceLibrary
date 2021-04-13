using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// Holds necessary data members for initializing game objects.
    /// </summary>
    public class Initializer
    {
        /// <summary>
        /// Loads content for the game object.
        /// </summary>
        public ContentManager Content;

        /// <summary>
        /// The graphics device for the game engine.
        /// </summary>
        public GraphicsDevice Graphics;

        /// <summary>
        /// Allows for creation of sprite batches and drawn to the screen.
        /// </summary>
        public SpriteBatch SpriteBatch;

        /// <summary>
        /// The graphics device manager of the game.
        /// </summary>
        public GraphicsDeviceManager Device;

        /// <summary>
        /// The window of the game engine.
        /// </summary>
        public GameWindow Window;
    }
}
