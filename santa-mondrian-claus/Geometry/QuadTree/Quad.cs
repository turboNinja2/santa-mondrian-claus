namespace santa_mondrian_claus.Geometry.QuadTree
{
    /// <summary>
    /// Used by the QuadTree to represent a rectangular area.
    /// </summary>
    public struct Quad
    {
        public float MinX;
        public float MinY;
        public float MaxX;
        public float MaxY;

        /// <summary>
        /// Construct a new Quad.
        /// </summary>
        /// <param name="minX">Minimum x.</param>
        /// <param name="minY">Minimum y.</param>
        /// <param name="maxX">Max x.</param>
        /// <param name="maxY">Max y.</param>
        public Quad(float minX, float minY, float maxX, float maxY)
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
        }

        /// <summary>
        /// Set the Quad's position.
        /// </summary>
        /// <param name="minX">Minimum x.</param>
        /// <param name="minY">Minimum y.</param>
        /// <param name="maxX">Max x.</param>
        /// <param name="maxY">Max y.</param>
        public void Set(float minX, float minY, float maxX, float maxY)
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
        }

        /// <summary>
        /// Check if this Quad intersects with another.
        /// </summary>
        public bool Intersects(ref Quad other)
        {
            return MinX < other.MaxX && MinY < other.MaxY && MaxX > other.MinX && MaxY > other.MinY;
        }

        /// <summary>
        /// Check if this Quad can completely contain another.
        /// </summary>
        public bool Contains(ref Quad other)
        {
            return other.MinX >= MinX && other.MinY >= MinY && other.MaxX <= MaxX && other.MaxY <= MaxY;
        }

        /// <summary>
        /// Check if this Quad contains the point.
        /// </summary>
        public bool Contains(float x, float y)
        {
            return x > MinX && y > MinY && x < MaxX && y < MaxY;
        }
    }
}
