using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Core.Interfaces;

namespace Core
{
    public class DefaultMapSaver : ISaver<Point3D[][]>
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        
        private readonly string _savePath;

        public DefaultMapSaver(string savePath)
        {
            _savePath = Path.Combine(Directory.GetCurrentDirectory(), "output.xyz");
            _savePath = Path.ChangeExtension(_savePath, "xyz");
        }
        
        public void Save(Point3D[][] saveObject)
        {
            for (int i = 0; i < saveObject.Length; i++)
            {
                for (int j = 0; j < saveObject[i].Length; j++)
                {
                    double positionZ = saveObject[i][j].Position.Z;

                    if (double.IsNaN(positionZ)) 
                        continue;
                    
                    _stringBuilder.Append(positionZ.ToString(CultureInfo.InvariantCulture));
                    _stringBuilder.Append(", ");
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(_savePath))
            {
                streamWriter.Write(_stringBuilder);
            }

            Process.Start(_savePath);
        }
    }
}