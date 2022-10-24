using System;

namespace Core.Extensions
{
    public static class InverseMatrixExtension
    {
        //TODO Add Error Description
        public static Matrix.Matrix Inverse(this Matrix.Matrix matrix)
        {
            int matrixRows = matrix.Rows;
            
            double[][] result = DuplicateMatrixStorage(matrix);
            double[][] disassembledMatrix = ParseMatrix(matrix, out int[] perm);

            if (disassembledMatrix == null)
                throw new Exception();

            double[] b = new double[matrixRows];
            for (int i = 0; i < matrixRows; i++)
            {
                for (int j = 0; j < matrixRows; j++)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }

                double[] x = Processing(disassembledMatrix, b);

                for (int j = 0; j < matrixRows; j++)
                {
                    result[j][i] = x[j];
                }
            }

            return new Matrix.Matrix(result);
        }

        private static double[][] DuplicateMatrixStorage(Matrix.Matrix matrix)
        {
            double[][] result = new double[matrix.Rows][];
            
            for (int i = 0; i < matrix.Columns; i++)
            {
                result[i] = new double[matrix.Columns];
            }
            
            matrix.InteractionWithData((i, j) =>
            {
                result[i][j] = matrix.GetElement(i, j);
            });
            
            return result;
        }

        //TODO Add Error Description
        private static double[][] ParseMatrix(Matrix.Matrix matrix, out int[] perm)
        {
            if (matrix.Rows != matrix.Columns)
                throw new Exception();

            int n = matrix.Rows; 

            double[][] result = DuplicateMatrixStorage(matrix);

            perm = new int[n];
            for (int i = 0; i < n; i++)
            {
                perm[i] = i;
            }

            for (int j = 0; j < n - 1; j++) 
            {
                double largestValueInColumn = Math.Abs(result[j][j]); 
                int pRow = j;

                for (int i = j + 1; i < n; i++)
                {
                    if (Math.Abs(result[i][j]) <= largestValueInColumn)
                        continue;

                    largestValueInColumn = Math.Abs(result[i][j]);
                    pRow = i;
                }

                if (pRow != j) 
                {
                    (result[pRow], result[j]) = (result[j], result[pRow]);
                    (perm[pRow], perm[j]) = (perm[j], perm[pRow]);
                }

                if (result[j][j] == 0.0)
                {
                    int targetRow = -1;
                    
                    for (int row = j + 1; row < n; row++)
                    {
                        if (result[row][j] != 0.0)
                            targetRow = row;
                    }

                    if (targetRow == -1)
                        throw new Exception();

                    (result[targetRow], result[j]) = (result[j], result[targetRow]);
                    (perm[targetRow], perm[j]) = (perm[j], perm[targetRow]);
                }

                for (int i = j + 1; i < n; i++)
                {
                    result[i][j] /= result[j][j];
                    
                    for (int k = j + 1; k < n; k++)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }
            } 

            return result;
        }
        
        private static double[] Processing(double[][] luMatrix, double[] b)
        {
            int n = luMatrix.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; i++)
            {
                double sum = x[i];
                
                for (int j = 0; j < i; j++)
                {
                    sum -= luMatrix[i][j] * x[j];
                }

                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];
            
            for (int i = n - 2; i >= 0; i--)
            {
                double sum = x[i];
                
                for (int j = i + 1; j < n; ++j)
                {
                    sum -= luMatrix[i][j] * x[j];
                }

                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }
    }
}