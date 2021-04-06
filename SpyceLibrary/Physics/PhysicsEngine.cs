using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    public class PhysicsEngine : IUpdated
    {
        #region Fields
        private Dictionary<GameObject, PhysicsBody> bodies;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the physics engine.
        /// </summary>
        public PhysicsEngine()
        {
            bodies = new Dictionary<GameObject, PhysicsBody>();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Registers the body to the engine.
        /// </summary>
        /// <param name="body"></param>
        public void RegisterBody(PhysicsBody body)
        {
            if (body == null)
                return;
            bodies.Add(body.Holder, body);
            body.OnDestroy += onBodyRemoved;
        }

        private void onBodyRemoved(GameComponent component)
        {
            bodies.Remove(component.Holder);
        }

        /// <summary>
        /// Updates the state of each physics engine.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            foreach (PhysicsBody body in bodies.Values)
            {
                if (body.Velocity != Vector2.Zero)
                {
                    body.Position += body.Velocity * Time.Instance.DeltaTime;
                    body.Velocity = Vector2.Zero;
                }

                // todo: add collision detection
            }
        }
        #endregion
    }
}
