using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
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

        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the physics body.
        /// </summary>
        public PhysicsBody()
        {
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
        }
        #endregion
    }
}
