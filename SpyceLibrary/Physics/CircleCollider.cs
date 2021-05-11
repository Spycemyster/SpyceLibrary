using Microsoft.Xna.Framework;

namespace SpyceLibrary.Physics
{
    /// <summary>
    /// A solid collider that has the shape of a circle.
    /// </summary>
    public class CircleCollider : GameComponent {
        /// <summary>
        /// The radius of the circle.
        /// </summary>
        /// <value></value>
        public float Radius
        {
            get;
            set;
        }

        /// <summary>
        /// Position of the circle.
        /// </summary>
        /// <value></value>
        public Vector2 Position
        {
            get { return offset + Holder.Position; }
        }

        private Vector2 offset;

        /// <summary>
        /// Creates a new instance of the Circle Collider.
        /// </summary>
        public CircleCollider() {

        }

        /// <summary>
        /// Checks if this circle is colliding with the other.
        /// </summary>
        /// <param name="circle"></param>
        /// <returns></returns>
        public bool Intersects(CircleCollider circle) {
            float r = circle.Radius + Radius;
            r *= r;
            return r < (circle.Position.X + Position.X) * (circle.Position.X + Position.X) 
                    + (circle.Position.Y + Position.Y) * (circle.Position.Y + Position.Y);
        }

        public void SetOffset(Vector2 offset) {
            this.offset = offset;
        }

    }
}