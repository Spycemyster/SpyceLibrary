using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.GameComponents
{
    public class LightSource : GameComponent
    {
        /// <summary>
        /// The x coordinate at which the light source is drawn.
        /// </summary>
        public float X
        {
            get { return holder.Transform.X + offset.X; }
        }

        /// <summary>
        /// The y coordinate at which the light source is drawn.
        /// </summary>
        public float Y
        {
            get { return holder.Transform.Y + offset.Y; }
        }

        /// <summary>
        /// The radius of the light source.
        /// </summary>
        public readonly float RADIUS;

        /// <summary>
        /// The multiplier of the light source.
        /// </summary>
        public readonly float INTENSITY;

        private GameObject holder;
        private Vector2 offset;

        /// <summary>
        /// Creates a new instance of a light source.
        /// </summary>
        public LightSource(float radius, float intensity, float offsetX = 0, float offsetY = 0)
        {
            RADIUS = radius;
            INTENSITY = intensity;
            offset = new Vector2(offsetX, offsetY);
        }
    }
}
