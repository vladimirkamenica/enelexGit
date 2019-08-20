using System;
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
    /// Interaction logic for PrintSheet.xaml
    /// </summary>
    public partial class PrintSheet : Window
    {
        public double P { get; set; }
        public double Q { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double A1 { get; set; }
        public double B1 { get; set; }
        public double W { get; set; }
        public double Aa1 { get; set; }
        public double Ba1 { get; set; }
        public double Ba { get; set; }
        public double As { get; set; }
        public double Bs { get; set; }
        public double As1 { get; set; }
        public double Bs1 { get; set; }
        public int CountOne { get; set; }
        public double APr { get; set; }

        public PrintSheet(double p, double q, double a, double apr, double b, double w, double a1, double b1, double aa1, double ba1, double ba, int countOne, double ass, double bs, double ass1, double bs1)
        {
            InitializeComponent();
            DataContext = this;
            P = p;
            Q = q;
            A = a;
            B = b;
            A1 = a1;
            B1 = b1;
            W = w;
            APr = apr;
            Aa1 = aa1;
            Ba1 = ba1;
            Ba = ba;
            CountOne = countOne;
            As = ass;
            As1 = ass1;
            Bs = bs;
            Bs1 = bs1;
            PrintPage();
        }
     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();

                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(printGrid, "Enelex izveštaj");
                    
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
        private void PrintPage()
        {
            tbP.Text = P.ToString("N4");
            tbQ.Text = Q.ToString("N4");

            tbA.Text = A.ToString("N4");
            tbB.Text = B.ToString("N4");
            tbW.Text = W.ToString("N4");
            tbA1.Text = A1.ToString("N2");
            tbB1.Text = B1.ToString("N2");

            if (APr == 0)
            {
                
                sp0.Visibility = Visibility.Visible;
                tb0.Text = "Nema apsolutnog pomeranja!";
                sp1.Visibility = Visibility.Collapsed;
                sp2.Visibility = Visibility.Collapsed;
                sp3.Visibility = Visibility.Collapsed;
                sp4.Visibility = Visibility.Collapsed;
                sp5.Visibility = Visibility.Collapsed;
                sp6.Visibility = Visibility.Collapsed;

            }
            else
            {

                sp0.Visibility = Visibility.Collapsed;
                tbWa.Text = W.ToString("N4");
                tbAa1.Text = Aa1.ToString("N4");
                tbBa1.Text = Ba1.ToString("N4");
                tbK.Text = APr.ToString("N4");
                tbAa.Text = Aa1.ToString("N2");
                tbBa.Text = Ba.ToString("N2");

            }
            if(CountOne ==2)
            {
                sp0s.Visibility = Visibility.Visible;
                tbWs.Text = W.ToString("N4");
                tbAs1.Text = As.ToString("N4");
                tbBs1.Text = As1.ToString("N4");
                tbAs.Text = Bs.ToString("N2");
                tbBs.Text = Bs1.ToString("N2");
                
            }
            else
            {
                sp0s.Visibility = Visibility.Visible;
                tbs.Text = "Nema srazmernog pomeranja!";
                sp1s.Visibility = Visibility.Collapsed;
                sp2s.Visibility = Visibility.Collapsed;
                sp3s.Visibility = Visibility.Collapsed;
                sp4s.Visibility = Visibility.Collapsed;
                sp5s.Visibility = Visibility.Collapsed;
                sp6s.Visibility = Visibility.Collapsed;
                sp7s.Visibility = Visibility.Collapsed;
            }

        }

        private void TbR111_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
