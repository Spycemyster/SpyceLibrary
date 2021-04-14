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
    public class UIScreen
    {
        #region Fields
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the ui screen.
        /// </summary>
        public UIScreen()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Process key presses.
        /// </summary>
        public virtual void HandleKeyPress()
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
        #endregion
    }
}
