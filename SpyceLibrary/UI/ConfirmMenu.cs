using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpyceLibrary.UI.UIComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.UI
{
    /// <summary>
    /// A menu that confirms yes or no.
    /// </summary>
    public class ConfirmMenu : UIScreen
    {
        private Texture2D blank;
        private Rectangle panelRect;
        private Point rectSize;
        public UIButton YesButton, NoButton;
        /// <summary>
        /// Creates a new instance of the confirm menu.
        /// </summary>
        /// <param name="currentScene"></param>
        public ConfirmMenu(Scene currentScene) : base(currentScene)
        {
        }

        public override void Initialize(Initializer initializer)
        {
            base.Initialize(initializer);
            blank = initializer.Content.Load<Texture2D>("System/blank");
            font = initializer.Content.Load<SpriteFont>("System/DebugFont");
            rectSize = new Point(400, 250);
            SetTitle("Are you sure?", Color.White);
            titlePos = GetMiddlePosition(font.MeasureString(title));
            Point rectPos = GetMiddlePosition(SceneManager.Instance.GetWindowSize().ToVector2(), rectSize.ToVector2()).ToPoint();
            panelRect = new Rectangle(rectPos, rectSize);
            YesButton = new UIButton(font, blank, "Yes")
            {
                Size = new Point(60, 60),
                BackgroundColor = Color.MediumVioletRed,
                TextColor = Color.White,
            };
            YesButton.Position = (GetMiddlePosition(YesButton.Size.ToVector2()) + new Vector2(60, 50)).ToPoint();
            NoButton = new UIButton(font, blank, "No")
            {
                Size = new Point(60, 60),
                BackgroundColor = Color.LightBlue,
                TextColor = Color.White,
            };
            NoButton.Position = (GetMiddlePosition(NoButton.Size.ToVector2()) + new Vector2(-60, 50)).ToPoint();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            YesButton.Update(gameTime);
            NoButton.Update(gameTime);
        }

        public override void ProcessInput(InputManager input)
        {
            base.ProcessInput(input);
            YesButton.ProcessInput(input);
            NoButton.ProcessInput(input);

            if (input.IsKeyDown(Keys.Escape))
            {
                NoButton.OnClick?.Invoke(NoButton);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(blank, panelRect, Color.Blue);
            spriteBatch.DrawString(font, title, titlePos, color);
            YesButton.Draw(spriteBatch);
            NoButton.Draw(spriteBatch);
        }
    }
}
