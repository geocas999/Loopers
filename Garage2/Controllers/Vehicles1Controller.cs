using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.DataAccessLayer;
using Garage2.Models;

namespace Garage2.Controllers
{
    public class Vehicles1Controller : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Vehicles1
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);
            return View(vehicles.ToList());
        }

        public ActionResult CheckOutBySearching(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                if (db.Vehicles.Any(v => v.RegNr == searchTerm))
                {
                    var vehicle = from v in db.Vehicles where v.RegNr == searchTerm select v;
                    return RedirectToAction("Delete", new { vehicle.First().Id });
                }
            }
            return View();
        }

        public ActionResult Autocomplete(string term)
        {
            var model = db.Vehicles.Where(v => v.RegNr.StartsWith(term)).Take(10).Select(v => new { label = v.RegNr });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Vehicles1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles1/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Type");
            return View();
        }

        // POST: Vehicles1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNr,MemberId,VehicleTypeId,StartTime,EndTime,Brand,Model,Color,TotalTime,Parked")] Vehicle vehicle)
        {
            if (db.Vehicles.Any(v => v.RegNr == vehicle.RegNr))
            {
                ModelState.AddModelError("RegNr", "Registreringsnumret finns redan parkerad!");
            }

            if (ModelState.IsValid)
            {
                vehicle.StartTime = DateTime.Now;
                vehicle.Parked = true;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Vehicles1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNr,MemberId,VehicleTypeId,StartTime,EndTime,Brand,Model,Color,TotalTime,Parked")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Vehicle vehicle = db.Vehicles.Find(id);
            //db.Vehicles.Remove(vehicle);
            //db.SaveChanges();
            //return RedirectToAction("Index");

            Vehicle vehicle = db.Vehicles.Find(id);
            vehicle.EndTime = DateTime.Now;
            vehicle.Parked = false;
            vehicle.TotalTime = (vehicle.EndTime - vehicle.StartTime);
            //db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return View("Receipt", vehicle);  
            //return RedirectToAction("Receipt", new { id = id });
        }

        //// GET: Vehicles1/Receipt/5
        //public ActionResult Receipt(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vehicle vehicle = db.Vehicles.Find(id);

        //    return View(vehicle);
        //}

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
