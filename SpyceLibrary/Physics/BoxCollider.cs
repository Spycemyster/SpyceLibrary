using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    public class BoxCollider : GameComponent
    {
        #region Fields
        public Rectangle CollisionRectangle
        {
            get { return rectangle; }
        }
        private Rectangle rectangle;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the collider.
        /// </summary>
        public BoxCollider()
        {
            rectangle = new Rectangle();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the collision rectangle.
        /// </summary>
        /// <param name="rect"></param>
        public void SetCollisionRectangle(Rectangle rect)
        {
            rectangle = rect;
        }
        #endregion
    }
}
