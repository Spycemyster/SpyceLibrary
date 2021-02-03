using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// A GameComponent object is the parent class for all different components. Components hold behaviors that are
    /// then executed in a GameObject.
    /// </summary>
    public class GameComponent
    {
        private GameObject holder;

        /// <summary>
        /// A flag for whether the game engine to implement the behaviors for this component.
        /// </summary>
        public bool IsEnabled
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates a new instance of the game component.
        /// </summary>
        public GameComponent()
        {
            IsEnabled = true;
        }

        /// <summary>
        /// Enables this component.
        /// </summary>
        public void Enable()
        {
            IsEnabled = true;
        }

        /// <summary>
        /// Disables this component.
        /// </summary>
        public void Disable()
        {
            IsEnabled = false;
        }

        /// <summary>
        /// Whether this game component should be added to the list of drawn game components in the game object.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDrawn() { return false; }

        /// <summary>
        /// Whether this game component should be added to the list of updated game components in the game object.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsUpdated() { return false; }

        /// <summary>
        /// Initializes the game component.
        /// </summary>
        public virtual void Initialize(ContentManager Content, GraphicsDevice graphics, GameObject obj) 
        {
            holder = obj;
        }

        /// <summary>
        /// Returns the game object this component is attached to.
        /// </summary>
        /// <returns></returns>
        public GameObject GetHolder()
        {
            return holder;
        }

        /// <summary>
        /// Disposes the game component's unmanaged resources.
        /// </summary>
        public virtual void Dispose() { }

        /// <summary>
        /// The Update method is called in real time. 
        /// </summary>
        public virtual void Update(GameTime gameTime) { }

        /// <summary>
        /// The Draw method is able to draw images and generated pixels to the screen.
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }

    /// <summary>
    /// The transform class holds the object's position.
    /// </summary>
    public class Transform : GameComponent
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;
        public float Rotation;

        public Transform()
        {
        }
    }
}
