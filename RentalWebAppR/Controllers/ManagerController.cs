using RentalWebAppR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BAL;
using static DataLibrary.BAL.UserProcessor;
using System.Configuration;
using System.Xml.Linq;
using RentalWebAppR.Models;
using System.Net.Security;
using System.Web.Security;
using System.Data.SqlClient;
using System.Security.Cryptography;
using RentalWebAppR.DAL;

namespace RentalWebAppR.Controllers
{
    public class ManagerController : Controller
    {
        private PropertyRentalManagementDBEntities2 db = new PropertyRentalManagementDBEntities2();
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListTest()
        {
            List<UserModel> usm = new List<UserModel>();

            UserDAL dalx = new UserDAL();

            usm = dalx.ListAll();

            return View(usm);
        }

        public ActionResult TenantSideMg()
        {  
            return View();
        }

        public ActionResult PropertyMgPortal()
        { 
            return View();
        }
        public ActionResult UserMgPortal()
        { 
            return View();
        }

        public ActionResult Login()
        {



            return View();
        }
        //-----------------------------------------------------------//
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (PropertyRentalManagementDBEntities2 su27sk = new PropertyRentalManagementDBEntities2())
            {
                bool isValidUserWithType = su27sk.Users.Any(user => user.UEmail == model.UEmail && user.UPassword == model.UPassword
                && user.UserType == model.UserType);
                bool isValidUser = su27sk.Users.Any(user => user.UEmail == model.UEmail && user.UPassword == model.UPassword);
                if (isValidUser)
                {
                    if (isValidUserWithType)
                    {
                        FormsAuthentication.SetAuthCookie(model.UEmail, false);
                        Session["UserName"] = model.UEmail;
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Please check your user type!");
                    }

                }
                ModelState.AddModelError("", "Invalid user email or password !");

                // var UserDetail = su27sk.Users.Where(x => x.UEmail == model.UEmail &&
                //                                     x.UPassword == model.UPassword).FirstOrDefault();
                //if(UserDetail == null)
                // {
                //     ModelState.AddModelError("", "Invalid user email or password !");
                // }
                // else
                // {
                //     Session["UserName"] = model.UFirstName;
                //     return RedirectToAction("Index");
                // }
                
                return View();
            }
        }
        
    

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Manager");

        }
        public ActionResult ViewUsers()
        {
            ViewBag.Message = "User List";
            var data = LoadUsers();

            List<UserModel> users = new List<UserModel>();
            foreach (var row in data)
            {
                users.Add(new UserModel
                {
                    UserId = row.UserId,
                    UFirstName = row.UFirstName,
                    ULastName = row.ULastName,
                    UEmail = row.UEmail,
                    UPhoneNumber = row.UPhoneNumber,
                    UPassword = row.UPassword,
                    UserType=row.UserType
                });
            }

            return View(users);
        }


        public ActionResult ViewUserDetail(int id)
        {
            UserDAL dalx = new UserDAL();
            UserModel usmc = dalx.ListOne(id);

            return View(usmc);
        }

        public ActionResult SignUp() 
        {
            ViewBag.Message = "User Sign Up";
            return View();
        }

        public ActionResult UpdateUser(int id)
        {
            ViewBag.Message = "User Update";
            UserDAL dalx = new UserDAL();
            UserModel usmc = dalx.ListOne(id);
            return View("ViewUsers",usmc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserModel model)
        {
          if (ModelState.IsValid)
            {
              int recordsCreated =  CreateUser(model.UFirstName,
                          model.ULastName,
                          model.UEmail,
                          model.UPhoneNumber,
                          model.UPassword,
                          model.UserType);
                return RedirectToAction("index","UserHome");

            }
            return View();
        }
    }
}