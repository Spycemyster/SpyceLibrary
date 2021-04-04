﻿using Microsoft.Xna.Framework;
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
        /// The amount of elapsed time from the last update call.
        /// </summary>
        public float DeltaTime
        {
            get { return deltaTime * timestep; }
        }

        /// <summary>
        /// The gametime field from the update cycle.
        /// </summary>
        public GameTime GameTime
        {
            get { return gameTime; }
        }
        private GameTime gameTime;
        private float deltaTime;
        private float timestep;
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
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        #endregion
    }
}