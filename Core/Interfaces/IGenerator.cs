namespace Core.Interfaces
{
    public interface IGenerator<out T>
    {
        T Generate();
    }
}