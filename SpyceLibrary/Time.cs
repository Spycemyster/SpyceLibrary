using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// Singleton class for handling time related applications.
    /// </summary>
    public class Time
    {
        #region Singleton
        private static Time inst;

        /// <summary>
        /// Singleton instance of the time.
        /// </summary>
        public static Time Instance
        {
            get 
            { 
                if (inst == null)
                {
                    inst = new Time();
                }
                return inst; 
            }
        }
        #endregion

        #region Fields
        /// <summary>
        /// The targetted minimum framerate of the game.
        /// </summary>
        public const int TARGET_FRAMERATE = 60;

        /// <summary>
        /// The maximum timestep for each update cycle.
        /// </summary>
        public const float MAX_SMOOTH_DELTA = 1f / TARGET_FRAMERATE;

        /// <summary>
        /// The amount of elapsed time from the last update call, but within the bounds of the max smooth delta. This is
        /// to prevent game freezes from messing too much with the physics.
        /// </summary>
        public float DeltaTime
        {
            get { return Math.Min(MAX_SMOOTH_DELTA, TrueDeltaTime); }
        }

        /// <summary>
        /// The amount of elapsed time from the last update call.
        /// </summary>
        /// <value></value>
        public float TrueDeltaTime {
            get { return Math.Min(MAX_SMOOTH_DELTA, (float)(RawDeltaTime * timestep)); }
        }

        /// <summary>
        /// The actual amount of elapsed time from the last update call.
        /// </summary>
        public double RawDeltaTime
        {
            get { return deltaTime; }
        }

        /// <summary>
        /// The gametime field from the update cycle.
        /// </summary>
        public GameTime GameTime
        {
            get { return gameTime; }
        }

        /// <summary>
        /// The time multiplier of the calculated delta time.
        /// </summary>
        public float Timestep
        {
            get { return timestep; }
            set { timestep = value; }
        }
        private GameTime gameTime;
        private float timestep;
        private double deltaTime;
        #endregion

        #region Constructor
        private Time()
        {
            timestep = 1;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Updates the state of the time manager.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            deltaTime = gameTime.ElapsedGameTime.TotalSeconds;
        }
        #endregion
    }
}
