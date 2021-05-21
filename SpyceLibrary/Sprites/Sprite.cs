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
        private Vector2 offset, scale, origin;
        private uint drawOrder;
        private int borderSize;
        private bool hasSetSourceRectangle, hasSetSize, hasSetOrigin, isDrawingBorder;
        private Point size;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game component.
        /// </summary>
        public Sprite()
        {
            isDrawingBorder = hasSetOrigin = hasSetSize = hasSetSourceRectangle = false;
            scale = Vector2.One;
            Color = Color.White;
            origin = Vector2.Zero;
            size = Point.Zero;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Enables or disables the border.
        /// </summary>
        /// <param name="enabled"></param>
        /// <param name="size"></param>
        public void EnableBorder(bool enabled, int size = 1)
        {
            borderSize = size;
            isDrawingBorder = enabled;
        }

        /// <summary>
        /// Sets the origin for the sprite. (By default, it is the center of the loaded texture.)
        /// </summary>
        /// <param name="origin"></param>
        public void SetOrigin(Vector2 origin)
        {
            this.origin = origin;
            hasSetOrigin = true;
        }

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
        /// Sets the size of the sprite before applying scaling. By default it is the size of the texture.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetSize(int width, int height)
        {
            SetSize( new Point(width, height) );
        }

        /// <summary>
        /// Sets the size of the sprite before applying scaling. By default it is the size of the texture.
        /// </summary>
        /// <param name="size"></param>
        public void SetSize(Point size)
        {
            this.size = size;

            // flag
            hasSetSize = true;
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
            SetScale( new Vector2(x, y) );
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
            if (!hasSetSize)
            {
                size = texture.Bounds.Size;
            }
            if (!hasSetSourceRectangle) 
            {
                sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            }
            if (!hasSetOrigin)
            {
                origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
            }
        }

        private void DrawBorder()
        {
            Rectangle rect = GetDrawRectangle();
            rect.Offset(-borderSize, -borderSize);
            spriteBatch.Draw(texture, rect, sourceRectangle, Color.Black, Holder.Rotation,
                origin, SpriteEffects.None, DrawOrder() / IDrawn.MAX_DRAW_ORDER);
            rect = GetDrawRectangle();
            rect.Offset(-borderSize, borderSize);
            spriteBatch.Draw(texture, rect, sourceRectangle, Color.Black, Holder.Rotation,
                origin, SpriteEffects.None, DrawOrder() / IDrawn.MAX_DRAW_ORDER);
            rect = GetDrawRectangle();
            rect.Offset(borderSize, -borderSize);
            spriteBatch.Draw(texture, rect, sourceRectangle, Color.Black, Holder.Rotation,
                origin, SpriteEffects.None, DrawOrder() / IDrawn.MAX_DRAW_ORDER);
            rect = GetDrawRectangle();
            rect.Offset(borderSize, borderSize);
            spriteBatch.Draw(texture, rect, sourceRectangle, Color.Black, Holder.Rotation,
                origin, SpriteEffects.None, DrawOrder() / IDrawn.MAX_DRAW_ORDER);
        }

        /// <summary>
        /// Draws the sprite to the screen.
        /// </summary>
        public virtual void Draw()
        {
            Rectangle rect = GetDrawRectangle();
            
            if (isDrawingBorder)
            {
                DrawBorder();
            }

            spriteBatch.Draw(texture, rect, sourceRectangle, Color, Holder.Rotation,
                origin, SpriteEffects.None, DrawOrder() / IDrawn.MAX_DRAW_ORDER);
        }

        /// <summary>
        /// Gets the size of the drawn sprite.
        /// </summary>
        /// <returns></returns>
        public Point GetSize()
        {
            return new Point((int)(size.X * Holder.Scale.X * scale.X), (int)(size.Y * Holder.Scale.Y * scale.Y));
        }

        /// <summary>
        /// Gets the visible rectangle for the sprite.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetDrawRectangle()
        {
            Point size = GetSize();
            return new Rectangle((int)(Holder.Position.X + offset.X), (int)(Holder.Position.Y + offset.Y), size.X, size.Y);
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
