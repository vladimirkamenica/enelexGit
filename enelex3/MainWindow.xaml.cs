using ClosedXML.Excel;
using enelex3.Alati;
using enelex3.FrontEndMethods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using enelex3.View;
using enelex3.ViewModel;
using enelex3.Interfaces;


namespace enelex3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IClosable
    {
        public MainWindow(IClosable win,bool admin, List<UserRegistrationViews> user)
        {
            DataContext = new MainWindowViewModel(win,admin, user);
            InitializeComponent();
        }
     
    }
}
