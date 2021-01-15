using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;
using enelex3.Base;

namespace enelex3.FrontEndMethods
{
    public class UserRegistrationFE
    {
        Model1 db;
        public UserRegistrationFE(Model1 context=null)
        {
            db = context ?? new Model1();
        }
        public List<UserRegistrationViews> GetUserRegistrationViews()
        {
            var userList = (from x in db.RegistrationUsers.Include(x=> x.Id) where x.IsActive select new UserRegistrationViews {
            Id = x.Id,
            UserName = x.UserName,
            UserEmail = x.UserEmail,
            UserPassword = x.UserPassword,
            LastName = x.LastName,
            FirstName = x.FirstName,
            IsActive = x.IsActive,
            LastOnUpdate = x.LastOnUpdate,
            DateOfBirth = x.DateOfBirth,
            RegistrationDate = x.RegistrationDate,
            SexEnum = x.SexEnum,
            Administrator = x.Administrator
            }).ToList();
            return userList;
        }
        public List<SexEnum> GetSex()
        {
            return Enum.GetValues(typeof(SexEnum)).Cast<SexEnum>().ToList();
        }
    }
}
