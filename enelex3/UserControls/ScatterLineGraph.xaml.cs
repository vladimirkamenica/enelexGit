﻿using enelex3.FrontEndMethods;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace enelex3.UserControls
{
    /// <summary>
    /// Interaction logic for ScatterLineGraph.xaml
    /// </summary>
    public partial class ScatterLineGraph : UserControl
    {
        public object Mapper { get; set; }

        public ScatterLineGraph()
        {
            InitializeComponent();
        }

        public void SetMeasureViewToGraph(List<MeasuresView> input, double p, double q)
        {
            DataContext = this;
            ValuesA.Clear();

            if (input.Count > 0)
            {

                foreach (var x in input.OrderBy(z => z.Ge))
                {
                    ValuesA.Add(new ObservablePoint(x.Ge, x.Lab));


                }

            }
            ValuesB.Clear();
            if (ValuesA.Count > 1)
            {
                var prva = ValuesA.Min(x => x.X);
                var poslednja = ValuesA.Max(x => x.X);
                var q1 = q;
                var p1 = p;

                ValuesB.Add(new ObservablePoint(prva, p1 * prva - q1));
                ValuesB.Add(new ObservablePoint(poslednja, p * poslednja - q1));
            }
            //Graph.AxisX.Add(new Axis
            //{
            //   IsMerged = true,
            //    Separator = new LiveCharts.Wpf.Separator
            //    {

            //      //  IsEnabled = true,
            //        Step = 5,

            //    },
            //});
            //Graph.AxisY.Add(new Axis
            //{
            //  IsMerged = true,
            //    Separator = new LiveCharts.Wpf.Separator
            //    {

            //      //  IsEnabled = true,
            //        Step = 5,

            //    },
            //});

        }
        public void SetMeasureViewToGraph2(List<MeasuresView> input, double p, double q, double NumP)
        {
            DataContext = this;
            ValuesA.Clear();
            if (input.Count > 0)
            {

                foreach (var x in input.OrderBy(z => z.Ge))
                {
                    ValuesA.Add(new ObservablePoint(x.Ge, x.Lab));
                }
            }
            ValuesB.Clear();
            if (ValuesA.Count > 1)
            {
                var prva = ValuesA.First();
                var poslednja = ValuesA.Last();
                var q1 = q - NumP;

                ValuesB.Add(new ObservablePoint(prva.X, p * prva.X - q1));
                ValuesB.Add(new ObservablePoint(poslednja.X, p * poslednja.X - q1));

            }
            //Graph.AxisX.Add(new Axis
            //{
            //    IsMerged = true,
            //    Separator = new LiveCharts.Wpf.Separator
            //    {

            //        IsEnabled = true,
            //        Step = 5,

            //    },
            //});
            //Graph.AxisY.Add(new Axis
            //{
            //    IsMerged = true,
            //    Separator = new LiveCharts.Wpf.Separator
            //    {

            //        IsEnabled = true,
            //        Step = 5,

            //    },
            //});
        }
        //public void SetMeasureViewToGraph1(List<MeasuresView> input, double p, double q, double Ps, double Qs)
        //{
        //    DataContext = this;
        //    ValuesA.Clear();

        //    if (input.Count > 0)
        //    {

        //        foreach (var x in input.OrderBy(z => z.Ge))
        //        {
        //            ValuesA.Add(new ObservablePoint(x.Ge, x.Lab));


        //        }

        //    }
        //    ValuesB.Clear();
        //    if (ValuesA.Count > 1)
        //    {
        //        var prva = ValuesA.Min(x => x.X);
        //        var poslednja = ValuesA.Max(x => x.X);
        //        var q1 = q - Qs;
        //        var p1 = p + Ps;

        //        ValuesB.Add(new ObservablePoint(prva, p1 * prva - q));
        //        ValuesB.Add(new ObservablePoint(poslednja, p * poslednja - q1));
        //    }

        //}
        public void SetMeasureViewToGraph3(List<MeasuresView> input, double p, double q, double Ps, double Qs, double shift)
        {
            DataContext = this;
            ValuesA.Clear();
            if (input.Count > 0)
            {

                foreach (var x in input.OrderBy(z => z.Ge))
                {
                    ValuesA.Add(new ObservablePoint(x.Ge, x.Lab));

                }
            }
            ValuesB.Clear();
            if (ValuesA.Count > 1)
            {
                var prva = ValuesA.Min(x => x.X);
                var poslednja = ValuesA.Max(x => x.X);
             
                var p1 = p + Ps;
                var q1 = q - Qs - shift;


                ValuesB.Add(new ObservablePoint(prva, p1 * prva - q1));
                ValuesB.Add(new ObservablePoint(poslednja, p * poslednja - q1));
            }

            //Graph.AxisX.Add(new Axis
            //{
            //    IsMerged = true,
            //    Separator = new LiveCharts.Wpf.Separator
            //    {

            //        IsEnabled = true,
            //        Step = 5,

            //    },
            //}) ;
            //Graph.AxisY.Add(new Axis
            //{
            //    IsMerged = true,
            //    Separator = new LiveCharts.Wpf.Separator
            //    {

            //        IsEnabled = true,
            //        Step = 5,

            //    },
            //});

        }





        public ChartValues<ObservablePoint> ValuesA { get; set; } = new ChartValues<ObservablePoint>();
        public ChartValues<ObservablePoint> ValuesB { get; set; } = new ChartValues<ObservablePoint>();
        public ChartValues<ObservablePoint> ValuesC { get; set; } = new ChartValues<ObservablePoint>();
        public Func<double, string> Formatter { get; set; }

        private void Graph_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
