using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// Represents a size transformation of the game object.
    /// </summary>
    public class Transform
    {
        #region Definitions
        /// <summary>
        /// Gets the identity transform. When this transform is applied, you get the exact same
        /// transform.
        /// </summary>
        public static Transform Identity
        {
            get 
            {
                Transform t = new Transform
                {
                    Position = Vector2.Zero,
                    Scale = Vector2.One,
                    Rotation = 0
                };
                return t;
            }
        }
        #endregion

        #region Fields
        /// <summary>
        /// The position of the transform.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// The size scale of the transform.
        /// </summary>
        public Vector2 Scale;

        /// <summary>
        /// The rotation of the sprite.
        /// </summary>
        public float Rotation;
        #endregion

        #region Methods
        /// <summary>
        /// Sets the scale of the transform.
        /// </summary>
        /// <param name="scale"></param>
        public void SetScale(Vector2 scale)
        {
            Scale = scale;
        }

        /// <summary>
        /// Sets the position of the transform.
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        /// <summary>
        /// Sets the position of the transform.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
        }
        #endregion
    }
}
