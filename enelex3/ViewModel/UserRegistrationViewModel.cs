using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;
using enelex3.Helpers;
using System.Collections.ObjectModel;
using enelex3.FrontEndMethods;
using System.ComponentModel;
using System.Windows.Data;
using enelex3.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using enelex3.Base;

namespace enelex3.ViewModel
{
    public class UserRegistrationViewModel : ViewModelBase
    {
        Model1 db;
        private bool Admin { get; set; }
        public UserRegistrationViewModel(bool admin)
        {
            Admin = admin;
            FilterText = "";
        }
        private UserRegistrationFE ufe;
        private ObservableCollection<UserRegistrationViews> listOfUsers { get; set; }
        public ObservableCollection<UserRegistrationViews> ListOfUsers
        {
            get => listOfUsers;
            set
            {
                if(listOfUsers != value)
                {
                    listOfUsers = value;
                    OnPropertyChanged(nameof(ListOfUsers));
                }
            }

        }
        private UserRegistrationViews selectedListOfUsers { get; set; }
        public UserRegistrationViews SelectedListOfUsers
        {
            get => selectedListOfUsers;
            set
            {
                if (selectedListOfUsers != value)
                {
                    selectedListOfUsers = value;
                    if (selectedListOfUsers != null)
                    {
                        selectedListOfUsers.Edit = true;
                    } 
                    OnPropertyChanged(nameof(SelectedListOfUsers));
                }
            }
        }
        private ICollectionView usersSearch { get; set; }
        public ICollectionView UsersSearch
        {
            get => usersSearch;
            set
            {
                if(usersSearch != value)
                {
                    usersSearch = value;
                    OnPropertyChanged(nameof(UsersSearch));
                }
            }
        }
        private string filterText { get; set; }
        public string FilterText
        {
            get => filterText;
            set
            {
                if (filterText != value)
                {
                    filterText = value;
                    OnPropertyChanged(nameof(FilterText));
                }
            }
        }
        private List<SexEnum> addSex { get; set; }
        public List<SexEnum> AddSex
        {
            get => addSex;
            set
            {
                if (addSex != value)
                {
                    addSex = value;
                    OnPropertyChanged(nameof(AddSex));
                }
            }
        }
        private bool FilterUser(object o)
        {
            var x = o as UserRegistrationViews;
            if (x == null) return false;
            if (x.FirstName.Contains(FilterText)) return true;
            else return false;
        }
        public ICommand LoadCommand => new RelayCommand(Load);
        private void Load()
        {
            db = new Model1();
            ufe = new UserRegistrationFE(db);
            addSex = ufe.GetSex();
          
            ListOfUsers = new ObservableCollection<UserRegistrationViews>();
            ListOfUsers.Clear();
            ListOfUsers = ufe.GetUserRegistrationViews().ToObservable();
          
            if (ListOfUsers.Count() > 0)
            {
                UsersSearch = CollectionViewSource.GetDefaultView(ListOfUsers);
                UsersSearch.Filter = FilterUser;
            }
        }
        public ICommand AddNewUserCommand => new RelayCommand(AddNewUser);
        private void AddNewUser()
        {
            UserRegistrationAddWindows add = new UserRegistrationAddWindows(Load);
            add.ShowDialog();
        }
        private void SaveToBase(UserRegistrationViews views,bool save, bool del, Model1 db = null)
        {
            db = db ?? new Model1();
            var x = db.RegistrationUsers.Find(views.Id);
            x.Id = views.Id;
            x.FirstName = views.FirstName;
            x.LastName = views.LastName;
            x.UserName = views.UserName;
            x.UserPassword = views.UserPassword;
            x.UserEmail = views.UserEmail;
            x.DateOfBirth = views.DateOfBirth;
            x.RegistrationDate = views.RegistrationDate;
            x.SexEnum = views.SexEnum;
            x.IsActive = del;
            x.LastOnUpdate = views.LastOnUpdate;
            if(save)
            {
                db.SaveChanges();
            }
            db.Dispose();
        }
        public ICommand EditCommand => new RelayCommand(Edit);
        private void Edit()
        {
            if (Admin)
            {
                foreach (var x in ListOfUsers.Where(z => z.Edit).ToList())
                {
                    if (x != null)
                    {
                        SaveToBase(x, true, true);
                        x.Edit = false;
                    }
                }
                Load();
            }
           
           
        }
        public ICommand DelCommand => new RelayCommand(Del);
        private void Del()
        {
            
            if (MessageBoxHelp.MessageBoxYesOrNO())
            {
                foreach (var x in ListOfUsers.Where(z => z.Edit).ToList())
                {
                    if (x != null)
                    {
                        SaveToBase(x, true, false);
                        x.Edit = false;
                    }
                }
                Load();
            }
           
        }
    }
}
