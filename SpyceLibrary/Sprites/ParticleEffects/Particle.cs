using System;
using Microsoft.Xna.Framework;

namespace SpyceLibrary.Sprites 
{
    /// <summary>
    /// Handles the functionality for various particle effects in the game.
    /// </summary>
    public class ParticleEngine {

    }

    /// <summary>
    /// A component that emits various randomly seeded particles.
    /// </summary>
    public class ParticleEmitter : GameComponent, IUpdated
    {
        #region Fields
        /// <summary>
        /// The number of particles to spawn per second.
        /// </summary>
        /// <value></value>
        public float SpawnRate 
        {
            get;
            set;
        }
        private float timer;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a particle emitter.
        /// </summary>
        public ParticleEmitter() {
            
        }
        #endregion

        #region Methods
        /// <summary>
        /// Updates the particle emitter.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            timer += Time.Instance.DeltaTime;

            int numParticles = (int)Math.Round(SpawnRate * timer);
            if (numParticles > 0) {
                for (int i = 0; i < numParticles; i++) {
                    
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

    }

}