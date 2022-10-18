using System.Windows.Forms;
using Core.Interfaces;

namespace Core.Selectors
{
    public class FolderSelector : ISelectorWithDialog
    {
        private readonly FolderBrowserDialog _folderBrowser = new FolderBrowserDialog();
        
        public string Select(string title, string filter = null, bool multiselect = false)
        {
            _folderBrowser.Reset();
            _folderBrowser.Description = title;
            
            using (_folderBrowser)
            {
                while (true)
                {
                    if (_folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        return _folderBrowser.SelectedPath;
                    }
                }
            }
        }
    }
}