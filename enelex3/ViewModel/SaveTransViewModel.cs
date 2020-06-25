using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;
using System.Collections.ObjectModel;
using enelex3.FrontEndMethods;
using enelex3.Helpers;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using enelex3.Base;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using enelex3.Helpers;

namespace enelex3.ViewModel
{
    public class SaveTransViewModel : INotifyPropertyChanged
    {
        Model1 db = new Model1();
        List<MeasuresView> ListOfMeasures;
        private SaveMeasure save;
        public SaveMeasure Save
        {
            get => save;
            set
            {
                if(save != value)
                {
                    save = value;
                    OnPropertyChanged(nameof(Save));
                }
            }
        }

        public SaveTransViewModel(List<MeasuresView> listOfMeasures)
        {
            Load();
            Save = new SaveMeasure() { DateOfCalibration = DateTime.Now };
            ListOfMeasures = listOfMeasures;
        }
        private double count { get; set; }
        public double Count
        {
            get => count;
            set
            {
                if (count != value)
                {
                    count = value;
                    OnPropertyChanged(nameof(Count));
                }
            }
        }
        private MeasuresFE mfe = new MeasuresFE();
        private List<SaveMeasureViews> GetSaveMeasure { get; set; } = new List<SaveMeasureViews>();
        private ObservableCollection<SaveMeasureViewGroup> getSaveMeasureGroup { get; set; }

        public ObservableCollection<SaveMeasureViewGroup> GetSaveMeasureGroup
        {
            get => getSaveMeasureGroup;
            set
            {
                if (getSaveMeasureGroup != value)
                {
                    getSaveMeasureGroup = value;
                    OnPropertyChanged(nameof(GetSaveMeasureGroup));
                }
            }
        }
        private void Load()
        {
            GetSaveMeasure = mfe.GetSaveMeasureViews();
            GetSaveMeasureGroup = new ObservableCollection<SaveMeasureViewGroup>();
            GetSaveMeasureGroup.Clear();
            GetSaveMeasureGroup = mfe.GetViewGroups(GetSaveMeasure).ToObservable();
            Count = GetSaveMeasureGroup.Count() + 1; ;
        }
        public ICommand SaveMeasureCommand => new RelayCommand<Window>(SaveMeasure);
        private void SaveMeasure(Window win)
        {
            
            foreach (var x in ListOfMeasures)
            {
                if (x != null)
                {
                    save.GroupID = GetSaveMeasureGroup.Count() + 1;
                    save.Ge = x.Ge;
                    save.Lab = x.Lab;
                    save.W = x.W;
                    if (save != null)
                    {
                        db.SaveMeasures.Add(save);
                        db.SaveChanges();
                    }

                }
            }
            win.Close();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
