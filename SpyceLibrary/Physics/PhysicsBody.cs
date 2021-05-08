using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    /// <summary>
    /// A member of the physics engine. This represents a physical object within the game world
    /// that has physics-based behaviors and interactions with other physical objects.
    /// </summary>
    [Serializable]
    public class PhysicsBody : GameComponent
    {
        #region Fields
        /// <summary>
        /// Position of the physics body.
        /// </summary>
        public Vector2 Position
        {
            get { return Holder.GetTransform().Position; }
            set { Holder.RelativeTransform.SetPosition(value); }
        }

        /// <summary>
        /// The velocity of the body for this tick.
        /// </summary>
        public Vector2 Velocity
        {
            get;
            set;
        }

        /// <summary>
        /// Whether this object should be collided with in the collision detection.
        /// </summary>
        public bool IsCollidable
        {
            get;
            set;
        }
        
        /// <summary>
        /// The rectangular collision rectangle of the physics body. TODO: Change to a more
        /// generic collider type.
        /// </summary>
        public BoxCollider Collider
        {
            get { return collider; }
        }

        /// <summary>
        /// The physics engine of the body.
        /// </summary>
        protected PhysicsEngine Engine
        {
            get { return engine; }
        }
        private PhysicsEngine engine;

        private BoxCollider collider;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the physics body.
        /// </summary>
        public PhysicsBody()
        {
            IsCollidable = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the physics body.
        /// </summary>
        /// <param name="init"></param>
        /// <param name="holder"></param>
        public override void Load(Initializer init, GameObject holder)
        {
            base.Load(init, holder);
            collider = RequireComponent<BoxCollider>();
        }

        /// <summary>
        /// Registers the engine with this body.
        /// </summary>
        /// <param name="engine"></param>
        public void Register(PhysicsEngine engine)
        {
            this.engine = engine;
        }

        /// <summary>
        /// Gets all the physics bodies within a set distance.
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public List<PhysicsBody> GetBodiesWithin(float distance)
        {
            return engine.GetBodiesWithin(Holder.GetTransform().Position, distance);
        }
        #endregion
    }
}
