﻿using Microsoft.Xna.Framework;
using SpyceLibrary.Debugging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SpyceLibrary
{
    /// <summary>
    /// An abstract component that is attached to a game object
    /// </summary>
    [XmlInclude(typeof(GameObject))]
    public class GameComponent
    {
        #region Events
        /// <summary>
        /// Delegate for handling events related to UI components.
        /// </summary>
        /// <param name="component"></param>
        public delegate void ComponentEvent(GameComponent component);

        /// <summary>
        /// When the component is enabled.
        /// </summary>
        [XmlIgnore]
        public ComponentEvent OnEnable;

        /// <summary>
        /// When the component is disabled.
        /// </summary>
        [XmlIgnore]
        public ComponentEvent OnDisable;

        /// <summary>
        /// When the component is being destroyed.
        /// </summary>
        [XmlIgnore]
        public ComponentEvent OnDestroy;

        #endregion

        #region Fields
        /// <summary>
        /// Whether this component should be updated or drawn.
        /// </summary>
        public bool IsEnabled
        {
            get { return isEnabled; }
        }

        /// <summary>
        /// The game object that this component is attached to.
        /// </summary>
        public GameObject Holder
        {
            get { return holder; }
        }

        /// <summary>
        /// Whether the load function has been called.
        /// </summary>
        /// <value></value>
        public bool IsLoaded 
        {
            get { return isLoaded; }
        }

        /// <summary>
        /// The current scene that is loaded into the scene manager.
        /// </summary>
        /// <value></value>
        public Scene CurrentScene
        {
            get { return SceneManager.Instance.CurrentScene; }
        }

        private bool isLoaded;

        private GameObject holder;
        private bool isEnabled;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the game component.
        /// </summary>
        public GameComponent()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Checks if the component is in the game object and throws an exception if it is not.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T RequireComponent<T>()
        {
            T comp = Holder.GetComponent<T>();
            Debug.Instance.AssertStrict(comp != null, $"Required component {typeof(T)} could not be found.");
            
            return comp;
        }
        /// <summary>
        /// Performs any final cleanup operations that aren't handled through regular garbage collection.
        /// </summary>
        public virtual void Unload()
        {
            OnDestroy?.Invoke(this);
            isLoaded = false;
        }

        /// <summary>
        /// Sets the activeness of the component.
        /// </summary>
        public void SetActive(bool active)
        {
            if (active == isEnabled) return;

            isEnabled = active;
            if (isEnabled)
            {
                OnEnable?.Invoke(this);
            }
            else
            {
                OnDisable?.Invoke(this);
            }
        }

        /// <summary>
        /// Called before the first Update has been called and after the object is created
        /// </summary>
        /// <param name="init"></param>
        /// <param name="holder"></param>
        public virtual void Load(Initializer init, GameObject holder)
        {
            this.holder = holder;
            isLoaded = true;
        }
        #endregion

    }

    #region Interfaces
    /// <summary>
    /// An object that has realtime update behavior.
    /// </summary>
    public interface IUpdated
    {
        /// <summary>
        /// Updates the state of the object.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime);
    }

    /// <summary>
    /// An object that has draw behavior.
    /// </summary>
    public interface IDrawn
    {
        /// <summary>
        /// The maximum number of layers to be drawn on.
        /// </summary>
        public const float MAX_DRAW_ORDER = 5f;

        /// <summary>
        /// The draw order of the game component.
        /// </summary>
        /// <returns></returns>
        public uint DrawOrder();

        /// <summary>
        /// The visible rectangle on the game world.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetDrawRectangle();

        /// <summary>
        /// Draws the object to the screen.
        /// </summary>
        public void Draw();
    }

    /// <summary>
    /// An object that processes user input.
    /// </summary>
    public interface IInput
    {
        /// <summary>
        /// Processes the user input.
        /// </summary>
        /// <param name="input"></param>
        public void ProcessInput(InputManager input);
    }
    #endregion
}
