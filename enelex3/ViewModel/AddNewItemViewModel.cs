using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.ViewModel;
using enelex3.Base;
using enelex3.View;
using enelex3.Helpers;
using enelex3.FrontEndMethods;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using enelex3.CalculatingErrorPercentage;

namespace enelex3.ViewModel
{
    public class AddNewItemViewModel : ViewModelBase
    {
        Model1 db = new Model1();
        private TrainTable trainTableAdd { get; set; } = new TrainTable();
        public TrainTable TrainTableAdd
        {
            get => trainTableAdd;
            set
            {
                if(trainTableAdd != value)
                {
                    trainTableAdd = value;
                    OnPropertyChanged(nameof(TrainTableAdd));
                }
            }
        }
        private Action Load { get; set; }
        public AddNewItemViewModel(Action load)
        {
            Load = load;
            ErrorMoinsture = 0;
            ErrorAsh = 0;
            ErrorCalorific = 0;
        }
        private TrainTableFE trfe = new TrainTableFE();
        private List<Shift> shiftsEnum;
        public List<Shift> ShiftsEnum
        {
            get => shiftsEnum = trfe.GetShifts();
            set
            {
                if (shiftsEnum != value)
                {
                    shiftsEnum = value;
                    OnPropertyChanged(nameof(ShiftsEnum));
                }
            }
        }
        private Shift selectedShiftsEnum;
        public Shift SelectedShiftsEnum
        {
            get => selectedShiftsEnum;
            set
            {
                if (selectedShiftsEnum != value)
                {
                    selectedShiftsEnum = value;
                    OnPropertyChanged(nameof(SelectedShiftsEnum));
                }
            }
        }
        private double errorMoisture { get; set; }
        public double ErrorMoinsture
        {
            get => errorMoisture;
            set
            {
                if(errorMoisture != value)
                {
                    errorMoisture = value;
                    OnPropertyChanged(nameof(ErrorMoinsture));
                }
            }
        }
        private double errorAsh{ get; set; }
        public double ErrorAsh
        {
            get => errorAsh;
            set
            {
                if (errorAsh != value)
                {
                    errorAsh = value;
                    OnPropertyChanged(nameof(ErrorAsh));
                }
            }
        }
        private double errorCalorific { get; set; }
        public double ErrorCalorific
        {
            get => errorCalorific;
            set
            {
                if (errorCalorific != value)
                {
                    errorCalorific = value;
                    OnPropertyChanged(nameof(ErrorCalorific));
                }
            }
        }
        public ICommand AddCommand => new RelayCommand(AddToBase);
        private void AddToBase()
        {
           if(TrainTableAdd != null)
            {
                TrainTableAdd.LastUpdatedOn = DateTime.Now;
                TrainTableAdd.IsActive = true;
                TrainTableAdd.ShiftWork = SelectedShiftsEnum;
                db.TrainTables.Add(TrainTableAdd);
                db.SaveChanges();
                Load?.Invoke();
                TrainTableAdd = null;
                TrainTableAdd = new TrainTable();
            }
        }
        public ICommand ErrorCommand => new RelayCommand(Error);
        private void Error()
        {
            if (TrainTableAdd.MoistureLabTam != null && TrainTableAdd.Moisture != null)
            {
                ErrorMoinsture = ErrorPercentage.Error(TrainTableAdd.Moisture, TrainTableAdd.MoistureLabTam);
            }
            if (TrainTableAdd.AshGE != null && TrainTableAdd.AshLabTam != null)
            {
                ErrorAsh = ErrorPercentage.Error(TrainTableAdd.AshGE, TrainTableAdd.AshLabTam);
            }
            if (TrainTableAdd.CalorificLabTam != null && TrainTableAdd.CalorificGE != null)
            {
                ErrorCalorific = ErrorPercentage.Error(TrainTableAdd.CalorificGE, TrainTableAdd.CalorificLabTam);
            }
        }
    }
}
