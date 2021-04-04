using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// An abstract component that is attached to a game object
    /// </summary>
    public class GameComponent
    {
        #region Events

        public delegate void ComponentEvent();

        /// <summary>
        /// When the component is enabled.
        /// </summary>
        public ComponentEvent OnEnable;

        /// <summary>
        /// When the component is disabled.
        /// </summary>
        public ComponentEvent OnDisable;

        /// <summary>
        /// When the component is being destroyed.
        /// </summary>
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
        ~GameComponent()
        {
            OnDestroy?.Invoke();
            Unload();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs any final cleanup operations that aren't handled through regular garbage collection.
        /// </summary>
        public virtual void Unload()
        {

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
                OnEnable?.Invoke();
            }
            else
            {
                OnDisable?.Invoke();
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

        /// <summary>
        /// The holder of this component.
        /// </summary>
        /// <returns></returns>
        protected GameObject GetHolder()
        {
            return holder;
        }
        #endregion

    }
}
