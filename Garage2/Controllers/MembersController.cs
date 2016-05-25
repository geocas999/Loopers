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
using PagedList;

namespace Garage2.Controllers
{
    public class MembersController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Members
        public ActionResult Index(string sorting, string searchTerm, int? pageNumber)
        {
            ViewBag.CurrentSort = sorting;

            //if the sorting parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sorting) ? "Medlemsnamn_desc" : "";

            //if the sorting value is 'Fordonstyp' then we are initializing the value as descending 'Fordonstyp 
            ViewBag.SortByMemberNr = sorting == "Medlemsnummer" ? "Medlemsnummer_desc" : "Medlemsnummer";

            //here we are converting the db.Vehicles to AsQueryable so that we can invoke all the extension methods on variable records.  
            var members = db.Members.AsQueryable();

            members = from v in db.Members orderby v.MemberNr select v;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                if (db.Members.Any(v => v.Name == searchTerm))
                {
                    var member = from v in db.Members where v.Name == searchTerm select v;
                    return RedirectToAction("Details", new { member.First().Id });
                }
            }

            switch (sorting)
            {
                case "Medlemsnummer":
                    //vehicles = vehicles.OrderBy(v => v.VehicleType);
                    members = from v in db.Members orderby v.MemberNr select v;
                    break;
                case "Medlemsnummer_desc":
                    //vehicles = from v in db.Vehicles orderby v.VehicleType descending select v;
                    members = members.OrderByDescending(v => v.MemberNr);
                    break;

                case "Medlemsnamn":
                    //vehicles = vehicles.OrderBy(v => v.RegNr);
                    members = from v in db.Members orderby v.Name select v;
                    break;
                case "Medlemsnamn_desc":
                    //vehicles = from v in db.Vehicles orderby v.RegNr descending select v; 
                    members = members.OrderByDescending(v => v.Name);
                    break;

                default:
                    break;
            }
            return View(members.ToPagedList(pageNumber ?? 1, 8));
        }



        public ActionResult Autocomplete(string term)
        {
            var model = db.Members.Where(v => v.Name.StartsWith(term)).Take(10).Select(v => new { label = v.Name });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            var maxNr = (db.Members.Max(x => x.MemberNr) ) + 1;
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberNr,Name")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberNr,Name")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
