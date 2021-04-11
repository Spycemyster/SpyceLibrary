using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    public class TestComponent : GameComponent, IUpdated
    {
        #region Fields
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
        public override void Load(Initializer init, GameObject holder)
        {
            base.Load(init, holder);
        }

        /// <summary>
        /// Updates the state of the player controller.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            float speed = 1000 * Time.Instance.DeltaTime;
            Vector2 velocity = Vector2.Zero;
            if (InputManager.Instance.IsKeyDown(Keys.W))
            {
                velocity = new Vector2(0, -speed);
            }
            else if (InputManager.Instance.IsKeyDown(Keys.S))
            {
                velocity = new Vector2(0, speed);
            }
            if (InputManager.Instance.IsKeyDown(Keys.A))
            {
                velocity = new Vector2(-speed, 0);
            }
            else if (InputManager.Instance.IsKeyDown(Keys.D))
            {
                velocity = new Vector2(speed, 0);
            }
            Holder.RelativeTransform.Position += velocity;
        }
        #endregion
    }
}
