namespace Core.Interfaces
{
    public interface ISelectorWithDialog
    {
        string Select(string title, string filter = null, bool multiselect = false);
    }
}