using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace SpyceLibrary
{
    /// <summary>
    /// A game object is able to hold a list of components, which are initialzied, updated, and drawn accordingly. This
    /// class similar to the Unity game engine's concept for a game object.
    /// </summary>
    public class GameObject
    {
        public Transform Transform;
        private List<GameComponent> drawComponents, updateComponents, components;

        /// <summary>
        /// Creates a new instance of a game object.
        /// </summary>
        public GameObject()
        {
            components = new List<GameComponent>();
            drawComponents = new List<GameComponent>();
            updateComponents = new List<GameComponent>();
            Transform = new Transform();
        }

        /// <summary>
        /// Add a component to the game object's list of components.
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(GameComponent component)
        {
            if (component.IsUpdated())
                updateComponents.Add(component);

            if (component.IsDrawn())
                drawComponents.Add(component);

            components.Add(component);
            component.Initialize();
        }

        /// <summary>
        /// Updates the game object's real-time behavior.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            for (int i = 0; i < components.Count; i++)
            {
                GameComponent component = components[i];

                if (component.IsEnabled)
                    component.Update(gameTime);
            }
        }

        /// <summary>
        /// Renders the contents of the game object to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < components.Count; i++)
            {
                GameComponent component = components[i];

                if (component.IsEnabled)
                    component.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Disposes of any unmanaged resources in game components.
        /// </summary>
        public virtual void Dispose()
        {
            foreach(GameComponent component in components)
            {
                component.Dispose();
            }
        }

        /// <summary>
        /// Finds a component matching the same type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>()
        {
            return (T)(object)components.Find(X => X is T);
        }

        /// <summary>
        /// Finds the component of type T and removes it from the components list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveComponent<T>()
        {
            GameComponent component = (GameComponent)(object)GetComponent<T>();

            components.Remove(component);
            drawComponents.Remove(component);
            updateComponents.Remove(component);
        }
    }
}
