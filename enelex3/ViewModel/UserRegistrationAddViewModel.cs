using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using enelex3.Base;
using enelex3.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;
using enelex3.FrontEndMethods;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace enelex3.ViewModel
{
    public class UserRegistrationAddViewModel : ViewModelBase
    {
        Model1 db = new Model1();
        private Action Load { get; set; }
        public UserRegistrationAddViewModel(Action load)
        {
            Load = load;
        }
        private UserRegistrationFE ufe = new UserRegistrationFE();
        private RegistrationUser addUser { get; set; } = new RegistrationUser();
        public RegistrationUser AddUser
        {
            get => addUser;
            set
            {
                if(addUser != value)
                {
                    addUser = value;
                    OnPropertyChanged(nameof(AddUser));
                }
            }
        }
        private List<SexEnum> addSex { get; set; }
        public List<SexEnum> AddSex
        {
            get => addSex = ufe.GetSex();
            set
            {
                if (addSex != value)
                {
                    addSex = value;
                    OnPropertyChanged(nameof(AddSex));
                }
            }
        }
        private SexEnum selectedAddSex { get; set; }
        public SexEnum SelectedAddSex
        {
            get => selectedAddSex;
            set
            {
                if (selectedAddSex != value)
                {
                    selectedAddSex = value;
                    OnPropertyChanged(nameof(SelectedAddSex));
                }
            }
        }
        private BitmapImage imageCustomer { get; set; } = new BitmapImage();
        public BitmapImage ImageCustomer
        {
            get => imageCustomer;
            set
            {
                if(imageCustomer != value)
                {
                    imageCustomer = value;
                    OnPropertyChanged(nameof(ImageCustomer));
                }
            }
        }
        public ICommand ChangePictureCommand => new RelayCommand(ChangePicture);
        private void ChangePicture()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImageCustomer = new BitmapImage(new Uri(op.FileName));
            }
        }
        public ICommand AddCommand => new RelayCommand<IClosable>(SaveToBAse);
        private void SaveToBAse(IClosable win)
        {
            if(AddUser != null)
            {
                AddUser.IsActive = true;
                AddUser.LastOnUpdate = DateTime.Now;
                AddUser.SexEnum = SelectedAddSex;
                db.RegistrationUsers.Add(AddUser);
                db.SaveChanges();
                Load?.Invoke();
                AddUser = null;
                AddUser = new RegistrationUser();
                if (win != null) win.Close();
            }
        }
    }
}
