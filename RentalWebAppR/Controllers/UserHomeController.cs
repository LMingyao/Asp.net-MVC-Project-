using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentalWebAppR.Models;

namespace RentalWebAppR.Controllers
{
    public class UserHomeController : Controller
    {
        private PropertyRentalManagementDBEntities2 db = new PropertyRentalManagementDBEntities2();

        // GET: UserHome
        public ActionResult Index()
        {
            return View(db.Addresses.ToList());
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
                        Session["UserId"] = model.UserId;
                        //var TUId = db.Tenants.Include(t => t.TenantUserId).Include(t => t.UserId);
                        //Tenant ts = new Tenant();
                        //ts = db.Tenants.Where(x => (x.UserId).ToString().Contains(Session["UserId"].ToString()).ToString();

                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Please check your user type!");
                    }

                }
                ModelState.AddModelError("", "Invalid user email or password !");

                return View();
            }
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "UserHome");

        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.EmployeeUserId = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId");
            ViewBag.TenantUserId = new SelectList(db.Tenants, "TenantUserId", "TenantUserId"); 
            return View();
        }
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs([Bind(Include = "MessageId,Message1,TenantUserId,EmployeeUserId")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                message.TenantUserId = 1;
                message.EmployeeUserId = 1;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeUserId = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId", message.EmployeeUserId);
            ViewBag.TenantUserId = new SelectList(db.Tenants, "TenantUserId", "TenantUserId", message.TenantUserId);
            return View(message);
        }


        public ActionResult SearchBuilingsByCity(string Search)
        {
            var buildingFinals = db.BuildingFinals.Include(t => t.BuildingId).Include(t => t.BuildingName).Include(t => t.Address).Include(t => t.Apartment).Include(t => t.Apartment).Include(t => t.Status).Include(t => t.price);
            Session["Search"] = Search;

            return View(db.BuildingFinals.Where(x => (x.Address).ToString().Contains(Search) || Search == null).ToList());
        }

        public ActionResult MyAccount(string searching)
        {

            if (Session["UserName"] == null)
            {

                Response.Redirect("~/UserHome/index");
            }
            else
            {
                searching ="Mingyao";
            }
            searching = "Mingyao";
            var Users = db.Users.Include(t => t.UFirstName).Include(t => t.ULastName).Include(t => t.UEmail).Include(t => t.UPassword).Include(t => t.UPassword).Include(t => t.UserType);

            return View(db.Users.Where(x => (x.UFirstName).ToString().Contains(searching) || searching == null).ToList());

        }

        //---------------------------------------------------------------------------------------------------
        // GET: UserHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: UserHome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserHome/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressId,StreetNumber,StreetName,City,Province,PostalCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(address);
        }

        // GET: UserHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: UserHome/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressId,StreetNumber,StreetName,City,Province,PostalCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // GET: UserHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: UserHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult UserBuildingDetail()
        {
            var buildings = db.Buildings.Include(b => b.Address); 
            return View("UserBuildingDetail", buildings.ToList());
        }

        public ActionResult UserSelectApartment()
        {
            var apartments = db.Apartments.Include(b => b.Building);
            return View("UserSelectApartment", apartments.ToList());
        }

        public ActionResult SetAppointment()
        {
            ViewBag.EmployeeUserId = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId");
            ViewBag.TenantUserId = new SelectList(db.Tenants, "TenantUserId", "TenantUserId");
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetAppointment([Bind(Include = "AppointmentId,AppointmentDate,AppointmentTime,TenantUserId,EmployeeUserId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                appointment.TenantUserId = 1;
                appointment.EmployeeUserId = 1;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeUserId = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId", appointment.EmployeeUserId);
            ViewBag.TenantUserId = new SelectList(db.Tenants, "TenantUserId", "TenantUserId", appointment.TenantUserId);
            return View(appointment);
        }


        public ActionResult EditMA(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMA([Bind(Include = "UserId,UFirstName,ULastName,UEmail,UPhoneNumber,UPassword,UserType")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult DetailsMA(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }



    }

}
