using System;
using Microsoft.Xna.Framework;
using SpyceLibrary.Debugging;
using SpyceLibrary.Lighting;

namespace SpyceLibrary.Sprites 
{
    /// <summary>
    /// A component that emits various randomly seeded particles.
    /// </summary>
    public class ParticleEmitter<T> : GameComponent, IUpdated where T : Particle
    {
        #region Fields
        /// <summary>
        /// The number of particles to spawn per second.
        /// </summary>
        /// <value></value>
        public float SpawnRate 
        {
            get {return spawnRate;}
        }

        /// <summary>
        /// The maximum scale for the particles emitted.
        /// </summary>
        /// <value></value>
        public float MaxScale 
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum scale for the particles emitted.
        /// </summary>
        /// <value></value>
        public float MinScale 
        {
            get;
            set;
        }
        private Random random;
        private float timer, timeToLive, spawnRate;
        private string[] paths;
        private bool isLoaded, isEmitting;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a particle emitter.
        /// </summary>
        public ParticleEmitter() {
            isLoaded = false;
            isEmitting = true;
            MinScale = 1f;
            MaxScale = 1f;
            random = new Random();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the particle emitter.
        /// </summary>
        /// <param name="timeToLive"></param>
        /// <param name="particleRate"></param>
        /// <param name="paths"></param>
        public void Initialize(float timeToLive, float particleRate, params string[] paths)
        {
            this.paths = paths;
            this.timeToLive = timeToLive;
            spawnRate = particleRate;
            isLoaded = true;
        }

        /// <summary>
        /// Continues emitting particles.
        /// </summary>
        public void ContinueEmitting() {
            isEmitting = true;
        }

        /// <summary>
        /// Stops emitting particles.
        /// </summary>
        public void StopEmitting() {
            isEmitting = false;
        }

        /// <summary>
        /// Updates the particle emitter.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (!isEmitting) {
                return;
            }
            Debug.Instance.AssertStrict(isLoaded, "Particle Emitter not initialized...");
            timer += Time.Instance.DeltaTime;

            int numParticles = (int)Math.Round(SpawnRate * timer);
            if (numParticles > 0)
            {
                for (int i = 0; i < numParticles; i++)
                {
                    float scale = (float)(random.NextDouble() * (MaxScale - MinScale) + MinScale);
                    Particle p = (Particle)Activator.CreateInstance( typeof(T) , timeToLive);
                    p.Position = Holder.Position;
                    p.Scale = new Vector2(scale, scale);
                    p.SetTexturePath(paths);
                    CurrentScene.AddObject(p);
                }
                timer = 0;
            }
        }
        #endregion
    }

    /// <summary>
    /// Represents a singular particle within a particle engine.
    /// </summary>
    public class Particle : GameObject
    {
        /// <summary>
        /// The time left the particle has before it is removed.
        /// </summary>
        public float TTL;

        /// <summary>
        /// The sprite drawn for the particle.
        /// </summary>
        /// <value></value>
        protected Sprite Sprite
        {
            get
            {
                return sprite;
            }
        }
        
        /// <summary>
        /// The total time the particle has before being removed.
        /// </summary>
        /// <value></value>
        protected float TimeToLive 
        {
            get {return TIME_TO_LIVE;}
        }
        /// <summary>
        /// The color of the particle.
        /// </summary>
        protected Color Color;

        /// <summary>
        /// The color of the light emitted from this particle.
        /// </summary>
        protected Color LightColor
        {
            get { return lightSource.LightColor; }
            set { lightSource.LightColor = value; }
        }
        private Sprite sprite;
        private LightSource lightSource;
        private string[] texturePaths;
        private Vector2 velocity;
        private Random random;
        private readonly float TIME_TO_LIVE;
        private readonly float INITIAL_LIGHT_INTENSITY;

        /// <summary>
        /// Creates a new instance of the particle.
        /// </summary>
        public Particle(float timeToLive)
        {
            TIME_TO_LIVE = timeToLive;
            TTL = timeToLive;
            random = new Random();
            double direction = random.NextDouble() * 2 * Math.PI;
            velocity = new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction)) * 500f;
            INITIAL_LIGHT_INTENSITY = 0.8f;
            lightSource = new LightSource(INITIAL_LIGHT_INTENSITY, 150f);
            LightColor = Color.White;
        }

        /// <summary>
        /// Sets the texture paths for the particle.
        /// </summary>
        /// <param name="paths"></param>
        public void SetTexturePath(params string[] paths)
        {
            texturePaths = paths;
        }

        /// <summary>
        /// Loads the particle.
        /// </summary>
        /// <param name="init"></param>
        public override void Load(Initializer init)
        {
            sprite = new Sprite();
            sprite.TexturePath = texturePaths[random.Next(texturePaths.Length)];
            sprite.SetScale(Scale);
            AddComponent(sprite);

            AddComponent(lightSource);
            base.Load(init);
        }

        /// <summary>
        /// Updates the behavior of the particle.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Position += GetVelocity() * Time.Instance.DeltaTime;
            TTL -= Time.Instance.DeltaTime;
            
            // updates the transparency of the particle
            float percent = (TTL / TIME_TO_LIVE);
            Color tColor = new Color(Color.R, Color.G, Color.B) * percent;
            Sprite.Color = tColor;
            //lightSource.Intensity = INITIAL_LIGHT_INTENSITY * percent;

            if (TTL <= 0) {
                Destroy();
            }
        }

        /// <summary>
        /// Gets the velocity of the particle.
        /// </summary>
        /// <returns></returns>
        public virtual Vector2 GetVelocity() {
            return velocity;
        }
    }

    /// <summary>
    /// Randomly colored particles.
    /// </summary>
    public class RainbowParticle : Particle
    {
        private Random random;
        private float timeToLive;
        /// <summary> 
        /// Creates a new instance of the rainbow particle.
        /// </summary>
        /// <param name="timeToLive"></param>
        /// <returns></returns>
        public RainbowParticle(float timeToLive) : base(timeToLive) {
            random = new Random();
            this.timeToLive = timeToLive;
            Color = new Color(random.Next(255), random.Next(255), random.Next(255));
            LightColor = Color;
        }
    }
}