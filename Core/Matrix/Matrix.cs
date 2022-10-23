using System;

namespace Core.Matrix
{
    public class Matrix : MatrixBase
    {
        private readonly double[][] _storage;

        public Matrix(int size) : base(size, size)
        {
            _storage = new double[Rows][];
            CreateEmptyStorage();
        }
        
        public Matrix(int rows, int columns) : base(rows, columns)
        {
            _storage = new double[Rows][];
            CreateEmptyStorage();
        }
        
        public Matrix(double[][] source) : base(source.Length, source[0].Length)
        {
            _storage = new double[Rows][];
            
            CreateEmptyStorage();
            Fill(source);
        }

        public double GetElement(int line, int column) => _storage[line][column];

        private void CreateEmptyStorage()
        {
            for (int i = 0; i < Rows; i++)
            {
                _storage[i] = new double[Columns];
            }
        }
        
        public void Fill(double[] source)
        {
            int size = Rows * Columns;

            if (size != source.Length)
                throw new InvalidOperationException();

            for (int index = 0; index < Rows; index++)
            {
                for (int i = 0; i < Columns; i++)
                {
                    _storage[index][i] = source[i + index * Rows];
                }
            }
        }

        public void Fill(double[][] source)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _storage[i][j] = source[i][j];
                }
            }
        }

        public void InteractionWithData(Action<int, int> action)
        {
            for(var i = 0; i < Rows; i++)
            {
                for(var j = 0; j < Columns; j++)
                {
                    action?.Invoke(i, j);
                }
            }
        }

        public static Matrix operator *(Matrix source, Matrix target)
        {
            if (source.Columns != target.Rows)
                throw new InvalidOperationException("Невозможно умножить матрицы");
            
            double[][] result = new double[source.Rows][];
            
            for (int i = 0; i < source.Rows; i++)
            {
                result[i] = new double[target.Columns];

                for (int j = 0; j < target.Columns; j++)
                {
                    for (int k = 0; k < target.Rows; k++)
                    {
                        result[i][j] += source.GetElement(i, k) * target.GetElement(k, j);
                    }
                }
            }

            Matrix matrix = new Matrix(target.Columns, target.Rows);
            matrix.Fill(result);
            
            return matrix;
        }
    }
}