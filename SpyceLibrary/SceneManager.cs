using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary
{
    // --UNFINISHED--
    /// <summary>
    /// A singleton object that handles various screen states. This has functionality that allows for
    /// smooth transitions between different screen states.
    /// </summary>
    public class SceneManager
    {
        #region Singleton
        private static SceneManager inst;
        /// <summary>
        /// Static access to the singleton scene manager object.
        /// </summary>
        public static SceneManager Instance
        {
            get 
            {
                if (inst == null)
                {
                    inst = new SceneManager();
                }

                return inst; 
            }
        }
        #endregion

        #region Events
        #endregion

        #region Fields
        public GameScene CurrentScene
        {
            get { return currentScene; }
        }
        public Type CurrentSceneType
        {
            get { return currentType; }
        }
        private Dictionary<string, Type> scenes;
        private GameScene currentScene;
        private Type currentType;
        private ContentManager content;
        private SpriteBatch spriteBatch;
        private GraphicsDevice graphics;
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the scene manager.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="graphics"></param>
        public void Initialize(ContentManager content, SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            scenes = new Dictionary<string, Type>();
            this.content = content;
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
        }

        /// <summary>
        /// Updates the scene manager and it's current scene.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Renders the contents of the scene manager and it's current scene.
        /// </summary>
        public void Draw()
        {

        }

        /// <summary>
        /// Changes the scene to the given scene.
        /// </summary>
        /// <param name="scene"></param>
        public bool ChangeScene(string scene)
        {
            if (!scenes.ContainsKey(scene))
                return false;

            currentScene?.Destroy();
            currentType = scenes[scene];
            currentScene = LoadScene(scene);
            return true;
        }

        private Initializer getInitializer()
        {
            Initializer init = new Initializer
            {
                Content = content,
                SpriteBatch = spriteBatch,
                Graphics = graphics,
            };
            return init;
        }

        /// <summary>
        /// Creates a new instance of the given scene and returns it.
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        public GameScene LoadScene(string scene)
        {
            GameScene loaded = (GameScene)Activator.CreateInstance(scenes[scene]);
            // initialize the loaded scene
            loaded.Initialize(getInitializer());
            return loaded;
        }
        #endregion
    }
}
