using Microsoft.Xna.Framework;

namespace SpyceLibrary.Physics
{
    /// <summary>
    /// A solid collider for physics bodies.
    /// </summary>
    public interface Collider
    {
        /// <summary>
        /// Checks if this collider intersects with the given collider.
        /// </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public bool Intersects(Collider collider);

        /// <summary>
        /// The top left position of the quad for the collider.
        /// </summary>
        /// <returns></returns>
        public Point TopLeftQuad();

        /// <summary>
        /// The bottom right quad position of the collider.
        /// </summary>
        /// <returns></returns>
        public Point BottomRightQuad();
    }
}