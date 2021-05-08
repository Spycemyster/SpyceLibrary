using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpyceLibrary.Debugging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.UI.UIComponents
{
    public class UITextBox : UIComponent
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
        private StringBuilder builder;
        private float timer;
        private bool keyPressed;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the UI button.
        /// </summary>
        public UITextBox(SpriteFont font, Texture2D texture, string text)
            : base(font, texture, text)
        {
            opacity = 1f;
            OnEnter += onEnter;
            OnLeave += onLeave;
            builder = new StringBuilder();
            keyPressed = false;
            timer = 0;
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
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (keyPressed)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                timer = 0f;
            }
        }
        public override void ProcessInput(InputManager input)
        {
            bool spamText = timer > 0.5f;
            base.ProcessInput(input);
            keyPressed = false;
            
            for (int i = 0; i < 26; i++)
            {
                //Debug.Instance.WriteLine("TEXTBOX", timer + "");
                if (input.IsKeyDown(Keys.A + i))
                {
                    keyPressed = true;
                    if (spamText || input.IsKeyJustPressed(Keys.A + i))
                    {
                        char c = (char)(97 + i);
                        builder.Append(c);
                        text = builder.ToString();
                        UpdateTextPosition();
                        return;
                    }
                }
            }
            if (input.IsKeyDown(Keys.Back) && builder.Length > 0)
            {
                keyPressed = true;
                if (spamText || input.IsKeyJustPressed(Keys.Back))
                {
                    builder.Length--;
                    text = builder.ToString();
                    UpdateTextPosition();
                }
            }

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
