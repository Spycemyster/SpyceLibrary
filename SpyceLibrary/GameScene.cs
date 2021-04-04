using Microsoft.Xna.Framework;
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
        private Dictionary<Guid, GameObject> objects;

        /// <summary>
        /// All game objects are parented to this.
        /// </summary>
        private GameObject sceneObject;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game scene.
        /// </summary>
        public GameScene()
        {
            sceneObject = new GameObject(null);
        }
        ~GameScene()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds an object to the game scene.
        /// </summary>
        /// <param name="obj"></param>
        public void AddObject(GameObject obj)
        {
            do
            {
                obj.GenerateNewID();
            } while (objects.ContainsKey(obj.ID));

            objects.Add(obj.ID, obj);
        }

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
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject obj in objects.Values)
            {
                if (obj.IsActive)
                {
                    obj.Update(gameTime);
                }
            }
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
