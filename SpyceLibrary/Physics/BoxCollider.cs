using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    /// <summary>
    /// Represents a rectangular hitbox.
    /// </summary>
    public class BoxCollider : GameComponent
    {
        #region Fields
        /// <summary>
        /// The size of the collider.
        /// </summary>
        public Point Size
        {
            get;
            set;
        }

        /// <summary>
        /// The offset of the collider.
        /// </summary>
        public Point Offset
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the collider.
        /// </summary>
        public BoxCollider()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Constructs a rectangle at the given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Rectangle ConstructRectangleAt(Vector2 position)
        {
            return new Rectangle(position.ToPoint() + Offset, Size);
        }

        /// <summary>
        /// Sets the offset of the collision rectangle.
        /// </summary>
        /// <param name="offset"></param>
        public void SetOffset(Point offset)
        {
            Offset = offset;
        }

        /// <summary>
        /// Sets the size of the collision rectangle.
        /// </summary>
        /// <param name="size"></param>
        public void SetBounds(Point size)
        {
            Size = size;
        }
        #endregion
    }
}
