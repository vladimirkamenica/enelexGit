using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.ViewModel
{
   public class DisplayNewCalibrationsViewModel : ViewModelBase
    {
        public DisplayNewCalibrationsViewModel()
        {

        }
        private double result_A { get; set; }
        public double Result_A
        {
            get => result_A;
            set
            {
                if (result_A != value)
                {
                    result_A = value;
                    OnPropertyChanged(nameof(Result_A));
                }
            }
        }
        private double result_B { get; set; }
        public double Result_B
        {
            get => result_B;
            set
            {
                if (result_B != value)
                {
                    result_B = value;
                    OnPropertyChanged(nameof(Result_B));
                }
            }
        }
        private double result_W { get; set; }
        public double Result_W
        {
            get => result_W;
            set
            {
                if (result_W != value)
                {
                    result_W = value;
                    OnPropertyChanged(nameof(Result_W));
                }
            }
        }
        private double result_P1 { get; set; }
        public double Result_P1
        {
            get => result_P1;
            set
            {
                if (result_P1 != value)
                {
                    result_P1 = value;
                    OnPropertyChanged(nameof(Result_P1));
                }
            }
        }
        private double result_Q1 { get; set; }
        public double Result_Q1
        {
            get => result_Q1;
            set
            {
                if (result_Q1 != value)
                {
                    result_Q1 = value;
                    OnPropertyChanged(nameof(Result_Q1));
                }
            }
        }
        private double result_R1 { get; set; }
        public double Result_R1
        {
            get => result_R1;
            set
            {
                if (result_R1 != value)
                {
                    result_R1 = value;
                    OnPropertyChanged(nameof(Result_R1));
                }
            }
        }
        private bool visibleTXT { get; set; }
        public bool VisibleTXT
        {
            get => visibleTXT;
            set
            {
                visibleTXT = value;
                OnPropertyChanged(nameof(VisibleTXT));
            }
        }
        private bool visibleTXT2 { get; set; }
        public bool VisibleTXT2
        {
            get => visibleTXT2;
            set
            {
                visibleTXT2 = value;
                OnPropertyChanged(nameof(VisibleTXT2));
            }
        }
    }
}
