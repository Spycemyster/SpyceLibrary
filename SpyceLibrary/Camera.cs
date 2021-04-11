using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// Handles matrix camera transformations.
    /// </summary>
    public class Camera
    {
        #region Fields
        /// <summary>
        /// The position of the camera.
        /// </summary>
        public Vector2 Position
        {
            get { return (viewedObject != null) ? viewedObject.GetTransform().Position + offset : offset; }
        }

        private Viewport viewport;
        private GameObject viewedObject;
        private Vector2 offset;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the camera.
        /// </summary>
        public Camera()
        {
            offset = Vector2.Zero;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Fixes the view on the object.
        /// </summary>
        /// <param name="obj"></param>
        public void FixViewOn(GameObject obj)
        {
            viewedObject = obj;
        }

        /// <summary>
        /// Sets the offset of the camera.
        /// </summary>
        /// <param name="offset"></param>
        public void SetOffset(Vector2 offset)
        {
            this.offset = offset;
        }

        /// <summary>
        /// Gets the transformed viewport matrix.
        /// </summary>
        /// <returns></returns>
        public Matrix GetTransformedMatrix()
        {
            return Matrix.CreateTranslation(-(int)(Position.X - viewport.Width / 2),
                -(int)(Position.Y - viewport.Height / 2), 0);
        }
        #endregion
    }
}
