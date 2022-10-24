using System;

namespace Core.Matrix
{
    public static class MatrixMath
    {
        #region Multiplication

        private static double[][] _multiplicationBuffer = new double[1][];
        
        public static Matrix MultiplicationBySecondMatrix(Matrix first, Matrix second)
        {
            if (first.Columns != second.Rows)
                throw new InvalidOperationException("Невозможно умножить матрицы");
            
            PreparingForMultiplication(second);
            Multiplication(first, second);

            second.InteractionWithData((row, column) =>
            {
                second.SetElement(row, column, _multiplicationBuffer[row][column]);
            });
            
            return second;
        }

        private static void PreparingForMultiplication(Matrix second)
        {
            if(NeedUpdateMultiplicationBuffer(second) == true)
                UpdateMultiplicationBuffer(second);

            ResetMultiplicationBuffer();
        }

        private static void Multiplication(Matrix first, Matrix second)
        {
            for (int i = 0; i < first.Rows; i++)
            {
                for (int j = 0; j < second.Columns; j++)
                {
                    for (int k = 0; k < first.Columns; k++)
                    {
                        _multiplicationBuffer[i][j] += first.GetElement(i, k) * second.GetElement(k, j);
                    }
                }
            }
        }

        private static bool NeedUpdateMultiplicationBuffer(Matrix matrix)
        {
            if (_multiplicationBuffer.Length != matrix.Rows)
                return true;

            for (int i = 0; i < matrix.Rows; i++)
            {
                if (_multiplicationBuffer[i].Length != matrix.Columns)
                {
                    return true;
                }
            }

            return false;
        }

        private static void UpdateMultiplicationBuffer(Matrix matrix)
        {
            _multiplicationBuffer = new double[matrix.Rows][];

            for (int i = 0; i < _multiplicationBuffer.Length; i++)
            {
                _multiplicationBuffer[i] = new double[matrix.Columns];
            }
        }

        private static void ResetMultiplicationBuffer()
        {
            for (int i = 0; i < _multiplicationBuffer.Length; i++)
            {
                for (int j = 0; j < _multiplicationBuffer[i].Length; j++)
                {
                    _multiplicationBuffer[i][j] = 0;
                }
            }
        }
        
        #endregion
    }
}