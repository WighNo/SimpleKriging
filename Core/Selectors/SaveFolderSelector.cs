using System.Windows.Forms;
using Core.Interfaces;

namespace Core.Selectors
{
    public class SaveFolderSelector : ISelectorWithDialog
    {
        private readonly SaveFileDialog _saveFileDialog = new SaveFileDialog();
        
        public string Select(string title, string filter = null, bool multiselect = false)
        {
            _saveFileDialog.Reset();
            _saveFileDialog.Title = title;
            _saveFileDialog.Filter = filter;

            _saveFileDialog.RestoreDirectory = true;

            using (_saveFileDialog)
            {
                while (true)
                {
                    if (_saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        return _saveFileDialog.FileName;
                    }
                }
            }
        }
    }
}