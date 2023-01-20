using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UFirstName { get; set; }
        public string ULastName { get; set; }
        public string UEmail { get; set; }
        public string UPhoneNumber { get; set; }
        public string UPassword { get; set; }
        public string UserType { get; set; }

        public UserModel() { }
            


    }
}
