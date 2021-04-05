using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpyceLibrary.Physics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpyceLibrary.Scenes
{
    /// <summary>
    /// This is the scene that will test the various functionality.
    /// </summary>
    public class TestScene : Scene
    {
        #region Fields
        /// <summary>
        /// The name of this scene.
        /// </summary>
        public const string NAME = "TEST";
        private GraphicsDevice GraphicsDevice;
        private GraphicsDeviceManager graphics;
        private GameWindow Window;
        private ContentManager Content;
        private SpriteBatch spriteBatch;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game scene.
        /// </summary>
        public TestScene()
        {
        }
        #endregion

        #region Methods
        protected override void Load(Initializer initializer)
        {
            base.Load(initializer);

            GraphicsDevice = initializer.Graphics;
            Window = initializer.Window;
            Content = initializer.Content;
            spriteBatch = initializer.SpriteBatch;
            graphics = initializer.Device;

            SceneManager.Instance.SetFrameDimension(854, 480);
            SetInterval(PrintTickSpeed, 3, 3);
        }

        /// <summary>
        /// Adds an object to the scene
        /// </summary>
        /// <param name="obj"></param>
        public override void AddObject(GameObject obj)
        {
            base.AddObject(obj);
            Debug.Instance.WriteLine(NAME, $"Added object of ID: {obj.ID}");
        }

        /// <summary>
        /// Updates the instance of the game scene.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float fps = 1.0f / Time.Instance.RawDeltaTime;
            Window.Title = $"{Debug.Instance.TickSpeed} ms, {(int)fps} fps";
        }

        /// <summary>
        /// Draws the contents of the game scene to the screen.
        /// </summary>
        public override void Draw()
        {
            base.Draw();

            GraphicsDevice.Clear(Color.CornflowerBlue);
        }
        #endregion
    }
}
