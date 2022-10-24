using Core.Interfaces;

namespace Core.Generators
{
    public class DefaultParamGenerator : IGenerator<Point3D[][]>
    {
        public Point3D[][] Generate()
        {
            var nx = 460;
            var ny = 800;
            var xStep = 50.0;
            var yStep = 50.0;
            var xMin = 309000.0;
            var yMin = 827000.0;
            var xMax = xMin + (nx - 1) * xStep;
            var yMax = yMin + (ny - 1) * yStep;

            var map = new Point3D[nx][];         
            for (var i = 0; i < nx; i++)
            {
                map[i] = new Point3D[ny];
                for (var j = 0; j < ny; j++)
                {
                    map[i][j] = new Point3D(xMin + xStep * i, yMin + yStep * j, double.NaN);
                }
            }

            return map;
        }
    }
}