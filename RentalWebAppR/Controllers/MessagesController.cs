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
    public class MessagesController : Controller
    {
        private PropertyRentalManagementDBEntities2 db = new PropertyRentalManagementDBEntities2();

        // GET: Messages
        public ActionResult Index()
        {
            var messages = db.Messages.Include(m => m.Employee).Include(m => m.Tenant);
            return View(messages.ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeUserId = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId");
            ViewBag.TenantUserId = new SelectList(db.Tenants, "TenantUserId", "TenantUserId");
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageId,Message1,TenantUserId,EmployeeUserId")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeUserId = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId", message.EmployeeUserId);
            ViewBag.TenantUserId = new SelectList(db.Tenants, "TenantUserId", "TenantUserId", message.TenantUserId);
            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeUserId = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId", message.EmployeeUserId);
            ViewBag.TenantUserId = new SelectList(db.Tenants, "TenantUserId", "TenantUserId", message.TenantUserId);
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageId,Message1,TenantUserId,EmployeeUserId")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeUserId = new SelectList(db.Employees, "EmployeeUserId", "EmployeeUserId", message.EmployeeUserId);
            ViewBag.TenantUserId = new SelectList(db.Tenants, "TenantUserId", "TenantUserId", message.TenantUserId);
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
