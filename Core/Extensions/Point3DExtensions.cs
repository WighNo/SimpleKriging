using System;
using System.Collections.Generic;

namespace Core.Extensions
{
    public static class Point3DExtensions
    {
        public static double[] GetDistance(this List<Point3D> points)
        {
            double[] result = new double[points.Count * points.Count];

            for (int index = 0; index < points.Count; index++)
            {
                double[] distance = points[index].CalculateDistance(points);
                for (int j = 0; j < distance.Length; j++)
                {
                    result[j + index * points.Count] = distance[j];
                }
            }

            return result;
        }

        public static Matrix GetDistanceMatrix(this List<Point3D> points)
        {
            Matrix result = new Matrix(points.Count);
            throw new NotImplementedException();
        }
    }
}