using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpyceLibrary.GameComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// The Light Engine handles all the different sources of light. It calculates
    /// and renders lighting effects on the viewport and draws it to the screen.
    /// </summary>
    public class LightEngine
    {
        /// <summary>
        /// The maximum brightness the world can be displayed in.
        /// Value ranges [0, 1]
        /// </summary>
        public readonly float MAX_BRIGHTNESS;

        /// <summary>
        /// The minimum brightness the world can be displayed in. Must be
        /// smaller than MAX_BRIGHTNESS, and the value ranges from [0, 1]
        /// </summary>
        public float MIN_BRIGHTNESS;

        /// <summary>
        /// The number of real-life seconds in each day.
        /// </summary>
        public uint DAY_TIME_SECONDS;

        /// <summary>
        /// The resolution of the generated lightmask
        /// </summary>
        public int LIGHT_RESOLUTION;

        private float worldTime;
        private Texture2D lightMask;
        private Texture2D blank;

        /// <summary>
        /// Creates a new instance of the light engine.
        /// </summary>
        public LightEngine(float maxBrightness, float minBrightness, uint dayTimeSeconds = 86400, int lightResolution = 1000)
        {
            MAX_BRIGHTNESS = maxBrightness;
            MIN_BRIGHTNESS = minBrightness;
            DAY_TIME_SECONDS = dayTimeSeconds;
            LIGHT_RESOLUTION = lightResolution;
            worldTime = 0;
        }

        /// <summary>
        /// Generates light mask and loads other effects.
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="graphics"></param>
        public void Load(ContentManager Content, GraphicsDevice graphics)
        {
            lightMask = GenerateLightMask(graphics, LIGHT_RESOLUTION);
            blank = GenerateBlank(graphics, LIGHT_RESOLUTION);
        }

        #region Resource Generation
        /// <summary>
        /// Generates a blank white texture of a given square size.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="resolution"></param>
        /// <returns></returns>
        private Texture2D GenerateBlank(GraphicsDevice graphics, int resolution)
        {
            Texture2D texture = new Texture2D(graphics, resolution, resolution);
            int pixelCount = resolution * resolution;
            Color[] data = new Color[pixelCount];
            for (int i = 0; i < pixelCount; i++)
            {
                data[i] = Color.White;
            }
            texture.SetData(data);
            return texture;
        }

        /// <summary>
        /// Generates a circular gradient texture that can be used as a light mask.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="resolution"></param>
        /// <returns></returns>
        private Texture2D GenerateLightMask(GraphicsDevice graphics, int resolution)
        {
            Texture2D texture = new Texture2D(graphics, resolution, resolution);
            Color[] data = new Color[resolution * resolution];

            for (int y = 0; y < resolution; y++)
            {
                for (int x = 0; x < resolution; x++)
                {
                    // use distance formula to calculate distance from origin
                    float r = (float)Math.Sqrt(Math.Pow(x - resolution / 2, 2) + Math.Pow(y - resolution / 2, 2));

                    // base the opacity on the distance from the center using the following equation
                    // q = resolution, r = radius
                    // opacity = (2 * (q / 2 - r) / resolution) ^ 2
                    float opacity = (float)Math.Pow((resolution / 2 - r) / resolution / 2, 2);

                    // set it to the current index
                    data[y * resolution + x] = Color.White * opacity;
                }
            }

            texture.SetData(data);
            return texture;
        }
        #endregion

        /// <summary>
        /// Unallocates the resources generated in the light engine.
        /// </summary>
        public void Dispose()
        {
            lightMask.Dispose();
            blank.Dispose();
        }

        public void AddSource(LightSource source)
        {

        }

        public void DeleteSource(LightSource source)
        {

        }
    }
}
