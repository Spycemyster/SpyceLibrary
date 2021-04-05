using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    public struct Initializer
    {
        public ContentManager Content;
        public GraphicsDevice Graphics;
        public SpriteBatch SpriteBatch;
        public GraphicsDeviceManager Device;
        public GameWindow Window;
    }
}
