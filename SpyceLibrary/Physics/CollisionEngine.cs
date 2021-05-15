using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static SpyceLibrary.Transform;

namespace SpyceLibrary.Physics
{
    /// <summary>
    /// Handles efficient collision detection by hashing objects to various spots of the game world.
    /// </summary>
    public class CollisionEngine
    {
        private Dictionary<GameObject, List<Collider>> colliders;
        private Dictionary<Point, HashSet<Collider>> hashedPositions;

        /// <summary>
        /// Creates a new instance of a collision engine.
        /// </summary>
        public CollisionEngine()
        {
            colliders = new Dictionary<GameObject, List<Collider>>();
            hashedPositions = new Dictionary<Point, HashSet<Collider>>();
        }

        /// <summary>
        /// Registers a body with the collision engine.
        /// </summary>
        /// <param name="obj"></param>
        public void Registerbody(in GameObject obj)
        {
            List<Collider> col = obj.GetComponents<Collider>();
            colliders.Add(obj, col);
            obj.OnDestroy += UnregisterBody;
            foreach (Collider c in col)
            {
                c.RegisterEngine(this);
            }

            AddBodyToQuads(obj, obj.Position);
        }

        /// <summary>
        /// Unregisters and removes the collider from the engine.
        /// </summary>
        /// <param name="obj"></param>
        public void UnregisterBody(in GameObject obj)
        {
            colliders.Remove(obj);
            obj.GetComponent<Collider>();
            obj.OnDestroy -= UnregisterBody;
            RemoveBodyFromQuads(obj, obj.Position);
        }

        /// <summary>
        /// Removes the body from the quads it is assigned to. This should be called before it moves.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="position"></param>
        public void RemoveBodyFromQuads(in GameObject gameObject, Vector2 position)
        {
            List<Collider> colliders = this.colliders[gameObject];

            foreach (Collider collider in colliders)
            {
                Tuple<Point, Point> points = collider.QuadPoints(position);
                for (int y = points.Item1.Y; y < points.Item2.Y; y++)
                {
                    for (int x = points.Item1.X; x < points.Item2.X; x++)
                    {
                        Point p = new Point(x, y);
                        HashSet<Collider> objects;
                        hashedPositions.TryGetValue(p, out objects);
                        if (objects != null)
                        {
                            objects.Remove(collider);
                            if (objects.Count == 0)
                            {
                                hashedPositions.Remove(p);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds the body from the quads appropriate quads.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="position"></param>
        public void AddBodyToQuads(in GameObject gameObject, Vector2 position)
        {
            List<Collider> colliders = this.colliders[gameObject];

            foreach (Collider collider in colliders)
            {
                Tuple<Point, Point> points = collider.QuadPoints(position);
                for (int y = points.Item1.Y; y < points.Item2.Y; y++)
                {
                    for (int x = points.Item1.X; x< points.Item2.X; x++)
                    {
                        Point p = new Point(x, y);
                        if (hashedPositions.ContainsKey(p)) 
                        {
                            hashedPositions[p].Add(collider);
                        }
                        else
                        {
                            HashSet<Collider> c = new HashSet<Collider>();
                            c.Add(collider);
                            hashedPositions.Add(p, c);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates the state of the given object.
        /// </summary>
        public void UpdateObjectQuad(in GameObject gameObject, Vector2 prevPosition)
        {
            RemoveBodyFromQuads(gameObject, prevPosition);
            AddBodyToQuads(gameObject, gameObject.Position);
        }

        /// <summary>
        /// Gets a set of possible colliders for the given object at a new position.
        /// </summary>
        /// <returns></returns>
        public HashSet<Collider> GetPossibleColliders(in GameObject gameObject, in Vector2 position)
        {
            HashSet<Collider> possible = new HashSet<Collider>();
            List<Collider> objColliders = gameObject.GetComponents<Collider>();

            // gets all the possible colliders that are colliding with this collider
            foreach (Collider c in objColliders)
            {
                possible.UnionWith(GetPossibleColliders(c, position));
            }

            // removes it's own colliders
            foreach (Collider c in objColliders)
            {
                possible.Remove(c);
            }

            return possible;
        }


        /// <summary>
        /// Gets a set of possible colliders for the given collider at a new position.
        /// </summary>
        /// <returns></returns>
        private HashSet<Collider> GetPossibleColliders(in Collider collider, in Vector2 position)
        {
            Tuple<Point, Point> points = collider.QuadPoints(position);
            HashSet<Collider> possible = new HashSet<Collider>();
            for (int y = points.Item1.Y; y < points.Item2.Y; y++)
            {
                for (int x = points.Item1.X; x< points.Item2.X; x++)
                {
                    Point key = new Point(x, y);
                    if (hashedPositions.ContainsKey(key))
                    {
                        possible.UnionWith(hashedPositions[key]);
                    }
                }
            }
            possible.Remove(collider);
            return possible;
        }

        /// <summary>
        /// Gets a set of possible colliders for the given game object at it's current position.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public HashSet<Collider> GetPossibleColliders(in GameObject gameObject)
        {
            return GetPossibleColliders(gameObject, gameObject.Position);
        }

        #region Debug Drawing and Loading
        /// <summary>
        /// Draws each non-empty hash quad.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawHashQuads(SpriteBatch spriteBatch)
        {
            foreach (Point p in hashedPositions.Keys)
            {
                Color c = ((p.X + p.Y) % 2 == 0) ? Color.Red : Color.Blue;
                spriteBatch.Draw(texture, new Rectangle(p.X * Collider.QUAD_SIZE, p.Y * Collider.QUAD_SIZE, Collider.QUAD_SIZE, Collider.QUAD_SIZE), c * 0.3f);
            }
        }
        private Texture2D texture;

        /// <summary>
        /// Loads the texture for the collision engine.
        /// </summary>
        /// <param name="content"></param>
        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("System/blank");
        }
        #endregion
    }
}