using System.Windows.Forms;
using Core.Interfaces;

namespace Core.Selectors
{
    public class FileSelector : ISelectorWithDialog
    {
        private readonly OpenFileDialog _fileDialog = new OpenFileDialog();
        
        public string Select(string title, string filter, bool multiselect = false)
        {
            _fileDialog.Reset();
            
            _fileDialog.Multiselect = multiselect;
            _fileDialog.Title = title;
            _fileDialog.Filter = filter;

            using (_fileDialog)
            {
                while (true)
                {
                    if (_fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        return _fileDialog.FileName;
                    }
                }
            }
        }
    }
}