using System;
using System.Collections.Generic;

namespace Core
{
    /// <summary>
    /// Основа для точек в 3D, в идеале я хочу тут увидеть операции сравнения, нахождения расстояний, перегрузку операторов и тд
    /// </summary>
    public class Point3D
    {
        public Point3D()
        {
            Position = Vector3.Zero;
        }

        public Point3D(double x, double y, double z)
        {
            Position = new Vector3(x, y, z);
        }

        public Point3D(Vector3 position)
        {
            Position = position;
        }
        
        public Vector3 Position { get; set; }

        public double CalculateDistance(Point3D targetPoint)
        {
            Vector3 result = targetPoint.Position - Position;
            double distance = Math.Sqrt(Math.Pow(result.X, 2) + Math.Pow(result.Y, 2));
            return distance;
        }
        
        public bool InRange(double minX, double minY, double maxX, double maxY)
        {
            double x = Position.X;
            double y = Position.Y;

            if (x < minX || y < minY || x > maxX || y > maxY)
                return false;
            
            return true;
        }
        
        public static Point3D operator -(Point3D first, Point3D second)
        {
            Vector3 position = first.Position - second.Position;
            return new Point3D(position);
        }
    }
}
