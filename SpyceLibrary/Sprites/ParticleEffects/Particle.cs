using System;
using Microsoft.Xna.Framework;
using SpyceLibrary.Debugging;

namespace SpyceLibrary.Sprites 
{
    /// <summary>
    /// A component that emits various randomly seeded particles.
    /// </summary>
    public class ParticleEmitter<T> : GameComponent, IUpdated
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
        private float timer, timeToLive, spawnRate;
        private string[] paths;
        private bool isLoaded;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a particle emitter.
        /// </summary>
        public ParticleEmitter() {
            isLoaded = false;
            MinScale = 1f;
            MaxScale = 1f;
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
        /// Updates the particle emitter.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            Debug.Instance.AssertStrict(isLoaded, "Particle Emitter not initialized...");
            timer += Time.Instance.DeltaTime;

            int numParticles = (int)Math.Round(SpawnRate * timer);
            if (numParticles > 0) {
                for (int i = 0; i < numParticles; i++) {
                    Particle p = (Particle)Activator.CreateInstance(typeof(T), timeToLive);
                    p.Position = Holder.Position;
                    p.MaxScale = MaxScale;
                    p.MinScale = MinScale;
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
    public class Particle : GameObject {
        public float MaxScale {
            get;
            set;
        }

        public float MinScale {
            get;
            set;
        }
        /// <summary>
        /// The time left the particle has before it is removed.
        /// </summary>
        public float TTL;

        /// <summary>
        /// The sprite drawn for the particle.
        /// </summary>
        /// <value></value>
        protected Sprite Sprite {
            get {return sprite;}
        }
        private Sprite sprite;
        private string[] texturePaths;
        private Vector2 velocity;
        private Random random;

        /// <summary>
        /// Creates a new instance of the particle.
        /// </summary>
        public Particle(float timeToLive)
        {
            TTL = timeToLive;
            random = new Random();
            double direction = random.NextDouble() * 2 * Math.PI;
            velocity = new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction)) * 100f;
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
            sprite.SetScale((float)random.NextDouble() * (MaxScale - MinScale) + MinScale);
            AddComponent(sprite);
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

    public class RainbowParticle : Particle {
        private Random random;
        private Color color;
        private float timeToLive;
        private Vector2 gravity;
        public RainbowParticle(float timeToLive) : base(timeToLive) {
            random = new Random();
            this.timeToLive = timeToLive;
            //color = new Color(random.Next(255), random.Next(255), random.Next(255));
            color = new Color(random.Next(10), random.Next(10), random.Next(200, 255));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            Color tColor = new Color(color.R, color.G, color.B) * (TTL / timeToLive);
            Sprite.Color = tColor;
            gravity += new Vector2(0, 5f) * Time.Instance.DeltaTime;
        }



        public override Vector2 GetVelocity()
        {
            return base.GetVelocity() + gravity;
        }

        public override void Load(Initializer init)
        {
            base.Load(init);
        }
    }

}