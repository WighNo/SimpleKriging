using System.Collections.Generic;

namespace Core.Extensions
{
    public static class DistanceMatrixExtensions
    {
        private static double[][] _matrixDistance = new double[1][];
        
        public static double[][] GetDistance(this List<Point3D> points, int rows = 0, int columns = 0)
        {
            rows = rows == 0 ? points.Count : rows;
            columns = columns == 0 ? points.Count : columns;
            
            if (MatrixDistanceIsValid(rows, columns) == false)
                CreateDistanceMatrix(rows, columns);

            for (int index = 0; index < rows; index++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _matrixDistance[index][j] = points[index].CalculateDistance(points[j]);
                }
            }

            return _matrixDistance;
        }

        public static double[][] GetDistance(this Point3D point, List<Point3D> otherPoints, int rows = 0, int columns = 0)
        {
            rows = rows == 0 ? otherPoints.Count : rows;
            columns = columns == 0 ? otherPoints.Count : columns;
            
            if (MatrixDistanceIsValid(rows, columns) == false)
                CreateDistanceMatrix(rows, columns);

            for (int index = 0; index < rows; index++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _matrixDistance[index][j] = point.CalculateDistance(otherPoints[j]);
                }
            }

            return _matrixDistance;
        }
        
        private static bool MatrixDistanceIsValid(int rows, int columns)
        {
            if (_matrixDistance.Length != rows)
                return false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (_matrixDistance[i].Length != columns)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void CreateDistanceMatrix(int rows, int columns)
        {
            _matrixDistance = new double[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _matrixDistance[i] = new double[columns];
                }
            }
        }
    }
}