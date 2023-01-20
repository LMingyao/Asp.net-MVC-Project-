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
    public class BuildingFinalsController : Controller
    {
        private PropertyRentalManagementDBEntities2 db = new PropertyRentalManagementDBEntities2();

        // GET: BuildingFinals
        public ActionResult Index()
        {
            return View(db.BuildingFinals.ToList());
        }

        public ActionResult SearchBuilingsByCity(string CitySearch)
        {
            var buildingFinals = db.BuildingFinals.Include(t => t.BuildingId).Include(t => t.BuildingName).Include(t => t.Address).Include(t => t.Apartment).Include(t => t.Apartment).Include(t => t.Status).Include(t => t.price);
            Session["CitySearch"] = CitySearch;
            
            return View(db.BuildingFinals.Where(x => (x.Address).ToString().Contains(CitySearch) || CitySearch == null).ToList());
        }


        // GET: BuildingFinals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingFinal buildingFinal = db.BuildingFinals.Find(id);
            if (buildingFinal == null)
            {
                return HttpNotFound();
            }
            return View(buildingFinal);
        }

        // GET: BuildingFinals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuildingFinals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuildingId,BuildingName,Address,Apartment,Status,price")] BuildingFinal buildingFinal)
        {
            if (ModelState.IsValid)
            {
                db.BuildingFinals.Add(buildingFinal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buildingFinal);
        }

        // GET: BuildingFinals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingFinal buildingFinal = db.BuildingFinals.Find(id);
            if (buildingFinal == null)
            {
                return HttpNotFound();
            }
            return View(buildingFinal);
        }

        // POST: BuildingFinals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuildingId,BuildingName,Address,Apartment,Status,price")] BuildingFinal buildingFinal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildingFinal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildingFinal);
        }

        // GET: BuildingFinals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingFinal buildingFinal = db.BuildingFinals.Find(id);
            if (buildingFinal == null)
            {
                return HttpNotFound();
            }
            return View(buildingFinal);
        }

        // POST: BuildingFinals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuildingFinal buildingFinal = db.BuildingFinals.Find(id);
            db.BuildingFinals.Remove(buildingFinal);
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
