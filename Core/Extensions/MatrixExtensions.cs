using System;
using Core.Variogram;

namespace Core.Extensions
{
    public static class MatrixExtensions
    {
        public static Matrix ConvertToSquareDifference(this Matrix sourceMatrix)
        {
            double[,] resultMatrixStorage = new double[sourceMatrix.Lines, sourceMatrix.Columns];
            
            sourceMatrix.InteractionWithData((i, j) =>
            {
                double point = sourceMatrix.GetElement(i, i);
                double value = sourceMatrix.GetElement(i, j);

                resultMatrixStorage[i, j] = Math.Pow(point - value, 2);
            });

            return new Matrix(resultMatrixStorage);
        }
        
        public static Matrix ConvertToCovariance(this Matrix sourceMatrix, VariogramBase variogram)
        {
            double[,] resultMatrixStorage = new double[sourceMatrix.Lines, sourceMatrix.Columns];
            
            sourceMatrix.InteractionWithData((i, j) =>
            {
                double h = sourceMatrix.GetElement(i, j);
                resultMatrixStorage[i, j] = sourceMatrix.Covariance(h, variogram.Range);
            });

            return new Matrix(resultMatrixStorage);
        }
        
        public static Matrix Inverse(this Matrix matrix)
        {
            if (matrix.Lines != matrix.Columns)
                throw new InvalidOperationException("Обратная матрица существует только для квадратных матриц");

            double[,] invertData = new double[matrix.Lines, matrix.Columns];

            for (int i = 0; i < matrix.Lines; i++)
            {
                int lineOffset = 0;
                int columnOffset = 0;
                
                for (int j = 0; j < matrix.Columns; j++)
                {
                    
                }
            }

            return matrix;
        }
    }
}