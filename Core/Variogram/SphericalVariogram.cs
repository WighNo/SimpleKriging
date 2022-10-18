using System.Collections.Generic;

namespace Core.Variogram
{
    public class SphericalVariogram : VariogramBase
    {
        //TODO Replace with calculation
        public SphericalVariogram()
        {
            Range = 4141;
        }

        public override void Create(List<Point3D> points)
        {
            throw new System.NotImplementedException();
        }
    }
}