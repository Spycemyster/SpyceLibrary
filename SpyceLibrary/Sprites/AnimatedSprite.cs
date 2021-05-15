using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SpyceLibrary.Sprites
{
    /// <summary>
    /// A spritesheet based sprite.
    /// </summary>
    public class AnimatedSprite : Sprite, IUpdated
    {
        #region Fields
        private Initializer initializer;
        private Dictionary<string, SpriteAnimation> animations;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the Animated Sprite.
        /// </summary>
        public AnimatedSprite()
        {
            animations = new Dictionary<string, SpriteAnimation>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads the animation data from the given path.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public void LoadAnimationData(string path, string name)
        {
            XmlSerializer ser = new XmlSerializer(typeof(FrameData[]));
            StreamReader reader = new StreamReader(path);
            reader.ReadToEnd();
            SpriteAnimation animation = new SpriteAnimation();
            FrameData[] data = (FrameData[])ser.Deserialize(reader);
            reader.Close();

            animation.FrameData = data;
            animations.Add(name, animation);
        }

        /// <summary>
        /// Updates the state of the animated sprite.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Loads the textures for the animated sprite.
        /// </summary>
        /// <param name="init"></param>
        /// <param name="holder"></param>
        public override void Load(Initializer init, GameObject holder)
        {
            base.Load(init, holder);
            initializer = init;
        }
        #endregion
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
        /// Saves the frame data to the path.
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(FrameData[]));
            TextWriter writer = new StreamWriter(path);
            ser.Serialize(writer, FrameData);

            writer.Close();
        }

        /// <summary>
        /// Calculates the total time it takes to complete a full animation cycle.
        /// </summary>
        /// <returns></returns>
        public float GetFullTime()
        {
            float time = 0;
            for (int i = 0; i < FrameData.Length; i++)
            {
                time += FrameData[i].Time;
            }

            return time;
        }

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
        /// The path of the texture.
        /// </summary>
        public string TexturePath
        {
            get;
            set;
        }

        /// <summary>
        /// The texture that the frame is located on. Each frame data holds a reference to its
        /// texture to allow for animations to potentially consist of different files.
        /// </summary>
        [XmlIgnore]
        public Texture2D Texture
        {
            get;
            set;
        }
    }
}
