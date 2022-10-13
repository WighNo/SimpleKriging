using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Loaders
{
    public class PointsLoader : ILoader<List<Point3D>>
    {
        private readonly string _loadPath;

        public PointsLoader(string loadPath)
        {
            _loadPath = loadPath;
        }
        
        public List<Point3D> Load()
        {
            throw new System.NotImplementedException();
        }
    }
}