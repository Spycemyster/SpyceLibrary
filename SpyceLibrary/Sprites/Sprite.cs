using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Sprites
{
    /// <summary>
    /// Represents a drawable texture to the game object.
    /// </summary>
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
        private Rectangle sourceRectangle;
        private SpriteBatch spriteBatch;
        private Vector2 offset;
        private uint drawOrder;
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
        /// Sets the source rectangle for the sprite.
        /// </summary>
        /// <param name="sourceRect"></param>
        public void SetSourceRectangle(Rectangle sourceRect)
        {
            sourceRectangle = sourceRect;
        }

        /// <summary>
        /// Sets the draw order for the sprite.
        /// </summary>
        /// <param name="order"></param>
        public void SetDrawOrder(uint order)
        {
            drawOrder = order;
        }
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
        /// Sets the drawn dimension of the sprite.
        /// </summary>
        /// <param name="size"></param>
        public void SetSize(Point size)
        {
            this.size = size;
        }

        /// <summary>
        /// Sets the drawn dimension of the sprite.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetSize(int width, int height)
        {
            SetSize(new Point(width, height));
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
            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        /// <summary>
        /// Draws the sprite to the screen.
        /// </summary>
        public virtual void Draw()
        {
            Rectangle rect = GetDrawRectangle();
            if (GetDrawRectangle().Intersects(SceneManager.Instance.CurrentScene.ScreenRectangle))
            {
                Transform tr = Holder.GetTransform();
                spriteBatch.Draw(texture, rect, sourceRectangle, Color.White, tr.Rotation,
                    Vector2.Zero, SpriteEffects.None, DrawOrder() / IDrawn.MAX_DRAW_ORDER);
            }
        }

        /// <summary>
        /// Gets the visible rectangle for the sprite.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetDrawRectangle()
        {
            Transform tr = Holder.GetTransform();
            return new Rectangle((int)(tr.Position.X + offset.X), (int)(tr.Position.Y + offset.Y),
                (int)(size.X * tr.Scale.X), (int)(size.Y * tr.Scale.Y));
        }

        /// <summary>
        /// Gets the draw order for the sprite.
        /// </summary>
        /// <returns></returns>
        public uint DrawOrder()
        {
            return drawOrder;
        }

        #endregion
    }
}
