//using System;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web.Mvc;
//using Garage2.DataAccessLayer;
//using Garage2.Models;
//using PagedList;


////namespace Garage2.Controllers
////{
////    public class VehiclesController : Controller
////    {
////        private GarageContext db = new GarageContext();

//        // GET: Vehicles
//        public ActionResult Index(string sorting ,  string searchTerm , int? pageNumber)
//        {
//            ViewBag.CurrentSort = sorting;

//            //if the sorting parameter is null or empty then we are initializing the value as descending name  
//            ViewBag.SortByRegNr = string.IsNullOrEmpty(sorting) ? "RegNummer_desc" : "";

//            //if the sorting value is 'Fordonstyp' then we are initializing the value as descending 'Fordonstyp 
//            ViewBag.SortByVehicleType = sorting == "Fordonstyp" ? "Fordonstyp_desc" : "Fordonstyp";

//            //if the sorting value is 'Parkering påbörjad' then we are initializing the value as descending 'Parkering påbörjad' 
//            ViewBag.SortByStartTime = sorting == "Parkering påbörjad" ? "Parkering påbörjad_desc" : "Parkering påbörjad";

//            //here we are converting the db.Vehicles to AsQueryable so that we can invoke all the extension methods on variable records.  
//            var vehicles = db.Vehicles.AsQueryable();

//            vehicles = from v in db.Vehicles orderby v.RegNr where v.Parked == true select v;

//            if (!string.IsNullOrEmpty(searchTerm))
//            {
//                if (db.Vehicles.Any(v => v.RegNr==searchTerm))
//                {
//                    var vehicle = from v in db.Vehicles where v.RegNr == searchTerm select v;
//                    return RedirectToAction("Details", new { vehicle.First().Id });
//                }
//            }

//            //if (show == "all")
//            //{
//            //    vehicles = from v in db.Vehicles orderby v.RegNr select v;
//            //}

//            switch (sorting)
//            {
//                case "Fordonstyp":
//                    //vehicles = vehicles.OrderBy(v => v.VehicleType);
//                    vehicles = from v in db.Vehicles orderby v.VehicleType select v;
//                    break;
//                case "Fordonstyp_desc":
//                    //vehicles = from v in db.Vehicles orderby v.VehicleType descending select v;
//                    vehicles = vehicles.OrderByDescending(v => v.VehicleType);
//                    break;

//                case "RegNummer":
//                    //vehicles = vehicles.OrderBy(v => v.RegNr);
//                    vehicles = from v in db.Vehicles orderby v.RegNr select v;
//                    break;
//                case "RegNummer_desc":
//                    //vehicles = from v in db.Vehicles orderby v.RegNr descending select v; 
//                    vehicles = vehicles.OrderByDescending(v => v.RegNr);
//                    break;

//                case "Parkering påbörjad":
//                    //vehicles = vehicles.OrderBy(v => v.StartTime);
//                    vehicles = from v in db.Vehicles orderby v.StartTime select v;
//                    break;
//                case "Parkering påbörjad_desc":
//                    //vehicles = from v in db.Vehicles orderby v.StartTime descending select v;
//                    vehicles = vehicles.OrderByDescending(v => v.StartTime);
//                    break;

//                default:
//                    break;                    
//            }
//            return View(vehicles.ToPagedList(pageNumber ?? 1, 10));
//        }



//        public ActionResult Autocomplete(string term)
//        {
//            var model = db.Vehicles.Where(v => v.RegNr.StartsWith(term)).Take(10).Select(v => new { label = v.RegNr });

////            return Json(model, JsonRequestBehavior.AllowGet);
////        }


       
//        public ActionResult CheckIfParked(string RegNr)
//        {
//            if(db.Vehicles.Any(v => v.RegNr == RegNr))
//            {
//                return Json(true, JsonRequestBehavior.AllowGet);
//            }
//            else
//            {
//                return Json(false, JsonRequestBehavior.AllowGet);
//            }
            
//        }



//        public ActionResult CheckOutBySearching(string searchTerm)
//        {
//            if (!string.IsNullOrEmpty(searchTerm))
//            {
//                if (db.Vehicles.Any(v => v.RegNr == searchTerm))
//                {
//                    var vehicle = from v in db.Vehicles where v.RegNr == searchTerm select v;
//                    return RedirectToAction("CheckOut", new { vehicle.First().Id });
//                }
//            }
//            return View();
//        }


////        // GET: Vehicles/Details/5
////        public ActionResult Details(int? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            VehicleType vehicle = db.Vehicles.Find(id);
////            if (vehicle == null)
////            {
////                return HttpNotFound();
////            }
////            return View(vehicle);
////        }


//        // GET: Vehicles/Check-In
//        public ActionResult CheckIn()
//        {
//            return View();
//        }

//        // POST: Vehicles/ParkVehicle
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult CheckIn( [Bind(Include = "Id,RegNr,MemberId,VehicleTypeId,StartTime,EndTime,Brand,Model,Color,TotalTime,Parked")] Vehicle vehicle)
//        {
//            if (db.Vehicles.Any(v => v.RegNr == vehicle.RegNr))
//            {
//                ModelState.AddModelError("RegNr", "Registreringsnumret finns redan parkerad!");
//            }

//            if (ModelState.IsValid)
//            {              
//                vehicle.StartTime = DateTime.Now;
//                vehicle.Parked = true;
//                db.Vehicles.Add(vehicle);
//                db.SaveChanges();
//                return RedirectToAction("Index");                         
//            }

//            return View(vehicle);
//        }
          
             
//        // GET: Vehicles/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Vehicle vehicle = db.Vehicles.Find(id);
//            if (vehicle == null)
//            {
//                return HttpNotFound();
//            }
//            return View(vehicle);
//        }

//        // POST: Vehicles/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id, RegNr, MemberId, VehicleTypeId, StartTime, EndTime, Brand, Model, Color, TotalTime, Parked")] Vehicle vehicle)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(vehicle).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(vehicle);
//        }

//        // GET: Vehicles/Check-Out/5
//        public ActionResult CheckOut(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Vehicle vehicle = db.Vehicles.Find(id);
//            if (vehicle == null)
//            {
//                return HttpNotFound();
//            }
//            return View(vehicle);
//        }

//        // POST: Vehicles/Delete/5
//        [HttpPost, ActionName("CheckOut")]
//        [ValidateAntiForgeryToken]
//        public ActionResult CheckOutConfirmed(int id)
//        {
//            Vehicle vehicle = db.Vehicles.Find(id);
//            vehicle.EndTime = DateTime.Now;
//            vehicle.Parked = false;
//            vehicle.TotalTime = (vehicle.EndTime - vehicle.StartTime);
//            //db.Vehicles.Remove(vehicle);
//            db.SaveChanges();
//            //return View("Receipt", vehicle);  
//            return RedirectToAction("Receipt", new { id = id });
//        }

////        // GET: Vehicles/Details/5
////        public ActionResult Receipt(int? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            VehicleType vehicle = db.Vehicles.Find(id);
////            if (vehicle == null)
////            {
////                return HttpNotFound();
////            }            

////            return View(vehicle);
////        }

////        protected override void Dispose(bool disposing)
////        {
////            if (disposing)
////            {
////                db.Dispose();
////            }
////            base.Dispose(disposing);
////        }
////    }
////}
