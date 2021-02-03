using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.GameComponents
{
    public class Sprite : GameComponent
    {
        private Texture2D texture;
        private readonly string path;

        /// <summary>
        /// Creates a new instance of the sprite.
        /// </summary>
        public Sprite(string path) : base()
        {
            this.path = path;
        }
        public override bool IsDrawn()
        {
            return true;
        }

        public override bool IsUpdated()
        {
            return true;
        }

        public override void Initialize(ContentManager Content, GraphicsDevice graphics, GameObject obj)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
