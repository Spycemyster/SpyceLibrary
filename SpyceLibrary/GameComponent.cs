using Microsoft.Xna.Framework;
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
        /// Performs any final cleanup operations that aren't handled through regular garbage collection.
        /// </summary>
        public virtual void Unload()
        {
            OnDestroy?.Invoke(this);
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
        }
        #endregion

    }

    #region Interfaces
    public interface IUpdated
    {
        /// <summary>
        /// Updates the state of the object.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime);
    }

    public interface IDrawn
    {
        /// <summary>
        /// The draw order of the game component.
        /// </summary>
        /// <returns></returns>
        public int DrawOrder();

        /// <summary>
        /// Draws the object to the screen.
        /// </summary>
        public void Draw();
    }
    #endregion
}
