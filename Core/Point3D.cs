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

        public static Point3D operator -(Point3D first, Point3D second)
        {
            Vector3 position = first.Position - second.Position;
            return new Point3D(position);
        }
    }
}
