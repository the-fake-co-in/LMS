﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class AuthorMasterController : Controller
    {
        private LMSEntities db = new LMSEntities();

        //
        // GET: /AuthorMaster/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /AuthorMaster/
        public ActionResult GetData()
        {
            List<AuthorMaster> authors = db.AuthorMasters.ToList<AuthorMaster>();
            return Json(new { data = authors }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult InsertOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new AuthorMaster());
            }
            else
            {
                return View(db.AuthorMasters.Where(x => x.Id == id).FirstOrDefault<AuthorMaster>());
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(AuthorMaster author)
        {
            using (LMSEntities db = new LMSEntities())
            {
                author.CreatedOn = author.ModifiedOn = DateTime.Now;

                if (author.Id == 0)
                {
                    author.CreatedBy = 1;
                    db.AuthorMasters.AddObject(author);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Author".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    AuthorMaster authorInDb = db.AuthorMasters.Where(x => x.Id == author.Id).FirstOrDefault<AuthorMaster>();
                    if(authorInDb == null)
                    {
                        return Json(new { success = false, message = "Author".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        //db.ObjectStateManager.ChangeObjectState(authorInDb, System.Data.EntityState.Modified);
                        //authorInDb = author;
                        db.Attach(author);
                        db.ObjectStateManager.ChangeObjectState(author, System.Data.EntityState.Modified);
                        db.SaveChanges();

                        if(authorInDb.IsDeleted)
                        {
                            return Json(new { success = true, message = "Author".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "Author".ObjUpdated() }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}