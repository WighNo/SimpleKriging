using System.Collections.Generic;

namespace Core.Variogram
{
    public abstract class VariogramBase
    {
        public double Range { get; protected set; }

        public abstract void Create(List<Point3D> points);
    }
}