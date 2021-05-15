using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpyceLibrary.Lighting
{
    /// <summary>
    /// Applies lighting effects of various light sources in the game
    /// world.
    /// </summary>
    public class LightEngine : IDrawn
    {
        /// <summary>
        /// The resolution of the light mask texture.
        /// </summary>
        public const int LIGHTMASK_RESOLUTION = 1000;
        private Camera camera;
        private SpriteBatch spriteBatch;
        private readonly float MIN_BRIGHTNESS, MAX_BRIGHTNESS;
        private Texture2D blank, lightMask;
        private Vector2 lightMaskOrigin;
        private Effect lightEffect;
        private readonly Dictionary<GameObject, LightSource> sources;
        /// <summary>
        /// Creates a new instance of the light engine.
        /// </summary>
        public LightEngine(float minBrightness, float maxBrightness)
        {
            MIN_BRIGHTNESS = minBrightness;
            MAX_BRIGHTNESS = maxBrightness;
            sources = new Dictionary<GameObject, LightSource>();
        }

        /// <summary>
        /// Frees up the generated resources.
        /// </summary>
        public void Unload()
        {
            lightMask.Dispose();
        }

        /// <summary>
        /// Applies the light effect to the scene.
        /// </summary>
        /// <param name="lightTarget"></param>
        public void Apply(in RenderTarget2D lightTarget)
        {
            lightEffect.Parameters["lightMask"].SetValue(lightTarget);
            lightEffect.CurrentTechnique.Passes[0].Apply();
        }

        /// <summary>
        /// Initializes the light engine and its resources.
        /// </summary>
        /// <param name="initializer"></param>
        /// <param name="camera"></param>
        public void Initialize(Initializer initializer, Camera camera)
        {
            spriteBatch = initializer.SpriteBatch;
            this.camera = camera;
            blank = initializer.Content.Load<Texture2D>("System/blank");
            lightMask = GenerateLightMask(initializer.Graphics, LIGHTMASK_RESOLUTION);
            lightMaskOrigin = new Vector2(lightMask.Width / 2f, lightMask.Height / 2f);
            lightEffect = initializer.Content.Load<Effect>("System/DayNightEffect");
        }

        /// <summary>
        /// Generates a light mask based on the given parameters.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="resolution"></param>
        /// <returns></returns>
        private Texture2D GenerateLightMask(in GraphicsDevice graphics, int resolution)
        {
            Texture2D texture = new Texture2D(graphics, resolution, resolution);
            Color[] maskData = new Color[resolution * resolution];

            for (int y = 0; y < resolution; y++)
            {
                for (int x = 0; x < resolution; x++)
                {
                    int px = x - resolution / 2;
                    int py = y - resolution / 2;
                    int index = y * resolution + x;
                    float r = (float)Math.Sqrt(px * px + py * py);
                    float opacity = (r <= resolution / 2) ? (float)Math.Pow((resolution / 2 - r) / resolution * 2, 2) : 0f;
                    maskData[index] = new Color(opacity, opacity, opacity);
                }
            }
            texture.SetData(maskData);
            
            return texture;
        }

        /// <summary>
        /// Registers the source with the engine.
        /// </summary>
        /// <param name="source"></param>
        public void RegisterSource(in LightSource source)
        {
            sources.Add(source.Holder, source);
            source.Holder.OnDestroy += UnregisterSource;
        }

        /// <summary>
        /// Unregisters the source attached to the body.
        /// </summary>
        /// <param name="obj"></param>
        public void UnregisterSource(in GameObject obj)
        {
            sources.Remove(obj);
        }

        /// <summary>
        /// Draws the black background
        /// </summary>
        public void Draw()
        {
            float brightness = MIN_BRIGHTNESS;
            Rectangle drawRect = GetDrawRectangle();
            spriteBatch.Draw(blank, drawRect, Color.White * brightness);
        }

        /// <summary>
        /// Draws each light source of the engine.
        /// </summary>
        public void DrawLightSources()
        {
            foreach (LightSource source in sources.Values)
            {
                Rectangle lightRect = new Rectangle((int)(source.Position.X),
                    (int)(source.Position.Y), (int)(2 * source.Radius), (int)(2 * source.Radius));
                spriteBatch.Draw(lightMask, lightRect, null, source.LightColor * source.Intensity, 0f,
                    lightMaskOrigin, SpriteEffects.None, DrawOrder() / IDrawn.MAX_DRAW_ORDER);
            }
        }

        /// <summary>
        /// The draw order of the light engine.
        /// </summary>
        /// <returns></returns>
        public uint DrawOrder()
        {
            return 0;
        }

        /// <summary>
        /// Gets the screen rectangle at the 
        /// </summary>
        /// <returns></returns>
        public Rectangle GetDrawRectangle()
        {
            return new Rectangle(camera.TopLeft.ToPoint(), SceneManager.Instance.GetWindowSize());
        }
    }
}
