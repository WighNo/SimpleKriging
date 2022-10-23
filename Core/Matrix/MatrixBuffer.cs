using System.Collections.Generic;

namespace Core.Matrix
{
    public class MatrixBuffer<T> where T : MatrixBase
    {
        private readonly int _capacity;
        
        private readonly int _row;
        private readonly int _column;
        
        private readonly List<T> _storage;

        public MatrixBuffer(int capacity, int matrixRowCount, int matrixColumnCount)
        {
            _capacity = capacity;
            
            _row = matrixRowCount;
            _column = matrixColumnCount;
            
            _storage = new List<T>(_capacity);
        }

        /*public void Init() 
        { 
            if(_storage.Count == _capacity)
                return;

            for (int i = 0; i < _capacity; i++)
            {
                T matrix = new T();
                _storage.Add(matrix as T);
            }
        }}*/
    }
}