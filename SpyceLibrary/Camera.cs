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
    public class Camera : GameComponent
    {
        #region Fields
        /// <summary>
        /// The position of the camera.
        /// </summary>
        public Vector2 Position
        {
            get { return Holder.GetTransform().Position; }
        }

        private Viewport viewport;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the camera.
        /// </summary>
        public Camera()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads the c
        /// </summary>
        /// <param name="init"></param>
        /// <param name="holder"></param>
        public override void Load(Initializer init, GameObject holder)
        {
            base.Load(init, holder);
            viewport = init.Graphics.Viewport;
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
