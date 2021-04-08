using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SpyceLibrary
{
    /// <summary>
    /// A scene represents a set of various game objects interacting. Scenes are indepedent of each other and
    /// can be interchangebly loaded using the scene manager.
    /// </summary>
    public class Scene
    {
        #region Fields
        public Dictionary<Guid, GameObject> GameObjects
        {
            get { return objects; }
        }
        private readonly Dictionary<Guid, GameObject> objects;
        private readonly List<FunctionCall> repeatFunctions;
        private Initializer initializer;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game scene.
        /// </summary>
        public Scene()
        {
            objects = new Dictionary<Guid, GameObject>();
            repeatFunctions = new List<FunctionCall>();
        }
        #endregion

        #region Function Call
        private class FunctionCall
        {
            public Action Action;
            public float Interval;
            public float Timer;
            public bool isRepeating;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Prints the current tick speed and FPS to the debug console.
        /// </summary>
        public void PrintTickSpeed()
        {
            double fps = Math.Round(1.0 / Time.Instance.RawDeltaTime, 3);
            long speed = Debug.Instance.TickSpeed;
            ConsoleColor textColor = (speed > 16) ? ((speed > 32)
                ? ConsoleColor.Red : ConsoleColor.Yellow) : ConsoleColor.Green;
            Debug.Instance.WriteLine(GetDebugName(), $"Current Tick Speed: {speed} ms, FPS: {String.Format("{0:0.000}", fps)}", ConsoleColor.Green, textColor);
        }

        /// <summary>
        /// The debug name of the current scene.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetDebugName()
        {
            return "SCENE";
        }

        /// <summary>
        /// Saves the object to a specified path.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        public void SaveObject(GameObject obj, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameObject));
            using (TextWriter tw = new StreamWriter(path))
            {
                serializer.Serialize(tw, obj);
            }
        }

        /// <summary>
        /// Loads an object from a specified path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public GameObject LoadObject(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(GameObject));
            TextReader reader = new StreamReader(path);
            GameObject obj = (GameObject)deserializer.Deserialize(reader);
            obj.Load(initializer);

            return obj;
        }

        /// <summary>
        /// Removes an existing intervaled function.
        /// </summary>
        /// <param name="action"></param>
        public void RemoveInterval(Action action)
        {
            FunctionCall c = repeatFunctions.Find(x => x.Action == action);
            repeatFunctions.Remove(c);
        }

        /// <summary>
        /// Runs a function on a fixed interval.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="interval"></param>
        /// <param name="time"></param>
        public void SetInterval(Action action, float interval = -1, float time = 0)
        {
            FunctionCall c = new FunctionCall
            {
                Action = action,
                Timer = time,
                Interval = interval,
                isRepeating = interval != -1,
            };

            repeatFunctions.Add(c);
        }

        /// <summary>
        /// Performs any cleanup operations not done in regular garbage collection.
        /// </summary>
        public virtual void Unload()
        {
            foreach (GameObject obj in objects.Values)
            {
                obj.Destroy();
            }

            initializer.Content.Unload();
        }

        /// <summary>
        /// Adds an object to the game scene.
        /// </summary>
        /// <param name="obj"></param>
        public virtual void AddObject(GameObject obj)
        {
            do
            {
                obj.GenerateNewID();
            } while (objects.ContainsKey(obj.ID));

            objects.Add(obj.ID, obj);
            obj.OnDestroy += OnObjectDestruction;
            obj.Load(initializer);
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
        public virtual bool RemoveObject(Guid id)
        {
            return objects.Remove(id);
        }

        /// <summary>
        /// Initializes the game scene with the necessary resources.
        /// </summary>
        /// <param name="initializer"></param>
        public void Initialize(Initializer initializer)
        {
            this.initializer = initializer;

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
            for (int i = 0; i < repeatFunctions.Count; i++)
            {
                FunctionCall c = repeatFunctions[i];
                c.Timer -= Time.Instance.DeltaTime;

                if (c.Timer <= 0)
                {
                    c.Action.Invoke();
                    if (c.isRepeating)
                    {
                        c.Timer = c.Interval;
                    }
                    else
                    {
                        repeatFunctions.RemoveAt(i--);
                    }
                }
            }

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
            foreach (GameObject obj in objects.Values)
            {
                if (obj.IsActive)
                {
                    obj.Draw();
                }
            }
        }
        #endregion
    }
}
