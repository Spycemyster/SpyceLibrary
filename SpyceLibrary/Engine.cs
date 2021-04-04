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

        public Engine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            Debug.Instance.WriteLine("System", "Running through the SpyceLibrary. By Spencer Chang.", ConsoleColor.Green, ConsoleColor.Green);

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SceneManager.Instance.Initialize(Content, spriteBatch, GraphicsDevice, graphics);

            // Register all scenes here
            SceneManager.Instance.RegisterScene(typeof(GameScene), GameScene.NAME);

            // Initial scene loading
            SceneManager.Instance.ChangeScene(GameScene.NAME);
        }

        protected override void Update(GameTime gameTime)
        {
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
