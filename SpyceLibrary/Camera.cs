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
        /// Top left corner of the screen.
        /// </summary>
        public Vector2 TopLeft
        {
            get { return Center - SceneManager.Instance.GetWindowSize().ToVector2() / 2; }
        }

        /// <summary>
        /// The position of the camera.
        /// </summary>
        public Vector2 Center
        {
            get 
            {
                return (viewedObject == null) ? Vector2.Zero : viewedObject.GetTransform().Position;
            }
        }

        /// <summary>
        /// Sets the zoom value of the camera.
        /// </summary>
        public float Zoom
        {
            get { return zoom; }
            set { zoom = value; }
        }

        private Viewport viewport;
        private GameObject viewedObject;
        private float zoom;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the camera.
        /// </summary>
        public Camera()
        {
            zoom = 1;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Updates the viewport size to match the screen size.
        /// </summary>
        public void UpdateViewportSize()
        {
            viewport = SceneManager.Instance.GetScreenViewport();
        }

        /// <summary>
        /// Fixes the view on the object.
        /// </summary>
        /// <param name="obj"></param>
        public void FixViewOn(GameObject obj)
        {
            viewedObject = obj;
        }

        /// <summary>
        /// Gets the transformed viewport matrix.
        /// </summary>
        /// <returns></returns>
        public Matrix GetTransformedMatrix()
        {
            UpdateViewportSize();
            return Matrix.CreateTranslation(-(int)(Center.X), -(int)(Center.Y), 0) 
            //return Matrix.CreateTranslation(0, 0, 0)
                * Matrix.CreateScale(new Vector3(zoom, zoom, 0))
                * Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));
        }

        /// <summary>
        /// Maps screen coordinates to the matrix transformation.
        /// </summary>
        /// <param name="screen"></param>
        /// <returns></returns>
        public Vector2 ScreenToWorldCoordinates(Vector2 screen)
        {
            Matrix inverse = Matrix.Invert(GetTransformedMatrix());

            return Vector2.Transform(screen, inverse);
        }
        #endregion
    }
}
