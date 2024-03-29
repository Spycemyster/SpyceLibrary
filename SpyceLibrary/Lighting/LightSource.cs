﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpyceLibrary.Lighting
{
    /// <summary>
    /// Represents a source of light.
    /// </summary>
    public class LightSource : GameComponent
    {
        /// <summary>
        /// The intensity of the light source (1 is max, 0 is completely dark)
        /// </summary>
        /// <value></value>
        public float Intensity
        {
            get { return intensity; }
            set { intensity = value; }
        }

        /// <summary>
        /// The radius of the light source's reach.
        /// </summary>
        /// <value></value>
        public float Radius
        {
            get { return radius; }
        }

        /// <summary>
        /// The center of the light source.
        /// </summary>
        /// <value></value>
        public Vector2 Position
        {
            get { return Holder.Position + offset; }
        }

        /// <summary>
        /// The color of the emitted light.
        /// </summary>
        /// <value></value>
        public Color LightColor
        {
            get;
            set;
        }
        private float intensity, radius;
        private Vector2 offset;
        #region Constructor
        /// <summary>
        /// Creates a new instance of a light source.
        /// </summary>
        /// <param name="intensity"></param>
        /// <param name="radius"></param>
        public LightSource(float intensity, float radius)
        {
            this.intensity = intensity;
            this.radius = radius;
            this.offset = Vector2.Zero;
            
            LightColor = Color.White;
        }

        /// <summary>
        /// Sets the offset of the light source relative to the holder's position.
        /// </summary>
        /// <param name="offset"></param>
        public void SetOffset(Vector2 offset)
        {
            this.offset = offset;
        }
        #endregion
    }
}
