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
    public class Scene
    {
        #region Fields
        private Dictionary<Guid, GameObject> objects;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game scene.
        /// </summary>
        public Scene()
        {
            objects = new Dictionary<Guid, GameObject>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs any cleanup operations not done in regular garbage collection.
        /// </summary>
        public virtual void Unload()
        {
            foreach (GameObject obj in objects.Values)
            {
                obj.Destroy();
            }
        }

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
            obj.OnDestroy += OnObjectDestruction;
        }

        /// <summary>
        /// When an object is destroyed, it is removed from the scene.
        /// </summary>
        /// <param name="obj"></param>
        private void OnObjectDestruction(GameObject obj)
        {
            obj.OnDestroy -= OnObjectDestruction;
            RemoveObject(obj.ID);
        }

        /// <summary>
        /// Removes an object from the game scene.
        /// </summary>
        /// <param name="id"></param>
        public bool RemoveObject(Guid id)
        {
            return objects.Remove(id);
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
