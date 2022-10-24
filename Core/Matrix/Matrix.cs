using System;

namespace Core.Matrix
{
    public class Matrix
    {
        private readonly double[][] _storage;

        public Matrix(int size)
        {
            Rows = size;
            Columns = size;
            
            _storage = new double[Rows][];
            CreateEmptyStorage();
        }
        
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            
            _storage = new double[Rows][];
            CreateEmptyStorage();
        }
        
        public Matrix(double[][] source)
        {
            Rows = source.Length;
            Columns = source[0].Length;
            
            _storage = new double[Rows][];
            
            CreateEmptyStorage();
            Fill(source);
        }

        public int Rows { get; }
        
        public int Columns { get; }
        
        public double GetElement(int row, int column) => _storage[row][column];

        public bool SetElement(int row, int column, double value)
        {
            if (row > _storage.Length || column > _storage[row].Length)
                return false;
            
            _storage[row][column] = value;
            
            return true;
        }

        private void CreateEmptyStorage()
        {
            for (int i = 0; i < Rows; i++)
            {
                _storage[i] = new double[Columns];
            }
        }
        
        public void Fill(double[][] source)
        {
            if (source.Length != _storage.Length)
                throw new ArgumentException();
            
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

        [Obsolete("Дорого")]
        public static Matrix operator *(Matrix source, Matrix target)
        {
            if (source.Columns != target.Rows)
                throw new InvalidOperationException("Невозможно умножить матрицы");
            
            double[][] result = new double[target.Rows][];
            
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

            Matrix matrix = new Matrix(target.Rows, target.Columns);
            matrix.Fill(result);
            
            return matrix;
        }
        
        public static Matrix operator /(Matrix mat, double val)
        {
            double[][] result = new double[mat.Rows][];
            
            for (int i = 0; i < mat.Rows; i++)
            {
                result[i] = new double[mat.Columns];
                
                for (int j = 0; j < mat.Columns; j++)
                {
                    result[i][j] = mat.GetElement(i, j)/val;

                }
            }
            
            return new Matrix(result);
        }

    }
}