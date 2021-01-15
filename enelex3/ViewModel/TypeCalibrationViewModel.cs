using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;
using enelex3.Helpers;
using enelex3.Base;
using enelex3.FrontEndMethods;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;

namespace enelex3.ViewModel
{
   public class TypeCalibrationViewModel : ViewModelBase
    {
        Model1 db;
        private Action LoadMainCombo { get; set; }
        public TypeCalibrationViewModel(Action loadMianCombo = null)
        {
            WidthExpander = 60;
            OpenExpander = true;
            CloseExpander = false;
            LoadMainCombo = loadMianCombo;
            Load();
        }
        private TypeCalibrationFE tcfe;

        private double widthExpander { get; set; }
        public double WidthExpander
        {
            get => widthExpander;
            set
            {
                if(widthExpander != value)
                {
                    widthExpander = value;
                    OnPropertyChanged(nameof(WidthExpander));
                }
            }
        }
        private bool openExpander { get; set; }
        public bool OpenExpander
        {
            get => openExpander;
            set
            {
                if (openExpander != value)
                {
                    openExpander = value;
                    OnPropertyChanged(nameof(OpenExpander));
                }
            }
        }
        private bool closeExpander { get; set; }
        public bool CloseExpander
        {
            get => closeExpander;
            set
            {
                if (closeExpander != value)
                {
                    closeExpander = value;
                    OnPropertyChanged(nameof(CloseExpander));
                }
            }
        }
        private TypeCalibration addType { get; set; } = new TypeCalibration();
        public TypeCalibration AddType
        {
            get => addType;
            set
            {
                if (addType != value)
                {
                    addType = value;
                    OnPropertyChanged(nameof(AddType));
                }
            }
        }
        private ObservableCollection<TypeCalibrationViews> listOfTypeCalibration { get; set; }
        public ObservableCollection<TypeCalibrationViews> ListOfTypeCalibration
        {
            get => listOfTypeCalibration;
            set
            {
                if(listOfTypeCalibration != value)
                {
                    listOfTypeCalibration = value;
                    OnPropertyChanged(nameof(ListOfTypeCalibration));
                }
            }
        }
        private TypeCalibrationViews selectedTypeCalibration { get; set; }
        public TypeCalibrationViews SelectedTypeCalibration
        {
            get => selectedTypeCalibration;
            set
            {
                if (selectedTypeCalibration != value)
                {
                    selectedTypeCalibration = value;
                    if(selectedTypeCalibration != null)
                    {
                        selectedTypeCalibration.Edit = true;
                    }
                    OnPropertyChanged(nameof(SelectedTypeCalibration));
                }
            }
        }
        public ICommand LoadCommand => new RelayCommand(Load);
        private void Load()
        {
            db = new Model1();
            tcfe = new TypeCalibrationFE(db);
            ListOfTypeCalibration = new ObservableCollection<TypeCalibrationViews>();
            ListOfTypeCalibration.Clear();
            ListOfTypeCalibration = tcfe.GetTypeCalibrationViews().ToObservable();
         
        }
        public ICommand OpenCommand => new RelayCommand(Open);
        private void Open()
        {
            OpenExpander = false;
            CloseExpander = true;
            WidthExpander = 300;
        }
        public ICommand CloseCommand => new RelayCommand(Close);
        private void Close()
        {
            OpenExpander = true;
            CloseExpander = false;
            WidthExpander = 60;
        }
        public ICommand AddCommand => new RelayCommand(Add);
        private void Add()
        {
           if(AddType != null)
            {
                db = new Model1();
                AddType.IsActive = true;
                AddType.LastOnUpdate = DateTime.Now;
                AddType.DateCalibration = DateTime.Now;
                AddType.Type = "Novi tip";
                db.TypeCalibrations.Add(AddType);
                db.SaveChanges();
                Load();
                AddType = new TypeCalibration();
                LoadMainCombo?.Invoke();
            }
        }
       
        public ICommand EditCommand => new RelayCommand(Edit);
        private void Edit()
        {
            foreach(var x in ListOfTypeCalibration.Where(x=> x.Edit).ToList())
            {
                if(x != null)
                {
                    SaveToBase.TypeSave.TypeSaveToBase(x, true, true);
                }
            }
            Load();
            LoadMainCombo?.Invoke();
        }
        public ICommand DelCommand => new RelayCommand(Del);
        private void Del()
        {
           
                if (SelectedTypeCalibration != null)
                {
                    SaveToBase.TypeSave.TypeSaveToBase(SelectedTypeCalibration, true, false);
                Load();
                LoadMainCombo?.Invoke();
            }
         
        }
    }
    
}
