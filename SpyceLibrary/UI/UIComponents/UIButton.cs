using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.UI.UIComponents
{
    /// <summary>
    /// A button that can be clicked by the user.
    /// </summary>
    public class UIButton : UIComponent
    {
        #region Fields
        /// <summary>
        /// The color of the button's background.
        /// </summary>
        /// <value></value>
        public Color BackgroundColor
        {
            get;
            set;
        }

        /// <summary>
        /// The color of the text.
        /// </summary>
        /// <value></value>
        public Color TextColor
        {
            get;
            set;
        }

        /// <summary>
        /// The size of the button.
        /// </summary>
        /// <value></value>
        public override Point Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                base.Size = value;
                UpdateTextPosition();
            }
        }

        /// <summary>
        /// The position of the button.
        /// </summary>
        /// <value></value>
        public override Point Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                UpdateTextPosition();
            }
        }

        private Vector2 textPosition;
        private float opacity;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the UI button.
        /// </summary>
        public UIButton(SpriteFont font, Texture2D texture, string text) 
            : base(font, texture, text)
        {
            opacity = 1f;
            OnEnter += onEnter;
            OnLeave += onLeave;
        }
        #endregion

        #region Methods
        private void onEnter(UIComponent component)
        {
            opacity = 0.5f;
        }
        private void onLeave(UIComponent component)
        {
            opacity = 1f;
        }

        private void UpdateTextPosition()
        {
            textPosition = Position.ToVector2() + GetMiddlePosition(Size.ToVector2(), font.MeasureString(text));
        }

        /// <summary>
        /// Processes user input.
        /// </summary>
        /// <param name="input"></param>
        public override void ProcessInput(InputManager input)
        {
            base.ProcessInput(input);
        }

        /// <summary>
        /// Draws the button to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(texture, GetRectangle(), BackgroundColor * opacity);
            spriteBatch.DrawString(font, text, textPosition, TextColor);
        }
        #endregion
    }
}
