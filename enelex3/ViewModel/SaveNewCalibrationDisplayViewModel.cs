using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;
using enelex3.FrontEndMethods;
using enelex3.Helpers;

namespace enelex3.ViewModel
{
    public class SaveNewCalibrationDisplayViewModel : ViewModelBase
    {
        public SaveNewCalibrationDisplayViewModel()
        {

        }
        private ObservableCollection<TypeCalibrationViews> listOftype { get; set; }
        public ObservableCollection<TypeCalibrationViews> ListOfType
        {
            get => listOftype;
            set
            {
                if (listOftype != value)
                {
                    listOftype = value;
                    OnPropertyChanged(nameof(ListOfType));
                }
            }
        }
        private TypeCalibrationViews selectedListOftype { get; set; }
        public TypeCalibrationViews SelectedListOfType
        {
            get => selectedListOftype;
            set
            {
                if (selectedListOftype != value)
                {
                    selectedListOftype = value;
                    if(selectedListOftype != null)
                    {
                        Description = selectedListOftype.Description;
                        DateCalibration = selectedListOftype.DateCalibration;
                    }
                    OnPropertyChanged(nameof(SelectedListOfType));
                   
                }
            }
        }
        private string description { get; set; }
        public string Description
        {
            get => description;
            set
            {
                if(description != value)
                {
                    description = value;
                    if (SelectedListOfType != null)
                    {
                        SelectedListOfType.Description = description;
                       
                    }
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        private DateTime dateCalibration { get; set; }
        public DateTime DateCalibration
        {
            get => dateCalibration;
            set
            {
                if (dateCalibration != value)
                {
                    dateCalibration = value;
                    if (SelectedListOfType != null)
                    {
                        SelectedListOfType.DateCalibration = dateCalibration;

                    }
                    OnPropertyChanged(nameof(DateCalibration));
                }
            }
        }
        private int selectedIdexType { get; set; }
        public int SelectedIdexType
        {
            get => selectedIdexType;
            set
            {
                if (selectedIdexType != value)
                {
                    selectedIdexType = value;
                    OnPropertyChanged(nameof(SelectedIdexType));
                }
            }
        }
    }
}
