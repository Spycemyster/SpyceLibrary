using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// A scene represents a set of various game objects interacting. Scenes are indepedent of each other and
    /// can be interchangebly loaded using the scene manager.
    /// </summary>
    public class GameScene
    {
        #region Fields
        #endregion

        #region Constructor
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the game scene with the necessary resources.
        /// </summary>
        /// <param name="initializer"></param>
        public void Initialize(Initializer initializer)
        {
            Load(initializer);
        }

        /// <summary>
        /// Performs any cleanup operations that wouldn't be done with a normal destructor.
        /// </summary>
        public virtual void Destroy()
        {

        }

        /// <summary>
        /// Called before the first update is called.
        /// </summary>
        /// <param name="initializer"></param>
        protected virtual void Load(Initializer initializer)
        {

        }

        /// <summary>
        /// Updates all the game objects in this scene.
        /// </summary>
        /// <param name="dt"></param>
        public virtual void Update(float dt)
        {

        }

        /// <summary>
        /// Calls draw on each of the objects in the scene.
        /// </summary>
        public virtual void Draw()
        {

        }
        #endregion
    }
}
