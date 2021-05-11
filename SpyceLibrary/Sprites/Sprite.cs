using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpyceLibrary.Debugging;
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
            set 
            {
                Debug.Instance.Assert(!IsLoaded, "Changing the texture path, but the texture was already loaded...");
                texturePath = value;
            }
        }

        /// <summary>
        /// The tinted color for the sprite.
        /// </summary>
        /// <value></value>
        public Color Color 
        {
            get;
            set;
        }
        private Texture2D texture;
        private string texturePath;
        private Rectangle sourceRectangle;
        private SpriteBatch spriteBatch;
        private Vector2 offset, scale;
        private uint drawOrder;
        private bool hasSetSourceRectangle;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game component.
        /// </summary>
        public Sprite()
        {
            hasSetSourceRectangle = false;
            scale = Vector2.Zero;
            Color = Color.White;
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
            hasSetSourceRectangle = true;
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
        /// Sets the scale of the sprite's drawn texture.
        /// </summary>
        /// <param name="scale"></param>
        public void SetScale(Vector2 scale)
        {
            this.scale = scale;
        }

        /// <summary>
        /// Sets the scale of the sprite's drawn texture.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetScale(float x, float y) 
        {
            SetScale(new Vector2(x, y));
        }

        /// <summary>
        /// Sets the scale of the sprite's drawn texture.
        /// </summary>
        /// <param name="scale"></param>
        public void SetScale(float scale) 
        {
            SetScale(scale, scale);
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
            if (!hasSetSourceRectangle) {
                sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            }
        }

        /// <summary>
        /// Draws the sprite to the screen.
        /// </summary>
        public virtual void Draw()
        {
            Rectangle rect = GetDrawRectangle();
            if (rect.Intersects(SceneManager.Instance.CurrentScene.ScreenRectangle))
            {
                Transform tr = Holder.GetTransform();
                spriteBatch.Draw(texture, rect, sourceRectangle, Color, tr.Rotation,
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
            Point size = new Point((int)(texture.Width * tr.Scale.X * scale.X), (int)(texture.Height * tr.Scale.Y * scale.Y));
            return new Rectangle((int)(tr.Position.X + offset.X - size.X / 2), (int)(tr.Position.Y + offset.Y - size.Y / 2),
                size.X, size.Y);
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
