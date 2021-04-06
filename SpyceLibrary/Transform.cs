using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    public class Transform
    {
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
        public Vector2 Position;
        public Vector2 Scale;
        public float Rotation;

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
    }
}
