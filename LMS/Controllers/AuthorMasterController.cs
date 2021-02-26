using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class AuthorMasterController : Controller
    {
        private LMSEntities db = new LMSEntities();

        //
        // GET: /AuthorMaster/

        public ActionResult Index()
        {
            return View(db.AuthorMasters.ToList());
        }

        //
        // GET: /AuthorMaster/Details/5

        public ActionResult Details(int id = 0)
        {
            AuthorMaster authormaster = db.AuthorMasters.Single(a => a.Id == id);
            if (authormaster == null)
            {
                return HttpNotFound();
            }
            return View(authormaster);
        }

        //
        // GET: /AuthorMaster/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AuthorMaster/Create

        [HttpPost]
        public ActionResult Create(AuthorMaster authormaster)
        {
            if (ModelState.IsValid)
            {
                db.AuthorMasters.AddObject(authormaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authormaster);
        }

        //
        // GET: /AuthorMaster/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AuthorMaster authormaster = db.AuthorMasters.Single(a => a.Id == id);
            if (authormaster == null)
            {
                return HttpNotFound();
            }
            return View(authormaster);
        }

        //
        // POST: /AuthorMaster/Edit/5

        [HttpPost]
        public ActionResult Edit(AuthorMaster authormaster)
        {
            if (ModelState.IsValid)
            {
                db.AuthorMasters.Attach(authormaster);
                db.ObjectStateManager.ChangeObjectState(authormaster, System.Data.EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authormaster);
        }

        //
        // GET: /AuthorMaster/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AuthorMaster authormaster = db.AuthorMasters.Single(a => a.Id == id);
            if (authormaster == null)
            {
                return HttpNotFound();
            }
            return View(authormaster);
        }

        //
        // POST: /AuthorMaster/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorMaster authormaster = db.AuthorMasters.Single(a => a.Id == id);
            db.AuthorMasters.DeleteObject(authormaster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}