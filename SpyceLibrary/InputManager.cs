using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    /// <summary>
    /// A singleton class that handles user input.
    /// </summary>
    public class InputManager
    {
        // --Unfinished-- Todo: Add gamepad buttons and other mouse buttons
        #region Singleton
        private static InputManager inst;

        /// <summary>
        /// Singleton access to the input manager.
        /// </summary>
        public static InputManager Instance
        {
            get 
            { 
                if (inst == null)
                {
                    inst = new InputManager();
                }
                return inst;
            }
        }
        #endregion

        #region Events
        public delegate void KeyboardEventHandler(Keys key);
        public delegate void MouseEventHandler(MouseButton button);

        /// <summary>
        /// When a key is first pressed down.
        /// </summary>
        public event KeyboardEventHandler OnKeyPress;

        /// <summary>
        /// When a key is first released.
        /// </summary>
        public event KeyboardEventHandler OnKeyRelease;

        /// <summary>
        /// When a mouse button has just been pressed.
        /// </summary>
        public event MouseEventHandler OnMousePress;

        /// <summary>
        /// When a mouse button has just been released.
        /// </summary>
        public event MouseEventHandler OnMouseRelease;

        /// <summary>
        /// When the scroll wheel has just been scrolled.
        /// </summary>
        public event MouseEventHandler OnScroll;
        #endregion

        #region Fields
        private KeyboardState currentKeyState, prevKeyState;
        private MouseState currentMouseState, prevMouseState;
        #endregion

        #region Methods
        /// <summary>
        /// Determines if the mouse is scrolled up.
        /// </summary>
        /// <returns></returns>
        public bool IsScrolledUp()
        {
            return MouseScrollAmount() > 0;
        }

        /// <summary>
        /// Determines if the mouse is scrolled down.
        /// </summary>
        /// <returns></returns>
        public bool IsScrolledDown()
        {
            return MouseScrollAmount() < 0;
        }

        /// <summary>
        /// Returns the amount the mouse is scrolled in this update cycle.
        /// </summary>
        /// <returns></returns>
        public int MouseScrollAmount()
        {
            return currentMouseState.ScrollWheelValue - prevMouseState.ScrollWheelValue;
        }

        /// <summary>
        /// Determines whether the mouse has been clicked.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool IsMouseClicked(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LEFT:
                    return currentMouseState.LeftButton.Equals(ButtonState.Pressed) &&
                        prevMouseState.LeftButton.Equals(ButtonState.Released);
                case MouseButton.RIGHT:
                    return currentMouseState.RightButton.Equals(ButtonState.Pressed) &&
                        prevMouseState.RightButton.Equals(ButtonState.Released);
                case MouseButton.MIDDLE:
                    return currentMouseState.MiddleButton.Equals(ButtonState.Pressed) &&
                        prevMouseState.MiddleButton.Equals(ButtonState.Released);
                default:
                    // placeholder
                    return currentMouseState.LeftButton.Equals(ButtonState.Pressed) &&
                        prevMouseState.LeftButton.Equals(ButtonState.Released);
            }
        }

        /// <summary>
        /// Determines if the button is currently being held down.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool IsMouseUp(MouseButton button)
        {
            return !IsMouseDown(button);
        }

        /// <summary>
        /// Determines if the button is currently being held down.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public bool IsMouseDown(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LEFT:
                    return currentMouseState.LeftButton.Equals(ButtonState.Pressed);
                case MouseButton.RIGHT:
                    return currentMouseState.RightButton.Equals(ButtonState.Pressed);
                case MouseButton.MIDDLE:
                    return currentMouseState.MiddleButton.Equals(ButtonState.Pressed);
                default:
                    // placeholder
                    return currentMouseState.LeftButton.Equals(ButtonState.Pressed);
            }
        }

        /// <summary>
        /// Determines whether the key(s) have been pressed.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public bool IsKeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the key(s) are released.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public bool IsKeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the key(s) are down.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public bool IsKeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the state of the input manager.
        /// </summary>
        public void Update()
        {
            // updates the mouse and keyboard state
            prevKeyState = currentKeyState;
            prevMouseState = currentMouseState;

            currentKeyState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            // checks if any mouse buttons have been pressed
            if (OnMousePress != null)
            {
                if (prevMouseState.LeftButton.Equals(ButtonState.Released) 
                    && currentMouseState.LeftButton.Equals(ButtonState.Pressed))
                {
                    OnMousePress(MouseButton.LEFT);
                }
                if (prevMouseState.RightButton.Equals(ButtonState.Released) 
                    && currentMouseState.RightButton.Equals(ButtonState.Pressed))
                {
                    OnMousePress(MouseButton.RIGHT);
                }
                if (prevMouseState.MiddleButton.Equals(ButtonState.Released) 
                    && currentMouseState.MiddleButton.Equals(ButtonState.Pressed))
                {
                    OnMousePress(MouseButton.MIDDLE);
                }
            }

            // checks if any mouse buttons have been released
            if (OnMouseRelease != null)
            {
                if (currentMouseState.LeftButton.Equals(ButtonState.Released)
                    && prevMouseState.LeftButton.Equals(ButtonState.Pressed))
                {
                    OnMouseRelease(MouseButton.LEFT);
                }
                if (currentMouseState.RightButton.Equals(ButtonState.Released)
                    && prevMouseState.RightButton.Equals(ButtonState.Pressed))
                {
                    OnMouseRelease(MouseButton.RIGHT);
                }
                if (currentMouseState.MiddleButton.Equals(ButtonState.Released)
                    && prevMouseState.MiddleButton.Equals(ButtonState.Pressed))
                {
                    OnMouseRelease(MouseButton.MIDDLE);
                }
            }

            // checks if any keys have been pressed or released
            if (OnKeyPress != null || OnKeyRelease != null)
            {
                Keys[] prevDownKeys = prevKeyState.GetPressedKeys();
                Keys[] downKeys = currentKeyState.GetPressedKeys();
                // check for newly pressed keys
                if (OnKeyPress != null)
                {
                    List<Keys> newlyPressed = findNewKeys(downKeys, prevDownKeys);
                    foreach (Keys key in newlyPressed)
                    {
                        OnKeyPress(key);
                    }
                }

                // checks for newly released keys
                if (OnKeyRelease != null)
                {
                    List<Keys> newlyReleased = findNewKeys<Keys>(prevDownKeys, downKeys);
                    foreach (Keys key in newlyReleased)
                    {
                        OnKeyRelease(key);
                    }
                }
            }
        }
        
        /// <summary>
        /// Creates a list of keys that are currently in a, but not in b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private List<T> findNewKeys<T>(T[] a, T[] b)
        {
            List<T> newKeys = new List<T>();
            for (int i = 0; i < a.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (b[j].Equals(a[i]))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    newKeys.Add(a[i]);
                }
            }

            return newKeys;
        }
        #endregion
    }
    /// <summary>
    /// The mouse buttons on a mouse.
    /// </summary>
    public enum MouseButton
    {
        /// <summary>
        /// The left mouse button
        /// </summary>
        LEFT,

        /// <summary>
        /// The right mouse button
        /// </summary>
        RIGHT,

        /// <summary>
        /// The middle mouse button
        /// </summary>
        MIDDLE,
    }
}
