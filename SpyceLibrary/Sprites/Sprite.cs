using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Sprites
{
    public class Sprite : GameComponent, IDrawn
    {
        #region Fields
        /// <summary>
        /// The path of the texture.
        /// </summary>
        public string TexturePath
        {
            get { return texturePath; }
        }
        private Texture2D texture;
        private string texturePath;
        private Point size;
        private SpriteBatch spriteBatch;
        private Vector2 offset;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game component.
        /// </summary>
        public Sprite()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the texture path of the sprite.
        /// </summary>
        /// <param name="path"></param>
        public void SetTexturePath(string path)
        {
            texturePath = path;
        }

        /// <summary>
        /// Sets the offset of the sprite.
        /// </summary>
        /// <param name="offset"></param>
        public void SetOffset(Vector2 offset)
        {
            this.offset = offset;
        }

        /// <summary>
        /// Loads the textures of the sprite.
        /// </summary>
        /// <param name="init"></param>
        /// <param name="holder"></param>
        public override void Load(Initializer init, GameObject holder)
        {
            base.Load(init, holder);
            spriteBatch = init.SpriteBatch;
            texture = init.Content.Load<Texture2D>(texturePath);
            size = new Point(texture.Width, texture.Height);
        }

        /// <summary>
        /// Draws the sprite to the screen.
        /// </summary>
        public void Draw()
        {
            Transform tr = Holder.GetTransform();
            Rectangle rect = GetDrawRectangle();
            spriteBatch.Draw(texture, rect, null, Color.White, tr.Rotation,
                Vector2.Zero, SpriteEffects.None, DrawOrder());
        }

        private Rectangle GetDrawRectangle()
        {
            Transform tr = Holder.GetTransform();
            return new Rectangle((int)(tr.Position.X + offset.X), (int)(tr.Position.Y + offset.Y),
                (int)(size.X * tr.Scale.X), (int)(size.Y * tr.Scale.Y));
        }

        public int DrawOrder()
        {
            return 0;
        }

        #endregion
    }
}
