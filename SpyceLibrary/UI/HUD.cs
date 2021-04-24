using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpyceLibrary.UI
{
    public class HUD : UIScreen
    {

        #region Constructor
        /// <summary>
        /// Creates a new instance of the HUD.
        /// </summary>
        /// <param name="currentScene"></param>
        public HUD(Scene currentScene) 
            : base(currentScene)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Closes the UI.
        /// </summary>
        public override void Close()
        {
            base.Close();
            Scene.SetState(UIState.Gameplay);
        }

        /// <summary>
        /// Initializes the HUD.
        /// </summary>
        /// <param name="initializer"></param>
        public override void Initialize(Initializer initializer)
        {
            SetTitle("HUD Menu", Color.White);
            base.Initialize(initializer);
            font = initializer.Content.Load<SpriteFont>("System/DebugFont");

            titlePos = GetMiddlePosition(font.MeasureString(title));
            titlePos.Y = 16;

            Scene.SetState(UIState.Parallel);
        }

        /// <summary>
        /// Updates the state of the HUD.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the HUD to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Processes the input for the ui.
        /// </summary>
        /// <param name="input"></param>
        public override void ProcessInput(InputManager input)
        {
            base.ProcessInput(input);

            if (input.IsKeyJustPressed(Keys.Escape))
            {
                Scene.PushUI(new PauseMenu(Scene));
            }
        }
        #endregion
    }
}