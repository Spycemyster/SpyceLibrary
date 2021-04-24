using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpyceLibrary.Debugging;
using SpyceLibrary.UI.UIComponents;
using System;
using System.Collections.Generic;
using System.Text;
using static SpyceLibrary.Scene;

namespace SpyceLibrary.UI
{
    public class PauseMenu : UIScreen
    {
        #region Fields
        private UIButton quitBtn, resumeBtn;
        private ConfirmMenu conf;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the pause menu.
        /// </summary>
        /// <param name="currentScene"></param>
        public PauseMenu(Scene currentScene) : base(currentScene)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the pause menu.
        /// </summary>
        /// <param name="initializer"></param>
        public override void Initialize(Initializer initializer)
        {
            base.Initialize(initializer);
            font = initializer.Content.Load<SpriteFont>("System/DebugFont");
            Scene.SetState(UIState.Active);
            SetTitle("Pause", Color.White);

            titlePos = new Vector2(SceneManager.Instance.GetWindowSize().ToVector2().X
                / 2 - font.MeasureString(title).X / 2, 16);

            quitBtn = new UIButton(font, initializer.Content.Load<Texture2D>("System/blank"), "Quit")
            {
                Size = new Point(100, 30),
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
            };
            quitBtn.Position = GetMiddlePosition(quitBtn.Size.ToVector2() - new Vector2(0, 50)).ToPoint();
            quitBtn.OnClick += confirmClose;
            resumeBtn = new UIButton(font, initializer.Content.Load<Texture2D>("System/blank"), "Resume")
            {
                Size = new Point(100, 30),
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
            };
            resumeBtn.Position = GetMiddlePosition(resumeBtn.Size.ToVector2() + new Vector2(0, 50)).ToPoint();
            resumeBtn.OnClick += resumeClick;
            conf = new ConfirmMenu(Scene);
            conf.Initialize(initializer);
        }

        private void confirmClose(UIComponent component)
        {
            Scene.PushUI(conf);
            conf.YesButton.OnClick += closeGame;
            conf.NoButton.OnClick += closeConfirm;
        }

        private void closeConfirm(UIComponent component)
        {
            conf.Close(); 
        }

        private void closeGame(UIComponent component)
        {
            Debug.Instance.Exit();
        }

        private void resumeClick(UIComponent component)
        {
            Close();
        }

        public override void Close()
        {
            base.Close();
            Scene.SetState(UIState.Gameplay);
            Time.Instance.Timestep = 1;
        }

        public override void ProcessInput(InputManager input)
        {
            base.ProcessInput(input);

            resumeBtn.ProcessInput(input);
            quitBtn.ProcessInput(input);

            if (input.IsKeyJustPressed(Keys.Escape))
            {
                Close();
            }
        }

        /// <summary>
        /// Updates the state of the pause menu.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            resumeBtn.Update(gameTime);
            quitBtn.Update(gameTime);
            Time.Instance.Timestep = 0f;
        }

        /// <summary>
        /// Draws the pause menu
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            resumeBtn.Draw(spriteBatch);
            quitBtn.Draw(spriteBatch);
            spriteBatch.DrawString(font, title, titlePos, color);
        }
        #endregion
    }
}
