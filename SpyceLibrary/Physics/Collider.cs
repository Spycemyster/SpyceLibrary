using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SpyceLibrary.Physics
{
    /// <summary>
    /// The arguments passed for collision data
    /// </summary>
    public class ColliderArgs : EventArgs
    {
        /// <summary>
        /// The previous position of the collider
        /// </summary>
        /// <value></value>
        public Vector2 PreviousPosition
        {
            get;
            set;
        }
    }

    /// <summary>
    /// A solid collider for physics bodies.
    /// </summary>
    public class Collider : GameComponent, IUpdated
    {
        /// <summary>
        /// The size of a quadrant
        /// </summary>
        public const int QUAD_SIZE = 100;

        /// <summary>
        /// When another collider enters this collider.
        /// </summary>
        public event EventHandler OnEnter;

        /// <summary>
        /// When the absolute position of the game object moves.
        /// </summary>
        public event EventHandler OnMove;
        private Vector2 prevPosition;
        private ColliderArgs args;
        private CollisionEngine engine;

        /// <summary>
        /// Creates a new instance of the collider.
        /// </summary>
        public Collider()
        {
            OnMove += onMove;
        }

        private void onMove(object sender, EventArgs args)
        {
            ColliderArgs cArgs = (ColliderArgs)args;
            engine.UpdateObjectQuad(Holder, cArgs.PreviousPosition);
        }

        /// <summary>
        /// Loads the collider.
        /// </summary>
        /// <param name="init"></param>
        /// <param name="holder"></param>
        public override void Load(Initializer init, GameObject holder)
        {
            base.Load(init, holder);
            args = new ColliderArgs();
            args.PreviousPosition = Holder.Position;
        }

        /// <summary>
        /// Checks if the object has moved.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            if (prevPosition != Holder.Position)
            {
                OnMove?.Invoke(this, args);
            }
            prevPosition = Holder.Position;
            args.PreviousPosition = prevPosition;
        }

        /// <summary>
        /// Sets the offset of the collider.
        /// </summary>
        /// <param name="point"></param>
        public virtual void SetOffset(Vector2 point)
        {
            OnMove?.Invoke(this, args);
        }

        /// <summary>
        /// When this collider intersects with the given collider.
        /// </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public virtual void OnIntersectWith(Collider collider)
        { 
            InvokeOnEnter(collider, args);
        }
        
        /// <summary>
        /// Get the colliders that are colliding with this collider at the given position.
        /// </summary>
        /// <param name="position"></param>
        public virtual HashSet<Collider> GetCollidingWith(in Vector2 position)
        {
            return null;
        }

        /// <summary>
        /// Invokes the onEnter event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void InvokeOnEnter(object sender, EventArgs args)
        {
            OnEnter?.Invoke(sender, args);
        }

        /// <summary>
        /// The top left and bottom right points of the collider.
        /// </summary>
        /// <returns></returns>
        public virtual Tuple<Point, Point> QuadPoints(Vector2 position) { return new Tuple<Point, Point>(new Point(0, 0), new Point(0, 0)); }

        /// <summary>
        /// Registers the collision engine with the collider.
        /// </summary>
        /// <param name="engine"></param>
        public virtual void RegisterEngine(CollisionEngine engine)
        {
            this.engine = engine;
        }
    }
}