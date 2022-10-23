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
        
        public static double[] CalculateDistance(this Point3D point, List<Point3D> otherPoints)
        {
            double[] result = new double[otherPoints.Count];

            for (int i = 0; i < otherPoints.Count; i++)
            {
                result[i] = CalculateDistance(point, otherPoints[i]);
            }

            return result;
        }
        
        public static double CalculateDistance(this Point3D point, Point3D targetPoint)
        {
            Vector3 result = targetPoint.Position - point.Position;
            double distance = Math.Sqrt(Math.Pow(result.X, 2) + Math.Pow(result.Y, 2));
            return distance;
        }

    }
}