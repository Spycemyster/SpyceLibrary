using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Scenes
{
    /// <summary>
    /// This is the scene that the main gameplay takes place on.
    /// </summary>
    public class GameScene : Scene
    {
        #region Fields
        /// <summary>
        /// The name of this scene.
        /// </summary>
        public const string NAME = "GameScene";
        private GraphicsDevice graphics;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game scene.
        /// </summary>
        public GameScene()
        {
        }
        #endregion

        #region Methods
        protected override void Load(Initializer initializer)
        {
            base.Load(initializer);

            graphics = initializer.Graphics;
            SceneManager.Instance.SetFrameDimension(854, 480);
        }

        /// <summary>
        /// Updates the instance of the game scene.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the contents of the game scene to the screen.
        /// </summary>
        public override void Draw()
        {
            base.Draw();

            graphics.Clear(Color.CornflowerBlue);
        }
        #endregion
    }
}
