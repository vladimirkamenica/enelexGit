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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using enelex3.FrontEndMethods;
using LiveCharts.Configurations;
using LiveCharts.Helpers;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Collections.ObjectModel;

namespace enelex3
{
    /// <summary>
    /// Interaction logic for Graph1.xaml
    /// </summary>
    public partial class Graph1 : Window
    {
        public Graph1(ObservableCollection<MeasuresView> input, double p, double q)
        {
            InitializeComponent();
            Grafik1.SetMeasureViewToGraph(input, p, q);          
        }

        public Graph1(ObservableCollection<MeasuresView> input, double p, double q, double NumP)
        {
            InitializeComponent();
            Grafik1.SetMeasureViewToGraph(input, p, q, NumP);
        }

        public Graph1(ObservableCollection<MeasuresView> input, double p, double q, double Ps, double Qs)
        {
            InitializeComponent();
            Grafik1.SetMeasureViewToGraph1(input, p, q, Ps, Qs);
        }
    }
}

    











        

       

        
    

