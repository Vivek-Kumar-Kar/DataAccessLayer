using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFUsingDataAccessLayer;

namespace EFUsingDataAccessLayer.Controllers
{
    public class StudentDataAccessesController : Controller
    {
        private School0905Entities db = new School0905Entities();

        // GET: StudentDataAccesses
        public ActionResult Index()
        {
            return View(db.StudentDataAccesses.ToList());
        }

        // GET: StudentDataAccesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDataAccess studentDataAccess = db.StudentDataAccesses.Find(id);
            if (studentDataAccess == null)
            {
                return HttpNotFound();
            }
            return View(studentDataAccess);
        }

        // GET: StudentDataAccesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentDataAccesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SId,SName,Class")] StudentDataAccess studentDataAccess)
        {
            if (ModelState.IsValid)
            {
                db.StudentDataAccesses.Add(studentDataAccess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentDataAccess);
        }

        // GET: StudentDataAccesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDataAccess studentDataAccess = db.StudentDataAccesses.Find(id);
            if (studentDataAccess == null)
            {
                return HttpNotFound();
            }
            return View(studentDataAccess);
        }

        // POST: StudentDataAccesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SId,SName,Class")] StudentDataAccess studentDataAccess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentDataAccess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentDataAccess);
        }

        // GET: StudentDataAccesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDataAccess studentDataAccess = db.StudentDataAccesses.Find(id);
            if (studentDataAccess == null)
            {
                return HttpNotFound();
            }
            return View(studentDataAccess);
        }

        // POST: StudentDataAccesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentDataAccess studentDataAccess = db.StudentDataAccesses.Find(id);
            db.StudentDataAccesses.Remove(studentDataAccess);
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
