using System;

namespace Core
{
    public class Matrix
    {
        private readonly int _lines;
        private readonly int _columns;
        
        private readonly double[,] _storage;

        public Matrix(int size)
        {
            _lines = size;
            _columns = size;

            _storage = new double[_lines, _columns];
        }
        
        public Matrix(int lines, int columns)
        {
            _lines = lines;
            _columns = columns;

            _storage = new double[_lines, _columns];
        }

        public Matrix(double[,] source)
        {
            _lines = source.GetLength(0);
            _columns = source.GetLength(1);
            
            _storage = source;
        }

        public int Lines => _lines;

        public int Columns => _columns;

        public double GetElement(int line, int column) => _storage[line, column];

        public void Fill(double[] source)
        {
            int size = _lines * _columns;

            if (size != source.Length)
                throw new InvalidOperationException();

            for (int index = 0; index < _lines; index++)
            {
                for (int i = 0; i < _columns; i++)
                {
                    _storage[index, i] = source[i + index * _lines];
                }
            }
        }

        public Matrix ConvertToCovariance()
        {
            for (int i = 0; i < _lines; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    double h = _storage[i, j];
                    _storage[i, j] = Math.Round(Covariance(h), 2);
                }
            }

            return this;
        }

        private double Covariance(double h)
        {
            return 1 - 1.5 * (h / 4141) + 0.5 * Math.Pow(h / 4141, 3);
        }
        
        public void Invert()
        {
            if (_lines != _columns)
                throw new InvalidOperationException("Обратная матрица существует только для квадратных матриц");
            
            throw new NotImplementedException();
        }

        public static Matrix operator *(Matrix source, Matrix target)
        {
            if (source._columns != target._lines)
                throw new InvalidOperationException("Невозможно умножить матрицы");
            
            double[,] result = new double[source._lines, target._columns];
            
            for (int i = 0; i < source._lines; i++)
            {
                for (int j = 0; j < target._columns; j++)
                {
                    for (int k = 0; k < target._lines; k++)
                    {
                        result[i,j] += source.GetElement(i,k) * target.GetElement(k,j);
                    }
                }
            }
            
            return new Matrix(result);
        }
    }
}