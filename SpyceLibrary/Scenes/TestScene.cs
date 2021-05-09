using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpyceLibrary.Physics;
using SpyceLibrary.Sprites;
using SpyceLibrary.Debugging;
using System;
using SpyceLibrary.UI;
using Microsoft.Xna.Framework.Input;

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
        private ParticleEngine particleEngine;

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

            PushUI(new HUD(this));

            GameObject player = CreateTestPlayer();
            player["Camera"] = mainCamera;
            AddObject(player);

            #region Don't look...
            //GameObject obj1 = CreateBlankSprite(25, 25);
            //obj1.RelativeTransform.SetPosition(50, 50);
            //GameObject obj2 = CreateBlankSprite(25, 25);
            //obj2.RelativeTransform.SetPosition(100, 50);
            //GameObject obj3 = CreateBlankSprite(25, 100);
            //obj3.RelativeTransform.SetPosition(75, 80);

            //AddObject(obj1);
            //AddObject(obj2);
            //AddObject(obj3);
            #endregion

            for (int i = 0; i < 10000; i++)
            {
                GameObject obj = CreateBlankSprite(random.Next(10, 100), random.Next(10, 100));//CreateBlankSprite(100, 100);
                obj.RelativeTransform.SetPosition(random.Next(0, 10000), random.Next(0, 10000));
                AddObject(obj);
            }

            mainCamera.FixViewOn(player);
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
            PhysicsBody body = new PhysicsBody
            {
                IsCollidable = true
            };
            obj.AddComponent(body);
            obj.AddComponent(new TestComponent2());
            BoxCollider collider = new BoxCollider();
            obj.AddComponent(collider);
            collider.SetBounds(new Point(width, height));
            collider.SetOffset(new Point(0, 0));
            obj["type"] = "BlankSprite";
            return obj;
        }
         
        private GameObject CreateTestPlayer()
        {
            GameObject obj = new GameObject();
            Sprite sp = new Sprite();
            sp.SetSize(10, 10);
            sp.SetTexturePath("System/blank");
            obj.AddComponent(sp);
            PhysicsBody body = new PhysicsBody();
            obj.AddComponent(body);
            obj.AddComponent(new TestComponent());
            BoxCollider collider = new BoxCollider();
            collider.SetBounds(new Point(10, 10));
            collider.SetOffset(new Point(0, 0));
            obj.AddComponent(collider);
            obj["type"] = "Player";

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
            SetScreenRectangleLocation((int)mainCamera.TopLeft.X, (int)mainCamera.TopLeft.Y);
            CheckInput();
        }

        private void CheckInput()
        {
            if (InputManager.Instance.IsKeyDown(Keys.Q))
            {
                GameObject obj = CreateBlankSprite(random.Next(10, 100), random.Next(10, 100));//CreateBlankSprite(100, 100);
                obj.RelativeTransform.SetPosition(random.Next(0, 1000), random.Next(0, 1000));
                AddObject(obj);
            }
            else if (InputManager.Instance.IsKeyDown(Keys.E))
            {
                foreach (GameObject o in GameObjects.Values)
                {
                    if ((string)o["type"] == "BlankSprite")
                    {
                        RemoveObject(o.ID);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Draws the contents of the game scene to the screen.
        /// </summary>
        public override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(transformMatrix: mainCamera.GetTransformedMatrix());

            base.Draw();

            //physicsEngine.Draw(mainCamera);

            spriteBatch.End();

            spriteBatch.Begin();
            DrawUI();
            Debug.Instance.Draw(spriteBatch);
            spriteBatch.End();
        }
        #endregion
    }
}
