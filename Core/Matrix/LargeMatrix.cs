namespace Core.Matrix
{
    public class LargeMatrix<T> : MatrixBase where T : struct
    {
        public LargeMatrix(int rows, int columns) : base(rows, columns)
        {
    
        }
        
        public LargeMatrixStorage Storage { get; private set; }
    }
}