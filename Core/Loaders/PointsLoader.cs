using Core.Interfaces;
using System.Collections.Generic;
using System.IO;

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
            List<Point3D> result = new List<Point3D>();

            string[] data = ParseData();
            DefinePoints(data, result);
            
            return result;
        }

        private string[] ParseData()
        {
            using (StreamReader streamReader = new StreamReader(_loadPath))
            {
                string content = streamReader.ReadToEnd();
                return content.Split('\n', ' ', '\t');
            }
        }

        private List<Point3D> DefinePoints(in string[] data, List<Point3D> source)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (i % 3 != 0)
                    continue;

                double x = StringToDouble(data[i]);
                double y = StringToDouble(data[i + 1]);
                double z = StringToDouble(data[i + 2]);
                
                source.Add(new Point3D(x, y, z));
            }
            
            return source;
        }

        private double StringToDouble(string value)
        {
            return double.Parse(value.Replace('.', ','));
        }
    }
}