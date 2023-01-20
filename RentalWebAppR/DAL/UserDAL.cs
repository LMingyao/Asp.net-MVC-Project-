using RentalWebAppR.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace RentalWebAppR.DAL
{
    public class UserDAL
    {
        private string connectionString = @"Data Source=DESKTOP-A2E5028\SQLSERVEREXPRESS; 
                    Initial Catalog = PropertyRentalManagementDB; User ID = sa; Password=87857988ai";

        public List<UserModel> ListAll()
        {
            List<UserModel> listUSM = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from Users";
                SqlCommand com = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataReader reader= com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserModel usm = new UserModel();
                        usm.UserId = reader.GetInt32(0);
                        usm.UFirstName = reader.GetString(1);
                        usm.ULastName= reader.GetString(2);
                        usm.UEmail  = reader.GetString(3);
                        usm.UPhoneNumber= reader.GetString(4);
                        usm.UPassword= reader.GetString(5);
                        usm.UserType= reader.GetString(6);

                        listUSM.Add(usm);

                    }
                }

            }
            return listUSM;

        }

        public UserModel ListOne(int uIdX)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
                SqlCommand cmdProject = new SqlCommand();
                cmdProject.CommandText = "SELECT * FROM Users WHERE UserId =@uIdX";

                cmdProject.Connection = conn;

                cmdProject.Parameters.Add("@uIdX", System.Data.SqlDbType.Int).Value = uIdX;
                SqlDataReader reader = cmdProject.ExecuteReader();

                UserModel usm = new UserModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        usm.UserId = reader.GetInt32(0);
                        usm.UFirstName = reader.GetString(1);
                        usm.ULastName = reader.GetString(2);
                        usm.UEmail = reader.GetString(3);
                        usm.UPhoneNumber = reader.GetString(4);
                        usm.UPassword = reader.GetString(5);
                        usm.UserType = reader.GetString(6);

                    }
                }
                return usm;
            }

        }

        public int UpdateOne(UserModel usmc)
        {
            using (SqlConnection conn = UtilityDB.GetDBConnection())
            {
               
                string sqlQuery = "";
                sqlQuery = "UPDATE Users SET UFirstName = @UFirstName, ULastName = @ULastName," +
                    "UEmail = @UEmail, UPhoneNumber = @UPhoneNumber, UPassword = @UPassword, UserType = @UserType" +
                    "WHERE UserId = @UserId)";

                SqlCommand cmdProject = new SqlCommand(sqlQuery,conn);

                cmdProject.Parameters.AddWithValue("@UFirstName", usmc.UFirstName);
                cmdProject.Parameters.AddWithValue("@ULastName", usmc.ULastName);
                cmdProject.Parameters.AddWithValue("@UEmail", usmc.UEmail);
                cmdProject.Parameters.AddWithValue("@UPhoneNumber", usmc.UPhoneNumber);
                cmdProject.Parameters.AddWithValue("@UPassword", usmc.UPassword);
                cmdProject.Parameters.AddWithValue("@UserType", usmc.UserType);

                conn.Open();

                int newID = cmdProject.ExecuteNonQuery();

                return newID;
            }

        }































    }


}