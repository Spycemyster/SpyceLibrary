using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// Represents an abstract game object within the game.
    /// </summary>
    public class GameObject
    {
        #region Events
        public delegate void GameObjectEvent();

        /// <summary>
        /// When the object is enabled.
        /// </summary>
        public event GameObjectEvent OnEnable;

        /// <summary>
        /// When the object is disabled.
        /// </summary>
        public event GameObjectEvent OnDisable;

        /// <summary>
        /// When the object is being destroyed.
        /// </summary>
        public event GameObjectEvent OnDestroy;
        #endregion

        #region Fields
        public Guid ID
        {
            get { return id; }
        }
        private List<GameComponent> drawnComponents;
        private List<GameComponent> updatedComponents;
        private List<GameComponent> components;
        private SortedSet<string> tags;
        private bool isActive;
        private List<GameObject> children;
        private GameObject parent;
        private Transform relativeTransform;
        private Initializer initializer;
        private Guid id;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a game object.
        /// </summary>
        /// <param name="parent"></param>
        public GameObject(GameObject parent)
        {
            this.parent = parent;
            tags = new SortedSet<string>();
            drawnComponents = new List<GameComponent>();
            updatedComponents = new List<GameComponent>();
            components = new List<GameComponent>();
            children = new List<GameObject>();
        }
        ~GameObject()
        {
            OnDestroy?.Invoke();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Generates a new unique id for this object.
        /// </summary>
        public void GenerateNewID()
        {
            id = Guid.NewGuid();
        }

        /// <summary>
        /// Clones this game object and returns it.
        /// </summary>
        /// <returns></returns>
        public GameObject Clone()
        {
            return new GameObject(parent);
        }

        /// <summary>
        /// Initializes the game object and loads all necessary assets.
        /// </summary>
        /// <param name="init"></param>
        public void Load(Initializer init)
        {
            initializer = init;
        }

        /// <summary>
        /// Updates the state of the game object, components, and children.
        /// </summary>
        /// <param name="dt"></param>
        public virtual void Update(float dt)
        {

        }

        /// <summary>
        /// Adds a component to the list of components
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(GameComponent component)
        {
            components.Add(component);
        }

        /// <summary>
        /// Gets the transform of the game object.
        /// </summary>
        /// <returns></returns>
        public Transform GetTransform()
        {
            return relativeTransform;
        }

        /// <summary>
        /// Sets the current object's activeness.
        /// </summary>
        /// <param name="active"></param>
        public void SetActive(bool active)
        {
            if (active == isActive) return;

            isActive = active;

            if (isActive)
            {
                OnEnable?.Invoke();
            }
            else
            {
                OnDisable?.Invoke();
            }
        }

        /// <summary>
        /// Searches the list of tags for the specified tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool HasTag(string tag)
        {
            return tags.Contains(tag);
        }

        /// <summary>
        /// Adds a list of tags to the set of tags.
        /// </summary>
        /// <param name="addTags"></param>
        public void AddTags(params string[] addTags)
        {
            foreach (string tag in addTags)
            {
                tags.Add(tag);
            }
        }

        /// <summary>
        /// Serializes the object and saves it as a json file
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        public static void SaveObject(GameObject obj, string path)
        {
            string file = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, file);
        }

        /// <summary>
        /// Initializes a 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toClone"></param>
        /// <returns></returns>
        public static GameObject Initialize(GameObject toClone)
        {
            if (toClone == null)
            {
                return default;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
            GameObject cloned = JsonConvert.DeserializeObject<GameObject>(JsonConvert.SerializeObject(toClone), settings);
            cloned.Load(toClone.initializer);
            return cloned;
        }
        #endregion
    }
}
