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
        #region Fields
        private GameObject holder;
        private bool isEnabled;
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
        }
        #endregion

        #region Methods
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

        /// <summary>
        /// Updates the state of the game component
        /// </summary>
        /// <param name="dt"></param>
        public virtual void Update(float dt)
        {

        }

        /// <summary>
        /// Renders the contents of the game component to the screen.
        /// </summary>
        public virtual void Draw()
        {

        }
        #endregion

        #region Drawn/Updated Definitions
        public virtual bool IsDrawn()
        {
            return false;
        }

        public virtual bool IsUpdated()
        {
            return false;
        }
        #endregion
    }
}
