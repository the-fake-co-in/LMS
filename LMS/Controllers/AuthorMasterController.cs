using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class AuthorMasterController : Controller
    {
        private LMSEntities dbEntities = new LMSEntities();

        private static List<AuthorMaster> authors = new List<AuthorMaster>();

        //
        // GET: /AuthorMaster/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /AuthorMaster/
        public ActionResult GetData(Utility.DisplayRecords displayRecords)
        {
            if (displayRecords == Utility.DisplayRecords.Default)
            {
                authors = dbEntities.AuthorMasters.ToList<AuthorMaster>();
                return Json(new { data = authors.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Active)
            {
                return Json(new { data = authors.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Deleted)
            {
                return Json(new { data = authors.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            {
                authors = dbEntities.AuthorMasters.ToList<AuthorMaster>();
                return Json(new { data = authors }, JsonRequestBehavior.AllowGet);
            }
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
                return View(dbEntities.AuthorMasters.Where(x => x.Id == id).FirstOrDefault<AuthorMaster>());
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(AuthorMaster author)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                author.CreatedOn = author.ModifiedOn = DateTime.Now;

                if (author.Id == 0)
                {
                    author.CreatedBy = 1;
                    dbEntities.AuthorMasters.AddObject(author);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "Author".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    AuthorMaster authorInDb = dbEntities.AuthorMasters.Where(x => x.Id == author.Id).FirstOrDefault<AuthorMaster>();
                    if (authorInDb == null)
                    {
                        return Json(new { success = false, message = "Author".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (author.IsDeleted)
                        {
                            authorInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(authorInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            author.ModifiedBy = 1;
                            dbEntities.Detach(authorInDb);
                            dbEntities.AttachTo("AuthorMasters", author);
                            dbEntities.ObjectStateManager.ChangeObjectState(author, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (authorInDb.IsDeleted)
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
            dbEntities.Dispose();
            base.Dispose(disposing);
        }
    }
}