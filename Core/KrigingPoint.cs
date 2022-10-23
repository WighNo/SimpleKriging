namespace Core
{
    public class KrigingPoint
    {
        private readonly Point3D _source;

        public KrigingPoint(Point3D source)
        {
            _source = source;
        }

        public Matrix.Matrix Matrix { get; set; }
    }
}