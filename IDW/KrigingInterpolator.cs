using System.Collections.Generic;
using Core;
using Core.Interfaces;

namespace IDW
{
    public class KrigingInterpolator : IInterpolator
    {
        public bool Interpolate(Point3D[][] map, List<Point3D> points, bool[][] calculatingMask, IInterpolationOptions options)
        {
            return false;
        }
    }
}