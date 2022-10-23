using Core.Interfaces;

namespace IDW
{
    public class KrigingInterpolationOptions : IInterpolationOptions
    {
        public int ChunkSize => 400;

        public int GarbageСollectorStep => 25;
    }
}
