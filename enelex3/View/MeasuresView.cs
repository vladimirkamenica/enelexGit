using enelex3.FrontEndMethods;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace enelex3
{

    public class MeasuresView : INotifyPropertyChanged
    {
       

        public long ID { get; set; }
        public double Index { get; set; }

        public long Number { get; set; }

        public double Ge { get; set; }

        public double Lab { get; set; }

        public double GeAsh { get; set; }

        public double LabAsh { get; set; }

        public double W { get; set; }

        public string Description { get; set; }

        public double SumMeasure
        {

            get
            {
                return Ge * Lab;
            }
        }

        public double SumGe
        {

            get
            {
                return Ge * Ge;
            }
        }

        public double P { get; set; }
        
        public bool Save { get; set; }

        private bool _IsSelected { get; set; }
        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                if(_IsSelected != value)
                {
                    _IsSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

