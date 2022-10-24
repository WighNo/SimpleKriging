using Core.Interfaces;

namespace Core.Generators
{
    public class AllNodesMaskMapGenerator : IGenerator<bool[][]>
    {
        private readonly Point3D[][] _map;
        
        public AllNodesMaskMapGenerator(Point3D[][] map)
        {
            _map = map;
        }
        
        public bool[][] Generate()
        {
            bool[][] mask = new bool[_map.Length][];
            for (var i = 0; i < _map.Length; i++)
            {
                mask[i] = new bool[_map[i].Length];
                for (var j = 0; j < _map[i].Length; j++)
                {
                    mask[i][j] = true;
                }
            }

            return mask;
        }
    }
}