using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.UI.UIComponents
{
    /// <summary>
    /// Abstract class of a user interface component.
    /// </summary>
    public class UIComponent : IUpdated, IInput
    {
        #region Events
        public delegate void UIEvent(UIComponent component);
        public UIEvent OnClick, Hovering, OnEnter, OnLeave;

        public virtual Point Size
        {
            get { return size; }
            set
            {
                size = value;
            }
        }
        public virtual Point Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }

        protected string text;
        protected SpriteFont font;
        protected Texture2D texture;
        private Point size, position;
        private Point prevMousePosition;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the ui component.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="texture"></param>
        /// <param name="text"></param>
        public UIComponent(SpriteFont font, Texture2D texture, string text)
        {
            this.text = text;
            this.font = font;
            this.texture = texture;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets the position in the middle of the screen relative to the size of the object
        /// to be centers.
        /// </summary>
        /// <param name="objSize"></param>
        /// <returns></returns>
        protected Vector2 GetMiddlePosition(Vector2 objSize)
        {
            return SceneManager.Instance.GetWindowSize().ToVector2() / 2 - objSize / 2;
        }


        /// <summary>
        /// Gets the position in the middle of the given region to the size of the object
        /// to be centers.
        /// </summary>
        /// <param name="regionSize"></param>
        /// <param name="objSize"></param>
        /// <returns></returns>
        protected Vector2 GetMiddlePosition(Vector2 regionSize, Vector2 objSize)
        {
            return regionSize / 2 - objSize / 2;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(position, size);
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        public virtual void ProcessInput(InputManager input)
        {
            Point currentPosition = input.GetMousePosition();
            Rectangle rect = GetRectangle();

            if (rect.Contains(currentPosition))
            {
                Hovering?.Invoke(this);
                if (rect.Contains(prevMousePosition))
                {
                    OnEnter?.Invoke(this);
                }

                if (input.IsMouseClicked(MouseButton.LEFT) || input.IsMouseClicked(MouseButton.RIGHT)
                    || input.IsMouseClicked(MouseButton.MIDDLE))
                {
                    OnClick?.Invoke(this);
                }
            }
            else if (rect.Contains(prevMousePosition))
            {
                OnLeave?.Invoke(this);
            }

            prevMousePosition = currentPosition;
        }
        #endregion
    }
}
