using Microsoft.Xna.Framework;
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
        /// <summary>
        /// The unique ID of this game object.
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }

        /// <summary>
        /// Whether this object currently has behavior.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
        }
        private readonly List<IDrawable> drawnComponents;
        private readonly List<IUpdateable> updatedComponents;
        private readonly List<GameComponent> components;
        private readonly SortedSet<string> tags;
        private readonly List<GameObject> children;
        private bool isActive;
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
            drawnComponents = new List<IDrawable>();
            updatedComponents = new List<IUpdateable>();
            components = new List<GameComponent>();
            children = new List<GameObject>();
        }
        ~GameObject()
        {
            foreach (GameObject o in children)
            {
                o.parent = null;
            }
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
        public virtual void Update(GameTime gameTime)
        {
            foreach (IUpdateable comp in updatedComponents)
            {
                comp.Update(gameTime);
            }
        }
         
        public virtual void Draw(GameTime gameTime)
        {
            foreach(IDrawable comp in drawnComponents)
            {
                comp.Draw(gameTime);
            }
        }

        /// <summary>
        /// Adds a component to the list of components
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(GameComponent component)
        {
            components.Add(component);

            if (component is IUpdateable updateable)
            {
                updatedComponents.Add(updateable);
            }

            if (component is IDrawable drawable)
            {
                drawnComponents.Add(drawable);
            }
        }

        public T GetComponent<T>()
        {
            return (T)(object)components.Find(x => x is T);
        }

        /// <summary>
        /// Gets the relative transform.
        /// </summary>
        /// <returns></returns>
        public Transform GetRelativeTransform()
        {
            return relativeTransform;
        }

        /// <summary>
        /// Gets the relative to world transform of the game object.
        /// </summary>
        /// <returns></returns>
        public Transform GetTransform()
        {
            Transform tr = new Transform
            {
                Position = relativeTransform.Position * parent.relativeTransform.Scale + relativeTransform.Position,
                Scale = relativeTransform.Scale * parent.relativeTransform.Scale,
                Rotation = relativeTransform.Rotation + parent.relativeTransform.Rotation
            };
            return tr;
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
