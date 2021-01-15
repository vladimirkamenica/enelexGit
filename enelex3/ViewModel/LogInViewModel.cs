using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using enelex3.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;
using enelex3.FrontEndMethods;
using enelex3.Interfaces;
using System.Windows.Controls;

namespace enelex3.ViewModel
{
   public class LogInViewModel : ViewModelBase
    {
        Model1 db = new Model1();
        private string nameTxt { get; set; }
        public string NameTxt
        {
            get => nameTxt;
            set
            {
                if(nameTxt != value)
                {
                    nameTxt = value;
                    OnPropertyChanged(nameof(NameTxt));
                }
            }

        }
        private string passworidTxt { get; set; }
        public string PasswordTxt
        {
            get => passworidTxt;
            set
            {
                if (passworidTxt != value)
                {
                    passworidTxt = value;
                    OnPropertyChanged(nameof(PasswordTxt));
                }
            }
        }
       
        public LogInViewModel()
        {

            //NameTxt = "v.kamenica";
        }
        private UserRegistrationFE ufe = new UserRegistrationFE();
        public ICommand ViewPasswordCommand => new RelayCommand<PasswordBox>(ViewPassword);
        private void ViewPassword(PasswordBox ps)
        {
            PasswordTxt = ps.Password;
       }
        public ICommand ChangeCommand => new RelayCommand<IClosable>(changeText);
        private void changeText(IClosable win)
        {
           // PasswordTxt = "vvvvv";
            if(NameTxt != null && PasswordTxt != null)
            { 
         
            bool admin = false;
            var list = ufe.GetUserRegistrationViews();
            var name = list.Where(x => x.UserName.Replace(" ", "") == NameTxt.Replace(" ", "")).ToList();
            var password = list.Where(x =>  x.UserPassword.Replace(" ", "") == PasswordTxt.Replace(" ", "")).ToList();
            
            if (name.Count() > 0 && password.Count() > 0)
            {
                if (name[0].Administrator) admin = true;
                name[0].CurrentLog = true;
                var logInName = name[0].FirstName;
            
                MainWindow mainWindow = new MainWindow(win,admin, name);
                mainWindow.ShowDialog();
            }
            else
                {
                    Helpers.MessageBoxHelp.MessageBoxErrorLogIn();
                }

            }
        }
    }
}
