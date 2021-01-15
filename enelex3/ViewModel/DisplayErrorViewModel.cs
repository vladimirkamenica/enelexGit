using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace enelex3.ViewModel
{
    public class DisplayErrorViewModel : ViewModelBase
    {
        public DisplayErrorViewModel()
        {

        }
        public Action LoadAbsolute { get; set; }
        private double shiftAbsolute{ get; set; }
        public double ShiftAbsolute
        {
            get => shiftAbsolute;
            set
            {
                if (shiftAbsolute != value)
                {
                    shiftAbsolute = value;
                    OnPropertyChanged(nameof(ShiftAbsolute));
                }
            }
        }
        private double shiftProportional{ get; set; }
        public double ShiftProportional
        {
            get => shiftProportional;
            set
            {
                if (shiftProportional != value)
                {
                    shiftProportional = value;
                    OnPropertyChanged(nameof(ShiftProportional));
                }
            }
        }
        private double error_Calibration { get; set; }
        public double Error_Calibration
        {
            get => error_Calibration;
            set
            {
                if (error_Calibration != value)
                {
                    error_Calibration = value;
                    OnPropertyChanged(nameof(Error_Calibration));
                }
            }
        }
        public bool BoolShiftAbsolute
        {
            get => Properties.Settings.Default.Shift_Absolute;
            set
            {
                Properties.Settings.Default.Shift_Absolute = value;
                OnPropertyChanged(nameof(BoolShiftAbsolute));
                CheckAbsoluteShift();
                LoadAbsolute?.Invoke();

            }
        }
        public bool BoolShiftProportional
        {
            get => Properties.Settings.Default.Shift_Proportional;
            set
            {
                Properties.Settings.Default.Shift_Proportional = value;
                OnPropertyChanged(nameof(BoolShiftProportional));


            }
        }
        public double SettingsProportionShift
        {
            get => Properties.Settings.Default.Shift_Proportion_K;
            set
            {
                Properties.Settings.Default.Shift_Proportion_K = value;

                OnPropertyChanged(nameof(SettingsProportionShift));
            }
        }
        public double SettingsAbsoluteCalibration
        {
            get => Properties.Settings.Default.Shift_Absolute_K;
            set
            {
                Properties.Settings.Default.Shift_Absolute_K = value;
                OnPropertyChanged(nameof(SettingsAbsoluteCalibration));
                CheckAbsoluteShift();
                LoadAbsolute?.Invoke();
            }
        }
        public double CheckAbsoluteShift()
        {
            if (BoolShiftAbsolute) return Error_Calibration;
            else return SettingsAbsoluteCalibration;
        }
        public double CheckProportionalShift()
        {
            if (BoolShiftProportional) return Error_Calibration;
            else return SettingsProportionShift;
        }
    }
}
