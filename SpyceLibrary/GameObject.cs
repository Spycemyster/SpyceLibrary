using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        /// <summary>
        /// Delegate handler for game object events.
        /// </summary>
        /// <param name="obj"></param>
        public delegate void GameObjectEvent(GameObject obj);

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

        /// <summary>
        /// The components attached to this game object.
        /// </summary>
        public List<GameComponent> Components
        {
            get { return components; }
        }

        /// <summary>
        /// All game objects are childed to this game object.
        /// </summary>
        public List<GameObject> Children
        {
            get { return children; }
        }

        /// <summary>
        /// The relative transformation (before applying parent transformations).
        /// </summary>
        public Transform RelativeTransform
        {
            get { return relativeTransform; }
        }
        private readonly List<IDrawn> drawnComponents;
        private readonly List<IUpdated> updatedComponents;
        private readonly List<IInput> inputComponents;
        private readonly List<GameComponent> components;
        private readonly Dictionary<string, object> properties;
        private readonly SortedSet<string> tags;
        private readonly List<GameObject> children;
        private bool isActive;
        private GameObject parent;
        private Initializer initializer;
        private Transform relativeTransform;
        private Guid id;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a game object.
        /// </summary>
        public GameObject()
        {
            tags = new SortedSet<string>();
            drawnComponents = new List<IDrawn>();
            updatedComponents = new List<IUpdated>();
            inputComponents = new List<IInput>();
            components = new List<GameComponent>();
            children = new List<GameObject>();
            properties = new Dictionary<string, object>();
            relativeTransform = Transform.Identity;
            isActive = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Frees up the memory in the game object and its components.
        /// </summary>
        public void Destroy()
        {
            foreach (GameObject o in children)
            {
                o.parent = null;
            }

            foreach (GameComponent c in components)
            {
                c.Unload();
            }

            OnDestroy?.Invoke(this);
        }

        /// <summary>
        /// Generates a new unique id for this object.
        /// </summary>
        public void GenerateNewID()
        {
            id = Guid.NewGuid();
        }

        /// <summary>
        /// Sets the parent of the game object.
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(GameObject parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Initializes the game object and loads all necessary assets.
        /// </summary>
        /// <param name="init"></param>
        public void Load(Initializer init)
        {
            foreach (GameComponent c in components)
            {
                c.Load(init, this);
            }
            initializer = init;
        }

        /// <summary>
        /// Processes the input for the game components.
        /// </summary>
        /// <param name="input"></param>
        public virtual void ProcessInput(InputManager input)
        {
            foreach (IInput i in inputComponents)
            {
                i.ProcessInput(input);
            }
        }

        /// <summary>
        /// Updates the state of the game object, components, and children.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            foreach (IUpdated comp in updatedComponents)
            {
                comp.Update(gameTime);
            }
        }

        /// <summary>
        /// Draws all the drawable components.
        /// </summary>
        public virtual void Draw()
        {
            foreach (IDrawn comp in drawnComponents)
            {
                comp.Draw();
            }
        }

        /// <summary>
        /// Adds a component to the list of components
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(GameComponent component)
        {
            components.Add(component);

            if (component is IUpdated updateable)
            {
                updatedComponents.Add(updateable);
            }

            if (component is IDrawn drawable)
            {
                drawnComponents.Add(drawable);
            }

            if (component is IInput inputable)
            {
                inputComponents.Add(inputable);
            }
        }

        /// <summary>
        /// Gets the component if it is attached to this game object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>()
        {
            return (T)(object)components.Find(x => x is T);
        }

        /// <summary>
        /// Sets the relative transform of the game object.
        /// </summary>
        /// <param name="transform"></param>
        public void SetRelativeTransform(Transform transform)
        {
            relativeTransform = transform;
        }

        /// <summary>
        /// Gets the relative to world transform of the game object.
        /// </summary>
        /// <returns></returns>
        public Transform GetTransform()
        {
            Transform parentTransform = (parent == null) ? Transform.Identity : parent.relativeTransform;
            Transform tr = new Transform
            {
                Position = relativeTransform.Position + parentTransform.Position,
                Scale = relativeTransform.Scale * parentTransform.Scale,
                Rotation = relativeTransform.Rotation + parentTransform.Rotation
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
                OnEnable?.Invoke(this);
            }
            else
            {
                OnDisable?.Invoke(this);
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
        /// Gets a string representation of the game object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string raw = "";
            raw += $"[{id}]\n";
            if (tags.Count > 0)
            {
                raw += $"Tags: {{";
                int count = 0;
                foreach (string s in tags)
                {
                    count++;
                    raw += s;
                    if (count < tags.Count)
                    {
                        raw += $", ";
                    }
                    else
                    {
                        raw += "}\n";
                    }
                }
            }
            raw += $"\tPosition: ({relativeTransform.Position.X}, {relativeTransform.Position.Y}), Rotation: {relativeTransform.Rotation}, Scale: ({relativeTransform.Scale.X}, {relativeTransform.Scale.Y})\n";
            if (parent != null)
            {
                raw += $"\tParent: {parent.id}\n";
            }
            for (int i = 0; i < components.Count; i++)
            {
                raw += $"\t{components[i]}\n";
            }
            return raw;
        }


        /// <summary>
        /// Generates a circle texture.
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        protected Texture2D GetCircleTexture(int radius)
        {
            Texture2D circle = new Texture2D(initializer.Graphics, radius * 2, radius * 2);
            Color[] data = new Color[radius * radius * 4];
            for (int y = 0; y < radius; y++)
            {
                for (int x = 0; x < radius; x++)
                {
                    float dist = (float)Math.Sqrt(Math.Pow(radius - y, 2) + Math.Pow(radius - x, 2));
                    if (dist <= radius)
                    {
                        data[y * radius + x % radius] = Color.White;
                    }
                    else
                    {
                        data[y * radius + x % radius] = Color.Transparent;
                    }
                }
            }

            return circle;
        }


        #region Probably Delete
        ///// <summary>
        ///// Serializes the object and saves it as a json file
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="path"></param>
        //public static void SaveObject(GameObject obj, string path)
        //{
        //    string file = JsonConvert.SerializeObject(obj);
        //    File.WriteAllText(path, file);
        //}

        ///// <summary>
        ///// Initializes a 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="toClone"></param>
        ///// <returns></returns>
        //public static GameObject Initialize(GameObject toClone)
        //{
        //    if (toClone == null)
        //    {
        //        return default;
        //    }

        //    JsonSerializerSettings settings = new JsonSerializerSettings
        //    {
        //        ObjectCreationHandling = ObjectCreationHandling.Replace
        //    };
        //    GameObject cloned = JsonConvert.DeserializeObject<GameObject>(JsonConvert.SerializeObject(toClone), settings);
        //    cloned.Load(toClone.initializer);
        //    return cloned;
        //}
        #endregion
        #endregion

        #region Static Methods
        /// <summary>
        /// Checks if the first element is the direct parent of the second element.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool IsDirectChild(GameObject parent, GameObject child)
        {
            return child.parent == parent;
        }
        #endregion

        #region Operator Overloading
        /// <summary>
        /// Access a property of this object.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                if (properties.ContainsKey(key))
                    return properties[key];

                return default;
            }
            set
            {
                properties[key] = value;
            }
        }
        #endregion
    }
}
