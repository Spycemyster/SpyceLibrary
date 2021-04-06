using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    public class BoxCollider : GameComponent
    {
        #region Fields
        /// <summary>
        /// The list of colliders that are associated with this game object.
        /// </summary>
        public List<Rectangle> Colliders
        {
            get { return rectangles; }
        }
        private List<Rectangle> rectangles;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the collider.
        /// </summary>
        public BoxCollider()
        {
            rectangles = new List<Rectangle>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a collision rectangle.
        /// </summary>
        /// <param name="rect"></param>
        public void AddCollisionRectangle(Rectangle rect)
        {
            rectangles.Add(rect);
        }
        #endregion
    }
}
