using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpyceLibrary.Physics
{
    /// <summary>
    /// Updates physical objects within the game world.
    /// </summary>
    public class PhysicsEngine : IUpdated
    {
        #region Fields
        /// <summary>
        /// The size of each theoretical quad.
        /// </summary>
        public const int QUAD_SIZE = 64;
        private readonly Dictionary<GameObject, PhysicsBody> bodies;
        private readonly Dictionary<Point, List<PhysicsBody>> bodyQuad;
        private Initializer initializer;
        private Texture2D blank;
        private Random rand;
        private const string DEBUG_NAME = "PHYSICS";
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the physics engine.
        /// </summary>
        public PhysicsEngine()
        {
            bodies = new Dictionary<GameObject, PhysicsBody>();
            bodyQuad = new Dictionary<Point, List<PhysicsBody>>();
            rand = new Random();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Initializes the physics engine.
        /// </summary>
        /// <param name="initializer"></param>
        public void Initialize(Initializer initializer)
        {
            this.initializer = initializer;
            blank = initializer.Content.Load<Texture2D>("System/blank");
        }

        /// <summary>
        /// Registers the body to the engine.
        /// </summary>
        /// <param name="body"></param>
        public void RegisterBody(PhysicsBody body)
        {
            if (body == null)
                return;
            bodies.Add(body.Holder, body);
            body.OnDestroy += OnBodyRemoved;
            ReaddQuadBody(body);
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
                    Vector2 vel = body.Velocity * Time.Instance.DeltaTime;
                    Vector2 velX = new Vector2(vel.X, 0);
                    Vector2 velY = new Vector2(0, vel.Y);
                    if (body.IsCollidable && CanExistHere(body, body.Position + velX)
                        || !CanExistHere(body, body.Position))
                    {
                        body.Position += velX;
                        //Debug.Instance.WriteLine(DEBUG_NAME, $"Position: {body.Position}, Velocity: {vel}");
                    }
                    if (body.IsCollidable && CanExistHere(body, body.Position + velY)
                        || !CanExistHere(body, body.Position))
                    {
                        body.Position += velY;
                        //Debug.Instance.WriteLine(DEBUG_NAME, $"Position: {body.Position}, Velocity: {vel}");
                    }
                    body.Velocity = Vector2.Zero;
                    ReaddQuadBody(body);

                }
            }
        }

        private void OnBodyRemoved(GameComponent component)
        {
            UnregisterQuadBody((PhysicsBody)component);
            bodies.Remove(component.Holder);
        }

        private Point[] GetFirstQuad(PhysicsBody body)
        {
            return GetFirstQuad(body, body.Position);
        }
        private Point[] GetFirstQuad(PhysicsBody body, Vector2 newPosition)
        {
            Rectangle colliderRect = body.Collider.ConstructRectangleAt(body.Position);
            int x = (int)Math.Floor((newPosition.X + body.Collider.Offset.X) / QUAD_SIZE);
            int y = (int)Math.Floor((newPosition.Y + body.Collider.Offset.Y) / QUAD_SIZE);
            int lx = (int)Math.Ceiling((newPosition.X + colliderRect.Width) / QUAD_SIZE);
            int ly = (int)Math.Ceiling((newPosition.Y + colliderRect.Height) / QUAD_SIZE);
            return new Point[] { new Point(x, y), new Point(lx, ly) };
        }

        /// <summary>
        /// Clears all the bodies from the physics engine.
        /// </summary>
        public void Clear()
        {
            bodies.Clear();
            bodyQuad.Clear();
        }

        /// <summary>
        /// Debug Purposes. Draws a half opacity rectangle for all the physics bodies in the world.
        /// </summary>
        public void Draw(Camera camera)
        {
            Point windowSize = SceneManager.Instance.GetWindowSize();
            int startY = (int)(camera.Position.Y / QUAD_SIZE) - 1;
            int startX = (int)(camera.Position.X / QUAD_SIZE) - 1;
            int endY = (int)((camera.Position.Y + windowSize.Y) / QUAD_SIZE);
            int endX = (int)((camera.Position.X + windowSize.X) / QUAD_SIZE);
            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    Point p = new Point(x, y);

                    float opacity = (bodyQuad.ContainsKey(p)) ? 0.9f : 0.4f;
                    Color c = (Math.Abs(x + y) % 2 == 1) ? Color.Green : Color.Blue;
                    Rectangle rect = new Rectangle(x * QUAD_SIZE, y * QUAD_SIZE, QUAD_SIZE, QUAD_SIZE);
                    initializer.SpriteBatch.Draw(blank, rect, c * opacity);
                }
            }

            foreach (PhysicsBody body in bodies.Values)
            {
                if (body.IsCollidable)
                {
                    //Color c = new Color(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                    Color c = Color.Red;
                    Rectangle collisionRect = body.Collider.ConstructRectangleAt(body.Position);
                    initializer.SpriteBatch.Draw(blank, collisionRect, c * 0.5f);
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

                    //Debug.Instance.WriteLine(DEBUG_NAME, $"Unregistered {p}");
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

                    //Debug.Instance.WriteLine(DEBUG_NAME, $"Registered {p}");
                }
            }
        }
        private bool CanExistHere(PhysicsBody body, Vector2 newPosition)
        {
            Point[] quads = GetFirstQuad(body, newPosition);

            for (int y = quads[0].Y; y <= quads[1].Y; y++)
            {
                for (int x = quads[0].X; x <= quads[1].X; x++)
                {
                    Point key = new Point(x, y);
                    if (!bodyQuad.ContainsKey(key))
                        continue;
                    List<PhysicsBody> bodies = bodyQuad[key];

                    foreach (PhysicsBody b in bodies)
                    {
                        if (b == body || !b.IsCollidable) continue;

                        Rectangle bodyCollision = body.Collider.ConstructRectangleAt(newPosition);
                        Rectangle bCollision = b.Collider.ConstructRectangleAt(b.Position);
                        if (bodyCollision.Intersects(bCollision))
                            return false;
                    }
                }
            }

            #region Inefficient Collision Detection (But it works)
            //foreach (PhysicsBody b in bodies.Values)
            //{
            //    if (b == body)
            //        continue;

            //    Rectangle bodyRect = body.Collider.ConstructRectangleAt(newPosition);
            //    Rectangle bRect = b.Collider.ConstructRectangleAt(b.Position);

            //    if (bodyRect.Intersects(bRect))
            //    {
            //        return false;
            //    }
            //}
            #endregion

            return true;
        }
        #endregion
    }
}
