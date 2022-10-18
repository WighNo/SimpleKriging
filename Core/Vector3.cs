namespace Core
{
    public struct Vector3
    {
        public double X { get; set; }
        
        public double Y { get; set; }
        
        public double Z { get; set; }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 Zero => new Vector3(0, 0, 0);

        public override string ToString() => $"({X}, {Y}, {Z})";

        public static Vector3 operator -(Vector3 first, Vector3 second)
        {
            double x = first.X - second.X;
            double y = first.Y - second.Y;
            double z = first.Z - second.Z;

            return new Vector3(x, y, z);
        }
    }
}