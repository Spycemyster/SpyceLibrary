using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpyceLibrary.Physics;
using SpyceLibrary.Sprites;
using SpyceLibrary.Debugging;
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
        private Camera mainCamera;
        private PhysicsEngine physicsEngine;
        private Random random;

        /// <summary>
        /// Width of the window size.
        /// </summary>
        public const int WINDOW_WIDTH = 1244;

        /// <summary>
        /// Height of the window size.
        /// </summary>
        public const int WINDOW_HEIGHT = 700;
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
        /// <summary>
        /// Loads the scene and initializes it's data members.
        /// </summary>
        /// <param name="initializer"></param>
        protected override void Load(Initializer initializer)
        {
            base.Load(initializer);

            // initializer variables
            GraphicsDevice = initializer.Graphics;
            Window = initializer.Window;
            Content = initializer.Content;
            spriteBatch = initializer.SpriteBatch;
            graphics = initializer.Device;

            // engine initialization
            physicsEngine = new PhysicsEngine();
            physicsEngine.Initialize(initializer);

            // game initialization
            random = new Random();
            mainCamera = new Camera();
            SceneManager.Instance.SetFrameDimension(WINDOW_WIDTH, WINDOW_HEIGHT);
            SetScreenRectangleBounds(WINDOW_WIDTH, WINDOW_HEIGHT);
            SetInterval(PrintTickSpeed, 3, 3);
            GameObject player = CreateTestPlayer();
            AddObject(player);
            //for (int i = 0; i < 10; i++)
            //{
            //    GameObject obj = CreateBlankSprite(random.Next(10, 100), random.Next(10, 100));//CreateBlankSprite(100, 100);
            //    obj.RelativeTransform.SetPosition(random.Next(0, 1000), random.Next(0, 1000));
            //    AddObject(obj);
            //}

            mainCamera.FixViewOn(player);
            mainCamera.SetViewOffsetPercent(new Vector2(0.5f, 0.5f));
        }

        /// <summary>
        /// Unloads the test scene
        /// </summary>
        public override void Unload()
        {
            base.Unload();

            physicsEngine.Clear();
        }

        private GameObject CreateBlankSprite(int width, int height)
        {
            GameObject obj = new GameObject();
            Sprite sp = new Sprite();
            sp.SetSize(new Point(width, height));
            sp.SetTexturePath("System/blank");
            obj.AddComponent(sp);
            PhysicsBody body = new PhysicsBody();
            body.IsCollidable = true;
            obj.AddComponent(body);
            //obj.AddComponent(new TestComponent2());
            BoxCollider collider = new BoxCollider();
            obj.AddComponent(collider);
            collider.SetBounds(new Point(width, height));
            collider.SetOffset(new Point(0, 0));
            return obj;
        }
         
        private GameObject CreateTestPlayer()
        {
            GameObject obj = new GameObject();
            Sprite sp = new Sprite();
            sp.SetSize(10, 10);
            sp.SetTexturePath("System/blank");
            obj.AddComponent(sp);
            obj.AddComponent(new PhysicsBody());
            obj.AddComponent(new TestComponent());
            BoxCollider collider = new BoxCollider();
            collider.SetBounds(new Point(10, 10));
            collider.SetOffset(new Point(0, 0));
            obj.AddComponent(collider);

            return obj;
        }

        /// <summary>
        /// Adds an object to the scene
        /// </summary>
        /// <param name="obj"></param>
        public override void AddObject(GameObject obj)
        {
            base.AddObject(obj);

            if (obj.GetComponent<PhysicsBody>() != null)
            {
                physicsEngine.RegisterBody(obj.GetComponent<PhysicsBody>());
            }

            //Debug.Instance.WriteLine(NAME, $"Added object of ID: {obj.ID}");
        }

        /// <summary>
        /// Updates the instance of the game scene.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            double fps = Math.Round(1.0 / Time.Instance.RawDeltaTime);
            Window.Title = $"{Debug.Instance.TickSpeed} ms, {(int)fps} fps";
            physicsEngine.Update(gameTime);
            SetScreenRectangleLocation((int)mainCamera.Position.X, (int)mainCamera.Position.Y);
        }

        /// <summary>
        /// Draws the contents of the game scene to the screen.
        /// </summary>
        public override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(transformMatrix: mainCamera.GetTransformedMatrix());

            base.Draw();

            physicsEngine.Draw(mainCamera);

            spriteBatch.End();

            spriteBatch.Begin();
            Debug.Instance.Draw(spriteBatch);
            spriteBatch.End();
        }
        #endregion
    }
}
