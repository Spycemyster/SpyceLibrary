using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.UI
{
    /// <summary>
    /// Handles the user interface for a screen.
    /// </summary>
    public class UIScreen : IInput
    {
        #region Fields
        /// <summary>
        /// The displayed title of the ui.
        /// </summary>
        protected string title;

        /// <summary>
        /// The color of the title text.
        /// </summary>
        protected Color color;

        /// <summary>
        /// The position of the title text.
        /// </summary>
        protected Vector2 titlePos;

        /// <summary>
        /// 
        /// </summary>
        protected SpriteFont font;
        protected Scene Scene 
        {
            get { return currentScene; }
        }
        private Scene currentScene;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the ui screen.
        /// </summary>
        /// <param name="currentScene"></param>
        public UIScreen(Scene currentScene)
        {
            SetTitle("", Color.White);
            this.currentScene = currentScene;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the ui screen.
        /// </summary>
        /// <param name="initializer"></param>
        public virtual void Initialize(Initializer initializer)
        {

        }

        /// <summary>
        /// Updates the state of the UI state.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            
        }

        /// <summary>
        /// Draws the UI elements to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

        /// <summary>
        /// Displays the title of the UI to the top of the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void DrawTitle(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, title, titlePos, color);
        }

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
        /// Sets the state to closing
        /// </summary>
        public virtual void Close()
        {
            Scene.UIs.Remove(this);
        }

        /// <summary>
        /// Sets the title for the screen.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public virtual void SetTitle(string text, Color color)
        {
            this.title = text;
            this.color = color;
        }

        /// <summary>
        /// Processes the input for the ui.
        /// </summary>
        /// <param name="input"></param>
        public virtual void ProcessInput(InputManager input)
        {
        }

        #endregion
    }

    /// <summary>
    /// Determines the state of the user interface window on the current scene.
    /// </summary>
    public enum UIState
    {
        /// <summary>
        /// The current ui is actively being focused and updated.
        /// </summary>
        Active,

        /// <summary>
        /// The current ui is closed.
        /// </summary>
        Closed,

        /// <summary>
        /// The current ui is run in parallel with the gameplay.
        /// </summary>
        Parallel,

        /// <summary>
        /// The game is currently in "gameplay" mode.
        /// </summary>
        Gameplay,
    }
}
