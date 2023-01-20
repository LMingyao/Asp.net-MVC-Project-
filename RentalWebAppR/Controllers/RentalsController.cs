using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentalWebAppR.Models;

namespace RentalWebAppR.Controllers
{
    public class RentalsController : Controller
    {
        private PropertyRentalManagementDBEntities2 db = new PropertyRentalManagementDBEntities2();

        // GET: Rentals
        public ActionResult Index()
        {
            var rentals = db.Rentals.Include(r => r.Apartment).Include(r => r.Employee).Include(r => r.Tenant);
            return View(rentals.ToList());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            ViewBag.ApartmentId = new SelectList(db.Apartments, "ApartmentNumber", "ApartmentType");
            ViewBag.EmployeeUserID = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId");
            ViewBag.TenantUserID = new SelectList(db.Tenants, "TenantUserId", "TenantUserId");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalId,RentalPrice,StartDate,EndDate,ApartmentId,TenantUserID,EmployeeUserID")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Rentals.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApartmentId = new SelectList(db.Apartments, "ApartmentNumber", "ApartmentType", rental.ApartmentId);
            ViewBag.EmployeeUserID = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId", rental.EmployeeUserID);
            ViewBag.TenantUserID = new SelectList(db.Tenants, "TenantUserId", "TenantUserId", rental.TenantUserID);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApartmentId = new SelectList(db.Apartments, "ApartmentNumber", "ApartmentType", rental.ApartmentId);
            ViewBag.EmployeeUserID = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId", rental.EmployeeUserID);
            ViewBag.TenantUserID = new SelectList(db.Tenants, "TenantUserId", "TenantUserId", rental.TenantUserID);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalId,RentalPrice,StartDate,EndDate,ApartmentId,TenantUserID,EmployeeUserID")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApartmentId = new SelectList(db.Apartments, "ApartmentNumber", "ApartmentType", rental.ApartmentId);
            ViewBag.EmployeeUserID = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId", rental.EmployeeUserID);
            ViewBag.TenantUserID = new SelectList(db.Tenants, "TenantUserId", "TenantUserId", rental.TenantUserID);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rentals.Find(id);
            db.Rentals.Remove(rental);
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
    }
}
