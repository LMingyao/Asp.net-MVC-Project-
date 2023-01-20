using DataLibrary.DAL;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BAL
{
    public  static class UserProcessor
    {
        public static int CreateUser(string UFirstName,
                                    string ULastName,
                                    string UEmail,
                                    string UPhoneNumber,
                                    string UPassword,
                                    string UserType)
        {
            UserModel data = new UserModel
            {
                UFirstName = UFirstName,
                ULastName = ULastName,
                UEmail = UEmail,
                UPhoneNumber = UPhoneNumber,
                UPassword = UPassword,
                UserType = "Tenant"

            };

            string sql = @"INSERT INTO Users Values (@UFirstName, @ULastName, @UEmail, @UPhoneNumber, @UPassword, @UserType);";

            return SqlDataAccess.SaveData(sql, data);

        }

        public static List<UserModel> LoadUsers()
        {
            string sql = @"select * from Users;";

            return SqlDataAccess.LoadData<UserModel>(sql);
        }




    }
}
