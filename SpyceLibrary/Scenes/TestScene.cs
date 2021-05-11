using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpyceLibrary.Physics;
using SpyceLibrary.Sprites;
using SpyceLibrary.Debugging;
using System;
using SpyceLibrary.UI;
using Microsoft.Xna.Framework.Input;
using SpyceLibrary.Lighting;

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
        // private PhysicsEngine collisionEngine;
        private LightEngine lightEngine;
        private Random random;
        private Texture2D blank;
        private RenderTarget2D lightTarget, mainTarget;

        /// <summary>
        /// Width of the window size.
        /// </summary>
        public const int WINDOW_WIDTH = 1600;

        /// <summary>
        /// Height of the window size.
        /// </summary>
        public const int WINDOW_HEIGHT = 900;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game scene.
        /// </summary>
        public TestScene()
        {
            OnObjectAdded += OnAddObject;
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
            blank = Content.Load<Texture2D>("System/blank");
            BackgroundColor = new Color(0, 0, 10);

            // game initialization
            random = new Random();
            mainCamera = new Camera();
            SceneManager.Instance.SetFrameDimension(WINDOW_WIDTH, WINDOW_HEIGHT);
            SetScreenRectangleBounds(WINDOW_WIDTH, WINDOW_HEIGHT);
            SetInterval(PrintTickSpeed, 3, 3);
            lightTarget = new RenderTarget2D(initializer.Graphics, ScreenRectangle.Width, ScreenRectangle.Height);
            mainTarget = new RenderTarget2D(initializer.Graphics, ScreenRectangle.Width, ScreenRectangle.Height);

            // engine initialization
            // collisionEngine = new PhysicsEngine();
            // collisionEngine.Initialize(initializer);
            lightEngine = new LightEngine(0.5f, 1f);
            lightEngine.Initialize(initializer, mainCamera);

            PushUI(new HUD(this));

            GameObject player = CreateTestPlayer();
            player.Position = Vector2.Zero;
            player["Camera"] = mainCamera;
            AddObject(player);

            GameObject hugo = CreateTestSprite();
            hugo.Position = new Vector2(100, 100);
            AddObject(hugo);
            // for (int i = 0; i < 10000; i++)
            // {
            //     GameObject obj = CreateBlankSprite(random.Next(10, 100), random.Next(10, 100));
            //     obj.RelativeTransform.SetPosition(random.Next(0, 10000), random.Next(0, 10000));
            //     AddObject(obj);
            // }

            mainCamera.FixViewOn(player);
        }

        /// <summary>
        /// Unloads the test scene
        /// </summary>
        public override void Unload()
        {
            base.Unload();

            lightEngine.Unload();
            // collisionEngine.Clear();
        }

        private GameObject CreateTestSprite() {
            GameObject obj = new GameObject();
            Sprite sp = new Sprite();
            sp.SetTexturePath("Textures/hugo");
            sp.SetScale(3);
            obj.AddComponent(sp);
            return obj;
        }

        private GameObject CreateBlankSprite(int width, int height)
        {
            GameObject obj = new GameObject();
            Sprite sp = new Sprite();
            sp.SetTexturePath("Textures/hugo");
            sp.SetScale(width / 323f, height / 321f);
            obj.AddComponent(sp);
            // PhysicsBody body = new PhysicsBody
            // {
            //     IsCollidable = true
            // };
            // obj.AddComponent(body);
            // obj.AddComponent(new TestComponent2());
            // BoxCollider collider = new BoxCollider();
            // obj.AddComponent(collider);
            // collider.SetBounds(new Point(width, height));
            // collider.SetOffset(new Point(0, 0));
            obj["type"] = "BlankSprite";
            return obj;
        }
         
        private GameObject CreateTestPlayer()
        {
            GameObject obj = new GameObject();
            Sprite sp = new Sprite();
            sp.SetTexturePath("System/blank");
            sp.SetScale(5, 5);
            obj.AddComponent(sp);
            obj.AddComponent(new TestComponent());
            LightSource source = new LightSource(1, 100f);
            obj.AddComponent(source);
            ParticleEmitter<RainbowParticle> p = new ParticleEmitter<RainbowParticle>();
            // p.Initialize(4f, 10f, "Textures/henry", "Textures/hugo", "Textures/image1");
            p.Initialize(4f, 10f, "System/blank");
            p.MaxScale = 5f;
            p.MinScale = 4f;
            obj.AddComponent(p);
            obj["type"] = "Player";

            return obj;
        }

        private void OnAddObject(GameObject obj) {
            // if (obj.GetComponent<PhysicsBody>() != null) {
            //     collisionEngine.RegisterBody(obj.GetComponent<PhysicsBody>());
            // }
            if (obj.GetComponent<LightSource>() != null) {
                lightEngine.RegisterSource(obj.GetComponent<LightSource>());
            }
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
            // collisionEngine.Update(gameTime);
            SetScreenRectangleLocation((int)mainCamera.TopLeft.X, (int)mainCamera.TopLeft.Y);
            CheckInput();

            if (InputManager.Instance.IsKeyDown(Keys.OemOpenBrackets)) {
                Time.Instance.Timestep -= (float)(1f * Time.Instance.RawDeltaTime);
            }
            else if (InputManager.Instance.IsKeyDown(Keys.OemCloseBrackets)) {
                Time.Instance.Timestep += (float)(1f * Time.Instance.RawDeltaTime);
            }
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
            // draw light sources
            GraphicsDevice.SetRenderTarget(lightTarget);
            GraphicsDevice.Clear(Color.Black);

            // draws the light sources in the game
            spriteBatch.Begin(sortMode: SpriteSortMode.Immediate, samplerState: SamplerState.PointClamp,
                blendState: BlendState.Additive, transformMatrix:mainCamera.GetTransformedMatrix());
            lightEngine.Draw();
            lightEngine.DrawLightSources();
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(mainTarget);
            // draw main scene
            GraphicsDevice.Clear(BackgroundColor);
            spriteBatch.Begin(transformMatrix: mainCamera.GetTransformedMatrix());
            spriteBatch.Draw(blank, mainCamera.TopLeft, Color.Black);
            base.Draw();

            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(BackgroundColor);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            lightEngine.Apply(lightTarget);
            spriteBatch.Draw(mainTarget, Vector2.Zero, Color.White);
            spriteBatch.End();

            // draw UI
            spriteBatch.Begin();
            DrawUI();
            Debug.Instance.Draw(spriteBatch);
            spriteBatch.End();
        }
        #endregion
    }
}
