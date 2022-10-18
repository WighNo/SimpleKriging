using System.Threading.Tasks;
using Core.Interfaces;

namespace Core
{
    public class DefaultMapSaver : ISaver<Point3D[][]>
    {
        private readonly string _savePath;

        public DefaultMapSaver(string savePath)
        {
            _savePath = savePath;
        }
        
        public void Save(Point3D[][] saveObject)
        {
            throw new System.NotImplementedException();
        }
    }
}