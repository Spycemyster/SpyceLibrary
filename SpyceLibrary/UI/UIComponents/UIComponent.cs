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
        /// <summary>
        /// An event that has to do with user interface components.
        /// </summary>
        /// <param name="component"></param>
        public delegate void UIEvent(UIComponent component);

        /// <summary>
        /// When the component is clicked on.
        /// </summary>
        public UIEvent OnClick;

        /// <summary>
        /// When the user hovers their mouse over the component.
        /// </summary>
        public UIEvent Hovering;

        /// <summary>
        /// When the user's mouse just hovers over the component.
        /// </summary>
        public UIEvent OnEnter;

        /// <summary>
        /// When the user's mouse just leaves the component.
        /// </summary>
        public UIEvent OnLeave;

        /// <summary>
        /// The size of the component.
        /// </summary>
        /// <value></value>
        public virtual Point Size
        {
            get { return size; }
            set
            {
                size = value;
            }
        }

        /// <summary>
        /// The position of the component.
        /// </summary>
        /// <value></value>
        public virtual Point Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// The text drawn for the ui component.
        /// </summary>
        protected string text;

        /// <summary>
        /// The font of the text drawn for the ui component.
        /// </summary>
        protected SpriteFont font;

        /// <summary>
        /// The texture of the component.
        /// </summary>
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

        /// <summary>
        /// The draw rectangle for the ui component.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            return new Rectangle(position, size);
        }

        /// <summary>
        /// Updates the behavior of the ui component.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Draws the component to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        /// <summary>
        /// Processes user input with respect to the component.
        /// </summary>
        /// <param name="input"></param>
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
