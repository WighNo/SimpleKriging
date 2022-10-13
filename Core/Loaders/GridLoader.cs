using Core.Interfaces;

namespace Core.Loaders
{
    public class GridLoader : ILoader<Point3D[][]>
    {
        private readonly string _loadPath;

        public GridLoader(string loadPath)
        {
            _loadPath = loadPath;
        }
        
        public Point3D[][] Load()
        {
            throw new System.NotImplementedException();
        }
    }
}