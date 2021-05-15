using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpyceLibrary.Debugging;

namespace SpyceLibrary.Physics
{
    /// <summary>
    /// A rectangular collider.
    /// </summary>
    public class BoxCollider : Collider, IUpdated
    {
        private Point size;
        private Vector2 offset;
        private CollisionEngine engine;

        /// <summary>
        /// Creates a new instance of the box collider.
        /// </summary>
        public BoxCollider()
        {
            size = Point.Zero;
            offset = Vector2.Zero;
        }

        /// <summary>
        /// Updates the logic of the box collider.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Sets the size of the box collider.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetSize(int width, int height)
        {
            size = new Point(width, height);
        }

        /// <summary>
        /// Sets the offset of the box collider.
        /// </summary>
        public override void SetOffset(Vector2 offset)
        {
            this.offset = offset;
        }

        /// <summary>
        /// Constructs a collision rectangle at the holder's position.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetCollisionRectangle(Vector2 position)
        {
            Point s = new Point((int)(size.X * Holder.Scale.X), (int)(size.Y * Holder.Scale.Y));
            return new Rectangle((int)(position.X - s.X / 2 + offset.X),
                (int)(position.Y - s.Y / 2 + offset.Y), s.X, s.Y);
        }

        /// <summary>
        /// Gets a set of all colliders that this collider is colliding with at any given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override HashSet<Collider> GetCollidingWith(in Vector2 position)
        {
            HashSet<Collider> colliders = engine.GetPossibleColliders(Holder, position);
            HashSet<Collider> collidingWith = new HashSet<Collider>();
            foreach(Collider c in colliders)
            {
                // box collider
                if (c is BoxCollider bc)
                {
                    if (bc.GetCollisionRectangle(bc.Holder.Position).Intersects(GetCollisionRectangle(position)))
                    {
                        collidingWith.Add(c);
                    }
                }
                // add other collider types here

                else
                {
                    Debug.Instance.AssertStrict(false, $"BoxCollider does not have a defined collision behavior {c.GetType()}", "BoxCollider.cs");
                }
            }
            return collidingWith;
        }

        /// <summary>
        /// The top left and bottom right points of the collider.
        /// </summary>
        /// <returns></returns>
        public override Tuple<Point, Point> QuadPoints(Vector2 position)
        {
            Rectangle collisionRect = GetCollisionRectangle(position);
            int x = (int)Math.Floor(collisionRect.X / (float)Collider.QUAD_SIZE);
            int y = (int)Math.Floor(collisionRect.Y / (float)Collider.QUAD_SIZE);
            int lx = (int)Math.Ceiling(collisionRect.Right / (float)Collider.QUAD_SIZE);
            int ly = (int)Math.Ceiling(collisionRect.Bottom / (float)Collider.QUAD_SIZE);

            return new Tuple<Point, Point>(new Point(x, y), new Point(lx, ly));
        }


        /// <summary>
        /// Called when the collider intersects another collider.
        /// </summary>
        /// <param name="collider"></param>
        public override void OnIntersectWith(Collider collider)
        {
            BoxColliderArgs args = new BoxColliderArgs();
            args.ThatCollider = collider;
            args.ThisCollider = this;
            InvokeOnEnter(collider, args);
        }

        /// <summary>
        /// Registers the engine with this collider.
        /// </summary>
        /// <param name="engine"></param>
        public override void RegisterEngine(CollisionEngine engine)
        {
            base.RegisterEngine(engine);
            this.engine = engine;
        }

        #region Collision Check
        
        #endregion
    }

    /// <summary>
    /// Argument object for box colliders.
    /// </summary>
    public class BoxColliderArgs : EventArgs
    {
        /// <summary>
        /// This box collider
        /// </summary>
        public BoxCollider ThisCollider;

        /// <summary>
        /// The collider that intersects with this box collider.
        /// </summary>
        public Collider ThatCollider;
    }
}