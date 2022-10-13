namespace Core.Interfaces
{
    public interface ISaver<in T>
    {
        void Save(T saveObject);
    }
}