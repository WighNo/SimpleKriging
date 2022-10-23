namespace Core.Interfaces
{
    public interface IInterpolationOptions
    {
        int ChunkSize { get; }
        
        int GarbageСollectorStep { get; }
    }
}