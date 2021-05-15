using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpyceLibrary.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    /// <summary>
    /// A test dummy object.
    /// </summary>
    public class TestDummy : GameObject
    {
        public override void Load(Initializer init)
        {
            BoxCollider collider = new BoxCollider();
            collider.SetSize(100, 100);
            AddComponent(collider);

            Sprite sprite = new Sprite();
            sprite.SetSize(100, 100);
            sprite.SetTexturePath("System/blank");
            AddComponent(sprite);

            base.Load(init);
        }
    }

    /// <summary>
    /// A test object that tests various components.
    /// </summary>
    public class TestPlayer : GameObject
    {
        private Point size;
        private Texture2D texture;
        private BoxCollider collider;
        private Sprite sprite;

        /// <summary>
        /// Creates a new instance of a test player.
        /// </summary>
        public TestPlayer(int width, int height)
        {
            size = new Point(width, height);
        }

        /// <summary>
        /// Initializes the test player.
        /// </summary>
        /// <param name="init"></param>
        public override void Load(Initializer init)
        {
            sprite = new Sprite();
            sprite.SetTexturePath("Textures/hugo");
            sprite.SetSize(size.X, size.Y);
            AddComponent(sprite);

            collider = new BoxCollider();
            collider.SetSize(size.X, size.Y);
            collider.SetOffset(new Vector2(0, 0));
            AddComponent(collider);

            ParticleEmitter<RainbowParticle> particleEmitter = new ParticleEmitter<RainbowParticle>();
            particleEmitter.Initialize(1f, 100f, "System/blank");
            particleEmitter.MinScale = 1;
            particleEmitter.MaxScale = 2;
            AddComponent(particleEmitter);
            
            AddComponent(new TestComponent());

            base.Load(init);
            texture = content.Load<Texture2D>("System/blank");
        }

        /// <summary>
        /// Draws the test object to the screen.
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            Rectangle cRect = collider.GetCollisionRectangle(Position);
            spriteBatch.Draw(texture, cRect, Color.Blue * 0.3f);
        }
    }

    /// <summary>
    /// A component for testing means.
    /// </summary>
    public class TestComponent : GameComponent, IUpdated, IInput
    {
        #region Fields
        private Collider collider;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the test component.
        /// </summary>
        public TestComponent()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads the test component.
        /// </summary>
        /// <param name="init"></param>
        /// <param name="holder"></param>
        public override void Load(Initializer init, GameObject holder)
        {
            base.Load(init, holder);

            collider = RequireComponent<Collider>();
        }

        /// <summary>
        /// Check for user input.
        /// </summary>
        /// <param name="input"></param>
        public void ProcessInput(InputManager input)
        {
            float speed = 200; //* Time.Instance.DeltaTime;
            Vector2 velocity = Vector2.Zero;
            if (InputManager.Instance.IsKeyDown(Keys.W))
            {
                velocity += new Vector2(0, -1);
            }
            else if (InputManager.Instance.IsKeyDown(Keys.S))
            {
                velocity += new Vector2(0, 1);
            }
            if (InputManager.Instance.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);
            }
            else if (InputManager.Instance.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);
            }
            if (velocity.Length() > 0)
            {
                velocity.Normalize();
                velocity *= speed * Time.Instance.DeltaTime;
            }

            if (InputManager.Instance.IsKeyDown(Keys.Up))
            {
                Camera cam = (Camera)Holder["Camera"];
                cam.Zoom -= 0.01f;
            }
            else if (InputManager.Instance.IsKeyDown(Keys.Down))
            {
                Camera cam = (Camera)Holder["Camera"];
                cam.Zoom += 0.01f;
            }

            // move and slide
            Vector2 velocityX = new Vector2(velocity.X, 0);
            Vector2 velocityY = new Vector2(0, velocity.Y);
            if (collider.GetCollidingWith(Holder.Position + velocityX).Count == 0)
            {
                Holder.Position += velocityX;
            }
            if (collider.GetCollidingWith(Holder.Position + velocityY).Count == 0)
            {
                Holder.Position += velocityY;
            }
        }

        /// <summary>
        /// Updates the state of the player controller.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
        }
        #endregion
    }

    /// <summary>
    /// A test component (2).
    /// </summary>
    public class TestComponent2 : GameComponent, IUpdated
    {
        #region Fields
        private float timer;
        private Random rand;
        private float x, y;
        #endregion

        #region Constructor
        /// <summary>
        /// Loads the assets of the test component.
        /// </summary>
        /// <param name="init"></param>
        /// <param name="holder"></param>
        public override void Load(Initializer init, GameObject holder)
        {
            base.Load(init, holder);
            rand = new Random();
            x = (float)(rand.NextDouble() * 100) + 1;
            y = (float)(rand.NextDouble() * 100) + 1;
        }

        /// <summary>
        /// Updates the state of the game.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            timer += Time.Instance.DeltaTime;

            Vector2 velocity = new Vector2((float)Math.Cos(timer * 2) * x, (float)Math.Sin(timer * 2) * y);
            //body.Velocity += velocity * 10;
        }
        #endregion
    }
}
