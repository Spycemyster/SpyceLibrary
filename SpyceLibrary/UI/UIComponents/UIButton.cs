using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.UI.UIComponents
{
    public class UIButton : UIComponent
    {
        #region Fields
        public Color BackgroundColor
        {
            get;
            set;
        }

        public Color TextColor
        {
            get;
            set;
        }


        private Vector2 textPosition;
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
        public override void ProcessInput(InputManager input)
        {
            base.ProcessInput(input);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(texture, GetRectangle(), BackgroundColor * opacity);
            spriteBatch.DrawString(font, text, textPosition, TextColor);
        }
        #endregion
    }
}
