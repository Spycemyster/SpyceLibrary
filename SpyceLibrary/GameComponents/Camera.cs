using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.GameComponents
{
    /// <summary>
    /// Holds relevant information for preforming linear transformation on 
    /// game viewports.
    /// </summary>
    public class Camera : GameComponent
    {
        private float x;
        private float y;

        /// <summary>
        /// Creates a new instance of the Camera.
        /// </summary>
        public Camera()
        {
            x = y = 0;
        }

        /// <summary>
        /// Set the position of the camera.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Set the position of the camera.
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position)
        {
            SetPosition(position.X, position.Y);
        }

        /// <summary>
        /// Return the value of the x-coordinate.
        /// </summary>
        /// <returns></returns>
        public float GetX()
        {
            return x;
        }

        /// <summary>
        /// Return the value of the y-coordinate
        /// </summary>
        /// <returns></returns>
        public float GetY()
        {
            return y;
        }

        /// <summary>
        /// Calculates the transform based on the camera's position.
        /// </summary>
        /// <returns></returns>
        public Matrix GetTransform()
        {
            return Matrix.CreateTranslation((int)-x, (int)-y, 0);
        }
    }
}
