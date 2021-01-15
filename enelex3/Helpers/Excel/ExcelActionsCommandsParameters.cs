using MoralesLarios.Utilities.Helper.BrushesHelper;
using System.Windows.Media;

namespace enelex3.Helpers.Excel
{
    internal class ExcelActionsCommandsParameters
    {
        public bool            ContainsHeader    { get; set; }
        public bool            ShowErrorMessages { get; set; }
        public bool            CancelWithErrors  { get; set; }
        public bool            PaintFlash        { get; set; }
        public SolidColorBrush ColorFlash        { get; set; }


    }
}