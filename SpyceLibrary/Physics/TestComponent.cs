using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    /// <summary>
    /// A component for testing means.
    /// </summary>
    public class TestComponent : GameComponent, IUpdated, IInput
    {
        #region Fields
        private PhysicsBody body;
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

            body = RequireComponent<PhysicsBody>();
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
                body.Velocity = velocity * speed;
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
        private PhysicsBody body;
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
            body = RequireComponent<PhysicsBody>();
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
