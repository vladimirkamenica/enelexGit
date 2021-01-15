using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enelex3.Base
{
   public class RegistrationUser
    {
        public RegistrationUser()
        {
            DateOfBirth = DateTime.Now;
            RegistrationDate = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public SexEnum SexEnum { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool IsActive { get; set; }

        public bool Administrator { get; set; }

        public DateTime LastOnUpdate { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
