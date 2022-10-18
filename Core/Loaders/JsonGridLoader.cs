using Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Core.Loaders
{
    public class JsonGridLoader : ILoader<Point3D[][]>
    {
        private readonly string _loadPath;
        
        public JsonGridLoader(string loadPath)
        {
            _loadPath = loadPath;
        }
        
        //TODO Add Exception Descriptions
        public Point3D[][] Load()
        {
            JsonGridSettings gridSettings = ReadJson();
            Point3D[][] result = null;

            int stepX = gridSettings.StepX <= 0 ? throw new ArgumentException() : gridSettings.StepX;
            int stepY = gridSettings.StepY <= 0 ? throw new ArgumentException() : gridSettings.StepY;
            
            result = new Point3D[stepX][];
            
            Vector3 area = gridSettings.MaximumPosition - gridSettings.MinimumPosition;
            Vector3 nodeSize = new Vector3(area.X / stepX, area.Y / stepY, area.Z);
            
            for (int i = 0; i < stepX; i++)
            {
                for (int j = 0; j < stepY; j++)
                {
                    
                }
            }
            
            return result;
        }

        private JsonGridSettings ReadJson()
        {
            string json = null;
            
            using (StreamReader streamReader = new StreamReader(_loadPath))
            {
                json = streamReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<JsonGridSettings>(json) ?? throw new NullReferenceException();
        }
        
        private class JsonGridSettings
        {
            public Vector3 MinimumPosition { get; set; }
            
            public Vector3 MaximumPosition { get; set; }
            
            public int StepX { get; set; }
            
            public int StepY { get; set; }

            public List<Point3D> InterpolatePoints { get; set; }

            public override string ToString()
            {
                return JsonConvert.SerializeObject(new JsonGridSettings(), Formatting.Indented);
            }
        }
    }
}