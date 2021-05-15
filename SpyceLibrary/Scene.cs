using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using SpyceLibrary.Debugging;
using SpyceLibrary.UI;
using SpyceLibrary.Lighting;
using SpyceLibrary.Physics;

namespace SpyceLibrary
{
    /// <summary>
    /// A scene represents a set of various game objects interacting. Scenes are independent of each other and
    /// can be interchangeably loaded using the scene manager.
    /// </summary>
    public class Scene
    {
        #region Fields
        /// <summary>
        /// Reference to the data structure holding all the game objects in the game.
        /// </summary>
        public Dictionary<Guid, GameObject> GameObjects
        {
            get { return objects; }
        }

        /// <summary>
        /// The rectangle of the screen.
        /// </summary>
        public Rectangle ScreenRectangle
        {
            get { return screenRect; }
        }

        /// <summary>
        /// Stack of UI panels.
        /// </summary>
        public List<UIScreen> UIs
        {
            get { return uiStack; }
        }

        /// <summary>
        /// Events that occur with a game object.
        /// </summary>
        /// <param name="obj"></param>
        public delegate void SceneEvent(GameObject obj);

        /// <summary>
        /// After an object is added to the scene.
        /// </summary>
        public SceneEvent OnObjectAdded;

        /// <summary>
        /// The color of the scene's background.
        /// </summary>
        protected Color BackgroundColor;
        private readonly Dictionary<Guid, GameObject> objects;
        private readonly List<FunctionCall> repeatFunctions;
        private Initializer initializer;
        private List<UIScreen> uiStack;
        private Queue<GameObject> removeObjects, addObjects;
        private UIState uiState;
        private Rectangle screenRect;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game scene.
        /// </summary>
        public Scene()
        {
            objects = new Dictionary<Guid, GameObject>();
            repeatFunctions = new List<FunctionCall>();
            uiStack = new List<UIScreen>();
            uiState = UIState.Gameplay;
            removeObjects = new Queue<GameObject>();
            addObjects = new Queue<GameObject>();
            BackgroundColor = Color.White;
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
        /// Sets the state of the scene.
        /// </summary>
        /// <param name="state"></param>
        public void SetState(UIState state)
        {
            uiState = state;
        }

        /// <summary>
        /// Pushes a new UI menu to the UI stack.
        /// </summary>
        /// <param name="ui"></param>
        public void PushUI(UIScreen ui)
        {
            ui.Initialize(initializer);
            uiStack.Add(ui);
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

            // updates the objects
            foreach (GameObject obj in objects.Values)
            {
                if (obj.IsActive)
                {
                    obj.Update(gameTime);

                    if (uiState == UIState.Gameplay || uiState == UIState.Parallel || uiState == UIState.Closed)
                    {
                        obj.ProcessInput(InputManager.Instance);
                    }
                }
            }
            
            // adds the queued objects
            while (addObjects.Count > 0) {
                GameObject obj = addObjects.Dequeue();
                do
                {
                    obj.GenerateNewID();
                } while (objects.ContainsKey(obj.ID));

                objects.Add(obj.ID, obj);
                obj.OnDestroy += OnObjectDestruction;
                obj.Load(initializer);
                OnObjectAdded?.Invoke(obj);
            }

            // removes the queued objects
            while (removeObjects.Count > 0) {
                GameObject obj = removeObjects.Dequeue();
                RemoveObject(obj.ID);
                obj.OnDestroy -= OnObjectDestruction;
            }

            foreach (UIScreen ui in uiStack)
            {
                ui.Update(gameTime);
            }

            if (uiState != UIState.Closed && uiStack.Count != 0)
            {
                ProcessInputUI();
            }
        }

        private void ProcessInputUI()
        {
            uiStack[^1].ProcessInput(InputManager.Instance);
        }

        /// <summary>
        /// Sets the size of the screen rectangle.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetScreenRectangleBounds(int width, int height)
        {
            screenRect.Size = new Point(width, height);
        }

        /// <summary>
        /// Sets the position of the screen rectangle.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetScreenRectangleLocation(int x, int y)
        {
            screenRect.Location = new Point(x, y);
        }

        /// <summary>
        /// Prints the current tick speed and FPS to the debug console.
        /// </summary>
        public void PrintTickSpeed()
        {
            double fps = Math.Round(1.0 / Time.Instance.RawDeltaTime, 3);
            long speed = Debug.Instance.TickSpeed;
            ConsoleColor textColor = (speed > 16) ? ((speed > 32)
                ? ConsoleColor.Red : ConsoleColor.Yellow) : ConsoleColor.Green;
            Debug.Instance.WriteLine(GetDebugName(), $"Current Tick: {speed} ms, Draw: {Debug.Instance.DrawTime} ms, " +
                $"Update Speed: {Debug.Instance.UpdateTime} ms, FPS: {String.Format("{0:0.000}", fps)}",
                ConsoleColor.Green, textColor);
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
        /// Removes an existing intervalled function.
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
            addObjects.Enqueue(obj);
        }

        /// <summary>
        /// When an object is destroyed, it is removed from the scene.
        /// </summary>
        /// <param name="obj"></param>
        private void OnObjectDestruction(in GameObject obj)
        {
            removeObjects.Enqueue(obj);
        }

        /// <summary>
        /// Removes an object from the game scene.
        /// </summary>
        /// <param name="id"></param>
        public virtual bool RemoveObject(Guid id)
        {
            if (objects.ContainsKey(id))
            {
                GameObject o = objects[id];
                o.Destroy();
                return objects.Remove(id);
            }
            return false;
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

        /// <summary>
        /// Draws the user interface of the scene.
        /// </summary>
        protected void DrawUI()
        {
            if (uiState != UIState.Closed)
            {
                for (int i = 0; i < uiStack.Count; i++)
                {
                    uiStack[i].Draw(initializer.SpriteBatch);
                }

                uiStack[^1].DrawTitle(initializer.SpriteBatch);
            }
        }
        #endregion
    }
}
