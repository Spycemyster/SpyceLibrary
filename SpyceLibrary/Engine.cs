using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpyceLibrary.Scenes;
using SpyceLibrary.Debugging;
using System;

namespace SpyceLibrary
{
    /// <summary>
    /// The game engine holds various components from the game and runs them respectively.
    /// </summary>
    public class Engine : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private const string DEBUG_NAME = "SYSTEM";

        /// <summary>
        /// Creates a new instance of the engine.
        /// </summary>
        public Engine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = false;
        }

        /// <summary>
        /// Initializes the graphics window.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Loads and initializes necessary game assets.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Debug.Instance.Initialize(this, null);
            SceneManager.Instance.Initialize(Content, spriteBatch, GraphicsDevice, graphics, Window);
            Debug.Instance.WriteLine(DEBUG_NAME, "Running through the SpyceLibrary. By Spencer Chang.",
                ConsoleColor.Green, ConsoleColor.Green);

            // Register all scenes here
            SceneManager.Instance.RegisterScene(typeof(TestScene), TestScene.NAME);

            // Initial scene loading
            SceneManager.Instance.ChangeScene(TestScene.NAME);
        }

        /// <summary>
        /// Updates the state of the game and it's members.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            Debug.Instance.StartUpdateTick();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            SceneManager.Instance.Update(gameTime);
            Time.Instance.Update(gameTime);
            InputManager.Instance.Update();

            base.Update(gameTime);
            Debug.Instance.EndUpdateTick();
        }

        /// <summary>
        /// Draws the instance of the engine.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            Debug.Instance.StartDrawTick();
            SceneManager.Instance.Draw();

            base.Draw(gameTime);

            Debug.Instance.EndDrawTick();
        }

        /// <summary>
        /// Called when the game is exiting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);

            Debug.Instance.WriteLine(DEBUG_NAME, "Quitting the game...", ConsoleColor.Green, ConsoleColor.Green);
            SceneManager.Instance.OnExiting();
            Debug.Instance.WriteLine(DEBUG_NAME, "Bye!", ConsoleColor.Green, ConsoleColor.Green);
            Debug.Instance.SaveLog(DEBUG_NAME);
        }
    }
}
