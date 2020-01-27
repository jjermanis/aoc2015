namespace AoC2015
{
    public class Point
    {
        private const int HASH_PRIME = 53;

        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public static Point operator +(Point a, Point b)
            => new Point(a.X + b.X, a.Y + b.Y);

        public bool Equals(Point p)
            => (X == p.X) && (Y == p.Y);
        public override bool Equals(object o)
            => Equals(o as Point);
        public override int GetHashCode()
            => HASH_PRIME * X.GetHashCode() + Y.GetHashCode();
        public override string ToString()
            => $"({X}, {Y})";
    }
}
