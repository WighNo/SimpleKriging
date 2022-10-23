namespace Core.Matrix
{
    public class MatrixBase
    {
        private readonly int _rows;
        private readonly int _columns;

        public MatrixBase(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }
        
        public int Rows => _rows;

        public int Columns => _columns;
    }
}