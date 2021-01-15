using System.Windows.Input;

namespace enelex3.Helpers.Excel
{
    internal class ExcelActionsCommandInfo
    {
        public ICommand CopyAllCommmand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand PasteCommand { get; set; }

    }
}