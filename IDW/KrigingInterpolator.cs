using System;
using Core;
using Core.Interfaces;
using System.Collections.Generic;
using Core.Extensions;
using Core.Matrix;

namespace IDW
{
    public class KrigingInterpolator : IInterpolator
    {
        private readonly Dictionary<Point3D, Matrix> _matrixDistance = new Dictionary<Point3D, Matrix>();

        public bool Interpolate(Point3D[][] map, List<Point3D> points, bool[][] calculatingMask, IInterpolationOptions options)
        {
            List<Point3D> validPoints = ApplyMask(map, calculatingMask);

            int size = 50000;
            
            Console.WriteLine(size);
            Matrix covarianceMatrix = new Matrix(size);

            //covarianceMatrix.Fill(validPoints.GetDistance());
            
            return false;
        }

        private List<Point3D> ApplyMask(Point3D[][] map, bool[][] calculatingMask)
        {
            if (MaskFit(map, calculatingMask) == false)
                throw new InvalidOperationException();

            List<Point3D> result = new List<Point3D>();

            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (calculatingMask[i][j] == true)
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
                if (map[i].Length != mask[i].Length)
                {
                    return false;
                }
            }

            return true;
        }
    }
}