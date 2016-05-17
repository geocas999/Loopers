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
    public class VehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        public ActionResult Autocomplete(string term)
        {
            var model = db.Vehicles.Where(v => v.RegNr.StartsWith(term)).Take(10).Select(v => new { label = v.RegNr });

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Search(string searchTerm = null)
        {
            var model = from v in db.Vehicles select v;

            if (string.IsNullOrEmpty(searchTerm))
            {
                return View(model);
            }

            model = from v in db.Vehicles where v.RegNr.StartsWith(searchTerm) select v;
            if (Request.IsAjaxRequest())
            {

                return PartialView("_SearchVehicle", model);

            }
            return View(model);
        }



        //SortOrder by Category
        public ActionResult Sort(string Sorting_Order)
        {
            
            var vehicles = from v in db.Vehicles select v;

            switch (Sorting_Order)
            {
                case "VehicleType":
                    vehicles = vehicles.OrderBy(v => v.VehicleType.ToString());
                    break;
                case "RegNr":
                    vehicles = vehicles.OrderBy(v => v.RegNr);
                    break;
                case "StartTime":
                    vehicles = vehicles.OrderBy(v => v.StartTime);
                    break;
                case "Brand":
                    vehicles = vehicles.OrderBy(v => v.Brand);
                    break;
                case "Model":
                    vehicles = vehicles.OrderBy(v => v.Model);
                    break;
                case "Color":
                    vehicles = vehicles.OrderBy(v => v.Color);
                    break;
                default:
                    vehicles = vehicles.OrderBy(v => v.RegNr);
                    break;
            }
            return View(vehicles);
        }


        // GET: Vehicles/Details/5
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

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VehicleType,RegNr,StartTime,Color,Brand,Model")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.StartTime = DateTime.Now;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
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
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleTypes,RegNr,ParkingTime,Color,Brand,Model")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
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

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            vehicle.EndTime = DateTime.Now;
            vehicle.TotalTime = (vehicle.EndTime - vehicle.StartTime);
            //db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            //return View("Receipt", vehicle);  
            return RedirectToAction("Receipt", new { id = id });
        }

        // GET: Vehicles/Details/5
        public ActionResult Receipt(int? id)
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
