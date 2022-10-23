using Core;
using Core.Extensions;
using Core.Matrix;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IDW
{
    public class KrigingInterpolator : IInterpolator
    {
        private Dictionary<Point3D, Matrix> _weightMatrices;
        private List<Matrix> _matrixBuffer;
        
        private Matrix _gridPointDistanceMatrix;

        public bool Interpolate(Point3D[][] map, List<Point3D> points, bool[][] calculatingMask, IInterpolationOptions options)
        {
            List<Point3D> validPoints = DefineValidPoints(map, calculatingMask, points);
            
            int iterationCount = (int) Math.Ceiling((double) validPoints.Count / options.ChunkSize);
            int positionPointer = 0;
            
            Prepare(points, options);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < iterationCount; i++)
            {
                int startIndex = positionPointer;
                int endIndex = positionPointer + options.ChunkSize;
                
                if (endIndex > validPoints.Count)
                    endIndex = validPoints.Count;
                
                _weightMatrices.Clear();

                CalculateWeightMatrices(startIndex, endIndex, ref positionPointer, validPoints, points);
                RestoreZ(points);

                /*
                for (int j = startIndex; j < endIndex; j++)
                {
                    int pointIndex = j - startIndex;
                    
                    Point3D point3D = validPoints[positionPointer];
                    Matrix matrix = _matrixBuffer[pointIndex];
                    matrix.Fill(point3D.GetDistance(points, points.Count, 1));
                    
                    _weightMatrices.Add(point3D, MatrixMath.MultiplicationBySecondMatrix(_gridPointDistanceMatrix, matrix));
                    
                    positionPointer++;
                }
                */

                /*foreach (KeyValuePair<Point3D, Matrix> pair in _weightMatrices)
                {
                    Point3D point = pair.Key;
                    Matrix matrix = pair.Value;

                    double x = point.Position.X;
                    double y = point.Position.Y;
                    double z = 0;

                    for (int index = 0; index < points.Count; index++)
                    {
                        z += points[index].Position.Z * matrix.GetElement(index, 0);
                    }

                    point.Position = new Vector3(x, y, z);
                }*/
                
                Console.WriteLine($"{i} | {iterationCount}");
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            
            return true;
        }

        private List<Point3D> DefineValidPoints(Point3D[][] map, bool[][] calculatingMask, List<Point3D> points)
        {
            if (MaskFit(map, calculatingMask) == false)
                throw new InvalidOperationException();
            
            List<Point3D> result = new List<Point3D>();

            double xMinimum = points.Min(x => x.Position.X);
            double yMinimum = points.Min(x => x.Position.Y);
            
            double xMaximum = points.Max(x => x.Position.X);
            double yMaximum = points.Max(x => x.Position.Y);
            
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    bool inRange = map[i][j].InRange(xMinimum, yMinimum, xMaximum, yMaximum);
                    
                    if (calculatingMask[i][j] == true && inRange == true)
                    {
                        result.Add(map[i][j]);
                    }
                }
            }

            return result;
        }

        private bool MaskFit(Point3D[][] map, bool[][] mask)
        {
            if (map.Length != mask.Length)
                return false;

            for (int i = 0; i < map.Length; i++)
            {
                if (map[i].Length == mask[i].Length)
                    continue;

                return false;
            }

            return true;
        }

        private void Prepare(List<Point3D> points, IInterpolationOptions options)
        {
            CreateGridMatrix(points);
            CreateBufferMatrix(points.Count, options);
            CreateWeightMatrices(options);
        }
        
        private void CreateGridMatrix(List<Point3D> points)
        {
            _gridPointDistanceMatrix = new Matrix(points.Count);
            _gridPointDistanceMatrix.Fill(points.GetDistance());
            _gridPointDistanceMatrix = _gridPointDistanceMatrix.Inverse();
        }

        private void CreateBufferMatrix(int storageSize, IInterpolationOptions options)
        {
            _matrixBuffer = new List<Matrix>(options.ChunkSize);

            for (int i = 0; i < options.ChunkSize; i++)
            {
                _matrixBuffer.Add(new Matrix(storageSize, 1));
            }
        }

        private void CreateWeightMatrices(IInterpolationOptions options)
        {
            _weightMatrices = new Dictionary<Point3D, Matrix>(options.ChunkSize);
        }

        private void CalculateWeightMatrices(int startIndex, int endIndex, ref int positionPointer, List<Point3D> validPoints, List<Point3D> points)
        {
            for (int j = startIndex; j < endIndex; j++)
            {
                int pointIndex = j - startIndex;
                    
                Point3D point3D = validPoints[positionPointer];
                Matrix matrix = _matrixBuffer[pointIndex];
                matrix.Fill(point3D.GetDistance(points, points.Count, 1));
                    
                _weightMatrices.Add(point3D, MatrixMath.MultiplicationBySecondMatrix(_gridPointDistanceMatrix, matrix));
                    
                positionPointer++;
            }
        }

        private void RestoreZ(List<Point3D> points)
        {
            foreach (KeyValuePair<Point3D, Matrix> pair in _weightMatrices)
            {
                Point3D point = pair.Key;
                Matrix matrix = pair.Value;

                double x = point.Position.X;
                double y = point.Position.Y;
                double z = 0;

                for (int index = 0; index < points.Count; index++)
                {
                    z += points[index].Position.Z * matrix.GetElement(index, 0);
                }

                point.Position = new Vector3(x, y, z);
            }
        }
    }
}