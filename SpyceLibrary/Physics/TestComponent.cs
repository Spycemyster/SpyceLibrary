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
        private PhysicsBody body;
        #endregion

        #region Constructor
        public TestComponent()
        {
        }
        #endregion

        #region Methods
        public override void Load(Initializer init, GameObject holder)
        {
            base.Load(init, holder);
            body = holder.GetComponent<PhysicsBody>();
        }

        /// <summary>
        /// Updates the state of the player controller.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            float speed = 1000;
            if (InputManager.Instance.IsKeyDown(Keys.W))
            {
                body.Velocity += new Vector2(0, -speed);
            }
            else if (InputManager.Instance.IsKeyDown(Keys.S))
            {
                body.Velocity += new Vector2(0, speed);
            }
            if (InputManager.Instance.IsKeyDown(Keys.A))
            {
                body.Velocity += new Vector2(-speed, 0);
            }
            else if (InputManager.Instance.IsKeyDown(Keys.D))
            {
                body.Velocity += new Vector2(speed, 0);
            }
        }
        #endregion
    }
}
