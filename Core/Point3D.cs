using System;
using System.Collections.Generic;

namespace Core
{
    /// <summary>
    /// Основа для точек в 3D, в идеале я хочу тут увидеть операции сравнения, нахождения расстояний, перегрузку операторов и тд
    /// </summary>
    ///
    /// double distance = Math.Sqrt(Math.Pow(Xb - Xa, 2) + Math.Pow(Yb - Ya, 2))
    /// Xa и Ya - координаты этой точки
    /// Xb и Yb - координаты второй точки
    public class Point3D
    {
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double CalculateDistance(Point3D targetPoint)
        {
            double distance = Math.Sqrt(Math.Pow(targetPoint.X - X, 2) + Math.Pow(targetPoint.Y - Y, 2));
            return distance;
        }

        public double[] CalculateDistance(List<Point3D> otherPoints)
        {
            double[] result = new double[otherPoints.Count];

            for (int i = 0; i < otherPoints.Count; i++)
            {
                result[i] = CalculateDistance(otherPoints[i]);
            }

            return result;
        }
    }
}