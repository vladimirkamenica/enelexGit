using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.Base;
using enelex3.CalculatingErrorPercentage;
using enelex3.ViewModel;

namespace enelex3.View
{
    public class TrainTableView : ViewModelBase
    {
        public int Id { get; set; }

        public DateTime DateRecords { get; set; }

        public DateTime DateRecordsAdd { get => DateTime.Now; }

        public int NumberTrain { get; set; }

        public double MoistureLabTam { get; set; }

        public double MoistureLabTent { get; set; }

        public double Moisture { get; set; }

        public double AshLabTam { get; set; }

        public double AshLabTent { get; set; }

        public double AshGE { get; set; }

        public double CalorificLabTam { get; set; }

        public double CalorificLabTent { get; set; }

        public double CalorificGE { get; set; }

        public Shift ShiftWork { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public bool IsActive { get; set; }

        public bool Edit { get; set; }

        public bool ErrorCalibration
        {
            get
            {
                if (ErrorCalorific > 5) return true;
                else return false;
            }
        }
        public bool ErrorAshBool
        {
            get
            {
                if (ErrorAsh > 5) return true;
                else return false;
            }
        }
        public bool ErrorMoistureBool
        {
            get
            {
                if (ErrorMoisture > 5) return true;
                else return false;
            }
        }
        public double ErrorCalorific { get => ErrorPercentage.Error(CalorificGE,CalorificLabTam); }
       
        public double ErrorAsh { get => ErrorPercentage.Error(AshGE, AshLabTam); }
        
        public double ErrorMoisture { get => ErrorPercentage.Error(Moisture, MoistureLabTam); }
       
        private bool isNewItem { get; set; }
        public bool IsNewItem
        {
            get => isNewItem;
            set
            {
                if(isNewItem != value)
                {
                    isNewItem = value;
                    OnPropertyChanged(nameof(IsNewItem));
                }
            }
        }
        private bool isSelected { get; set; }
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
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
    }
}
