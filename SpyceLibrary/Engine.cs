using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpyceLibrary.Scenes;
using System;

namespace SpyceLibrary
{
    public class Engine : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

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

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Debug.Instance.Initialize(this);
            SceneManager.Instance.Initialize(Content, spriteBatch, GraphicsDevice, graphics, Window);
            Debug.Instance.WriteLine("System", "Running through the SpyceLibrary. By Spencer Chang.",
                ConsoleColor.Green, ConsoleColor.Green);

            // Register all scenes here
            SceneManager.Instance.RegisterScene(typeof(TestScene), TestScene.NAME);

            // Initial scene loading
            SceneManager.Instance.ChangeScene(TestScene.NAME);
        }

        protected override void Update(GameTime gameTime)
        {
            Debug.Instance.StartTick();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            SceneManager.Instance.Update(gameTime);
            Time.Instance.Update(gameTime);
            InputManager.Instance.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            SceneManager.Instance.Draw();

            base.Draw(gameTime);

            Debug.Instance.EndTick();
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);

            Debug.Instance.WriteLine("System", "Quitting the game...", ConsoleColor.Green, ConsoleColor.Green);
            SceneManager.Instance.OnExiting();
            Debug.Instance.WriteLine("System", "Bye!", ConsoleColor.Green, ConsoleColor.Green);
            Debug.Instance.SaveLog();
        }
    }
}
