using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.Base;
using enelex3.ViewModel;

namespace enelex3.View
{
    public class UserRegistrationViews :  ViewModelBase
    {
        private bool isSelected { get; set; }
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if(isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public bool Edit { get; set; }

        public bool CurrentLog { get; set; }
        public int Id { get; set; }

        public string UserName { get; set; }

        public string UserNameReplace { get => UserName.Replace(" ", ""); }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

      

        public DateTime RegistrationDate { get; set; }

        public bool IsActive { get; set; }

        public bool Administrator { get; set; }

        public DateTime LastOnUpdate { get; set; }

        public DateTime DateOfBirth { get; set; }
        private SexEnum sexEnum { get; set; }
        public SexEnum SexEnum
        {
            get => sexEnum;
            set
            {
                if(sexEnum != value)
                {
                    sexEnum = value;
                    OnPropertyChanged(nameof(SexEnum));
                }
            }
        }
    }
}
