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

        private readonly ArgumentException _stepArgumentException =
            new ArgumentException("Grid spacing in X or Y cannot be less than or equal to zero");
        
        public JsonGridLoader(string loadPath)
        {
            _loadPath = loadPath;
        }
        
        public Point3D[][] Load()
        {
            JsonGridSettings gridSettings = ReadJson();

            return gridSettings.Points;
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
            public Point3D[][] Points { get; set; }

            public override string ToString()
            {
                return JsonConvert.SerializeObject(new JsonGridSettings(), Formatting.Indented);
            }
        }
    }
}