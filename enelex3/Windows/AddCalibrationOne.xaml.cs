﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace enelex3
{
    /// <summary>
    /// Interaction logic for AddCalibrationOne.xaml
    /// </summary>
    public partial class AddCalibrationOne : Window
    {
        private Model1 db = new Model1();
        public CalibrationProportionShifting resOne = new CalibrationProportionShifting();
        bool Save = false;

        public AddCalibrationOne()
        {
            InitializeComponent();
            DataContext = resOne;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Save = true;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Save) resOne = null;
        }
    }
}