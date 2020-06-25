using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using enelex3.ViewModel;
using enelex3.View;
using System.Collections.ObjectModel;
using enelex3.FrontEndMethods;
using enelex3.Helpers;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using System.Windows;
using enelex3.UserControls;

namespace enelex3.ViewModel
{
    public class SaveMeasureViewModel : INotifyPropertyChanged
    {
        Model1 db = new Model1();
        public Action LoadAction { get; set; }
        public SaveMeasureViewModel(Action load)
        {
            LoadAction = load;
        }
        private ScatterLineGraph scatterGraph;
        public ScatterLineGraph ScatterGraph
        {
            get => scatterGraph;
            set
            {
                if(scatterGraph != value)
                {
                    scatterGraph = value;
                    OnPropertyChanged(nameof(ScatterGraph));
                }
            }
        }

        private MeasuresFE mfe;
        private List<SaveMeasureViews> getSaveMeasure { get; set; }

        public List<SaveMeasureViews> GetSaveMeasure
        {
            get => getSaveMeasure;
            set
            {
                if(getSaveMeasure != value)
                {
                    getSaveMeasure = value;
                    OnPropertyChanged(nameof(GetSaveMeasure));
                }
            }
        }
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
        private SaveMeasureViewGroup selectedGetSaveMeasureGroup;

        public SaveMeasureViewGroup SelectedGetSaveMeasureGroup
        {
            get => selectedGetSaveMeasureGroup;
            set
            {
                if (selectedGetSaveMeasureGroup != value)
                {
                    selectedGetSaveMeasureGroup = value;
                    OnPropertyChanged(nameof(SelectedGetSaveMeasureGroup));
                }
            }
        }
        private List<MeasuresView> GetMeasuresViews { get; set; } = new List<MeasuresView>();
        public ICommand LoadCommand => new RelayCommand(Load);
        private void Load()
        {
            db = new Model1();
            mfe = new MeasuresFE(db);
            GetSaveMeasure = new List<SaveMeasureViews>();
            GetSaveMeasure.Clear();
            GetSaveMeasure = mfe.GetSaveMeasureViews();
            GetSaveMeasureGroup = new ObservableCollection<SaveMeasureViewGroup>();
            GetSaveMeasureGroup.Clear();
            GetSaveMeasureGroup = mfe.GetViewGroups(GetSaveMeasure).ToObservable();
           
           
           
             
        }

        public ICommand DelMeasureCommand => new RelayCommand(DelMeasure);
        private void DelMeasure()
        {
            if (MessageBox.Show("Da li ste sigurni?", "Eneleks 1.0", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {

            }
            else
            {
                List<long> ids = new List<long>();

                foreach (var x in GetSaveMeasure)
                {
                    var id = x.Id;
                    ids.Add(id);
                }
                foreach (var id in ids)
                {
                    var izbaze = db.SaveMeasures.Find(id);
                    db.SaveMeasures.Remove(izbaze);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greska u podacima");
                    }
                    GetSaveMeasure.Remove(GetSaveMeasure.FirstOrDefault(x => x.Id == id));
                }
                Load();
            }
        }
        public ICommand SaveCommand => new RelayCommand(Save);
        public void Save()
        {
            Measure measure = new Measure();
            foreach(var x in SelectedGetSaveMeasureGroup.Details)
            {
                if(x != null)
                {
                    measure.Ge = x.Ge;
                    measure.Lab = x.Lab;
                    measure.W = x.W;
                    if(measure != null)
                    {
                        db.Measures.Add(measure);
                        db.SaveChanges();
                    }
                }
            }
            LoadAction?.Invoke();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
