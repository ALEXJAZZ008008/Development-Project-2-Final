using Microsoft.Win32;

namespace Scenarios.Core
{
    public class WindowsFileDialogFileSelector : IUserFileSelector
    {
        public string PromptUser()
        {
            string result; 

            OpenFileDialog dialog = new OpenFileDialog();
            bool? HasResult = dialog.ShowDialog();
            result = dialog.FileName;

            return result;
        }
    }
}
