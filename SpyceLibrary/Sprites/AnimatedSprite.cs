using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Sprites
{
    /// <summary>
    /// A spritesheet based sprite.
    /// </summary>
    public class AnimatedSprite : Sprite
    {
        /// <summary>
        /// Creates a new instance of the Animated Sprite.
        /// </summary>
        public AnimatedSprite()
        {
        }
    }

    /// <summary>
    /// Represents an individual animation for a spritesheet.
    /// </summary>
    public class SpriteAnimation : IUpdated
    {
        /// <summary>
        /// The list of frame data in the animated sprite.
        /// </summary>
        public FrameData[] FrameData
        {
            get;
            set;
        }

        /// <summary>
        /// The current frame being displayed.
        /// </summary>
        public int CurrentFrame
        {
            get;
            set;
        }
        private float timer;

        /// <summary>
        /// Updates the state of the animated sprite.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            timer += Time.Instance.DeltaTime;

            if (timer >= FrameData[CurrentFrame].Time)
            {
                CurrentFrame++;
                CurrentFrame %= FrameData.Length;
            }
        }

        /// <summary>
        /// Sets the current frame of the animated sprite.
        /// </summary>
        /// <param name="frame"></param>
        public void SetCurrentFrame(int frame) 
        {
            CurrentFrame = frame;
            timer = 0;
        }
    }

    /// <summary>
    /// Represents a single frame for an animation.
    /// </summary>
    public class FrameData
    {
        /// <summary>
        /// The position of the frame data on the texture file.
        /// </summary>
        public Point Position
        {
            get;
            set;
        }

        /// <summary>
        /// The amount of time is spent on this individual frame.
        /// </summary>
        public float Time
        {
            get;
            set;
        }

        /// <summary>
        /// The texture that the frame is located on. Each frame data holds a refernce to its
        /// texture to allow for animations to potentially consist of different files.
        /// </summary>
        public Texture2D Texture
        {
            get;
            set;
        }
    }
}
