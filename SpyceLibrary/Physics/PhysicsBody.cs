using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    [Serializable]
    public class PhysicsBody : GameComponent, IUpdated
    {
        #region Fields
        #endregion

        #region Constructor
        public PhysicsBody()
        {
        }
        #endregion

        #region Methods
        public override void Load(Initializer init, GameObject holder)
        {
            base.Load(init, holder);
        }
        public void Update(GameTime gameTime)
        {
        }
        #endregion
    }
}
