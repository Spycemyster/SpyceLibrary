using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    public abstract class Screen
    {
        /// <summary>
        /// Loads content and generates graphics.
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="graphics"></param>
        public abstract void LoadContent(ContentManager Content, GraphicsDevice graphics);

        /// <summary>
        /// Initializes the screen. This is performed before LoadContent.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Performs real time behaviors of the screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Renders textures to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
