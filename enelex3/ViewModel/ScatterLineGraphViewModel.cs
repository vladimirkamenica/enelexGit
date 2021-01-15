using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;


namespace enelex3.ViewModel
{
    public class ScatterLineGraphViewModel : ViewModelBase
    {
        public ScatterLineGraphViewModel()
        {
            MaxX = 1;
            MaxY = 1;
        }
        private double maxX { get; set; }
        public double MaxX
        {
            get => maxX;
            set
            {
                if (maxX != value)
                {
                    maxX = value;
                    OnPropertyChanged(nameof(MaxX));
                }
            }
        }
        private double maxY { get; set; }
        public double MaxY
        {
            get => maxY;
            set
            {
                if(maxY != value)
                {
                    maxY = value;
                    OnPropertyChanged(nameof(MaxY));
                }
            }
        }
        private double result_R { get; set; }
        public double Result_R
        {
            get => result_R;
            set
            {
                if (result_R != value)
                {
                    result_R = value;
                    OnPropertyChanged(nameof(Result_R));
                }
            }
        }
        private double result_Q { get; set; }
        public double Result_Q
        {
            get => result_Q;
            set
            {
                if (result_Q != value)
                {
                    result_Q = value;
                    OnPropertyChanged(nameof(Result_Q));
                }
            }
        }
        private double result_P { get; set; }
        public double Result_P
        {
            get => result_P;
            set
            {
                if (result_P != value)
                {
                    result_P = value;
                    OnPropertyChanged(nameof(Result_P));
                }
            }
        }
        public void SetMeasureViewToGraph(ObservableCollection<MeasuresView> input, double p, double q,double r)
        {
           
            ValuesA.Clear();

            if (input.Count > 0)
            {

                foreach (var x in input.OrderBy(z => z.Ge))
                {
                    ValuesA.Add(new ObservablePoint(x.Ge, x.Lab));


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
                    
                    MaxX = poslednja + 5;
                    MaxY = ValuesA.Max(x => x.Y) + 5;
                    Result_P = p;
                    Result_Q = q;
                    Result_R = r;
                }
            }
          


        }
        public void SetMeasureViewToGraph2(ObservableCollection<MeasuresView> input, double p, double q, double shift,double r)
        {
           
            ValuesA.Clear();
            if (input.Count > 0)
            {

                foreach (var x in input.OrderBy(z => z.Ge))
                {
                    ValuesA.Add(new ObservablePoint(x.Ge, x.Lab));
                }
                ValuesB.Clear();
                if (ValuesA.Count > 1)
                {
                    var prva = ValuesA.First();
                    var poslednja = ValuesA.Last();
                    var q1 = q - shift;

                    ValuesB.Add(new ObservablePoint(prva.X, p * prva.X - q1));
                    ValuesB.Add(new ObservablePoint(poslednja.X, p * poslednja.X - q1));
                   
                    MaxX = ValuesA.Max(x => x.X) + 5;
                    MaxY = ValuesA.Max(x => x.Y) + 5;
                    Result_P = p;
                    Result_Q = q1;
                    Result_R = r;
                }
            }
           

        }
     
        public void SetMeasureViewToGraph3(ObservableCollection<MeasuresView> input, double p, double q, double Ps, double Qs, double shift = 0)
        {
          
            ValuesA.Clear();
            if (input.Count > 0)
            {

                foreach (var x in input.OrderBy(z => z.Ge))
                {
                    ValuesA.Add(new ObservablePoint(x.Ge, x.Lab));

                }
                ValuesB.Clear();
                if (ValuesA.Count > 1)
                {
                    var prva = ValuesA.Min(x => x.X);
                    var poslednja = ValuesA.Max(x => x.X);

                    var p1 = p;
                    var q1 = q - Qs - shift;
                    var q2 = q - Ps;

                    ValuesB.Add(new ObservablePoint(prva, p1 * prva - q2));
                    ValuesB.Add(new ObservablePoint(poslednja, p * poslednja - q1));
                    MaxX = poslednja + 5;
                    MaxY = ValuesA.Max(x => x.Y) + 5;
                }
            }
          



        }
        public ChartValues<ObservablePoint> ValuesA { get; set; } = new ChartValues<ObservablePoint>();
        public ChartValues<ObservablePoint> ValuesB { get; set; } = new ChartValues<ObservablePoint>();
    }
}
