using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    public class PhysicsEngine : IUpdated
    {
        #region Fields
        public const int QUAD_SIZE = 32;
        private Dictionary<GameObject, PhysicsBody> bodies;
        private Dictionary<Point, List<PhysicsBody>> bodyQuad;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the physics engine.
        /// </summary>
        public PhysicsEngine()
        {
            bodies = new Dictionary<GameObject, PhysicsBody>();
            bodyQuad = new Dictionary<Point, List<PhysicsBody>>();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Registers the body to the engine.
        /// </summary>
        /// <param name="body"></param>
        public void RegisterBody(PhysicsBody body)
        {
            if (body == null)
                return;
            bodies.Add(body.Holder, body);
            body.OnDestroy += onBodyRemoved;
        }

        private void onBodyRemoved(GameComponent component)
        {
            UnregisterQuadBody((PhysicsBody)component);
            bodies.Remove(component.Holder);
        }

        private Point[] GetFirstQuad(PhysicsBody body)
        {
            BoxCollider collider = body.Collider;
            int x = (int)((body.Position.X + collider.CollisionRectangle.X) / QUAD_SIZE);
            int y = (int)((body.Position.Y + collider.CollisionRectangle.Y) / QUAD_SIZE);
            int lx = (int)Math.Ceiling((body.Position.X + collider.CollisionRectangle.Width) / QUAD_SIZE);
            int ly = (int)Math.Ceiling((body.Position.Y + collider.CollisionRectangle.Height) / QUAD_SIZE);
            return new Point[] { new Point(x, y), new Point(lx, ly) };
        }
        private Point[] GetFirstQuad(PhysicsBody body, Vector2 newPosition)
        {
            BoxCollider collider = body.Collider;
            int x = (int)((newPosition.X + collider.CollisionRectangle.X) / QUAD_SIZE);
            int y = (int)((newPosition.Y + collider.CollisionRectangle.Y) / QUAD_SIZE);
            int lx = (int)Math.Ceiling((newPosition.X + collider.CollisionRectangle.Width) / QUAD_SIZE);
            int ly = (int)Math.Ceiling((newPosition.Y + collider.CollisionRectangle.Height) / QUAD_SIZE);
            return new Point[] { new Point(x, y), new Point(lx, ly) };
        }

        /// <summary>
        /// Updates the state of each physics engine.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            foreach (PhysicsBody body in bodies.Values)
            {
                if (body.Velocity != Vector2.Zero)
                {
                    UnregisterQuadBody(body);
                    Vector2 newPosition = body.Velocity * Time.Instance.DeltaTime;
                    if (body.IsCollidable && canExistHere(body, newPosition))
                    {
                        body.Position = newPosition;
                    }
                    body.Velocity = Vector2.Zero;
                    ReaddQuadBody(body);
                    
                }
            }
        }

        /// <summary>
        /// Unregisters the bod with the quad map.
        /// </summary>
        /// <param name="body"></param>
        private void UnregisterQuadBody(PhysicsBody body)
        {
            Point[] quadPoints = GetFirstQuad(body);
            for (int y = quadPoints[0].Y; y < quadPoints[1].Y; y++)
            {
                for (int x = quadPoints[0].X; x < quadPoints[1].X; x++)
                {
                    Point p = new Point(x, y);
                    if (!bodyQuad.ContainsKey(p))
                    {
                        continue;
                    }

                    List<PhysicsBody> bodies = bodyQuad[p];
                    bodies.Remove(body);
                    if (bodies.Count == 0)
                    {
                        bodyQuad.Remove(p);
                    }
                }
            }
        }

        /// <summary>
        /// Registers the quad bodies of this body into the quad map.
        /// </summary>
        /// <param name="body"></param>
        private void ReaddQuadBody(PhysicsBody body)
        {
            Point[] quadPoints = GetFirstQuad(body);
            for (int y = quadPoints[0].Y; y < quadPoints[1].Y; y++)
            {
                for (int x = quadPoints[0].X; x < quadPoints[1].X; x++)
                {
                    Point p = new Point(x, y);
                    if (!bodyQuad.ContainsKey(p))
                    {
                        bodyQuad.Add(p, new List<PhysicsBody>());
                    }

                    List<PhysicsBody> bodies = bodyQuad[p];
                    bodies.Add(body);
                }
            }
        }
        private bool canExistHere(PhysicsBody body, Vector2 newPosition)
        {
            Point[] quads = GetFirstQuad(body, newPosition);

            for (int y = quads[0].Y; y < quads[1].Y; y++)
            {
                for (int x = quads[0].X; x < quads[1].X; x++)
                {
                    Point key = new Point(x, y);
                    if (!bodyQuad.ContainsKey(key))
                        continue;
                    List<PhysicsBody> bodies = bodyQuad[key];

                    foreach (PhysicsBody b in bodies)
                    {
                        if (b == body) continue;

                        if (body.Collider.CollisionRectangle.Intersects(b.Collider.CollisionRectangle))
                            return false;
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
