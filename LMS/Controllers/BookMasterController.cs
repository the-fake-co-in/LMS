using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;
using System.Data.Objects;

namespace LMS.Controllers
{
    public class BookMasterController : Controller
    {
        private static List<GetBookMaster> bookMasters;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData(Utility.DisplayRecords displayRecords)
        {
            if (displayRecords == Utility.DisplayRecords.Default)
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    bookMasters = dbEntities.GetBookMaster().ToList();
                    return Json(new { data = bookMasters.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
                }
            }
            else if (displayRecords == Utility.DisplayRecords.Active)
            {
                return Json(new { data = bookMasters.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Deleted)
            {
                return Json(new { data = bookMasters.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { data = bookMasters }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult InsertOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new BookMaster());
            }
            else
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    return View(dbEntities.BookMasters.Where(x => x.Id == id).FirstOrDefault<BookMaster>());
                }
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(BookMaster bookFine)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                bookFine.CreatedOn = bookFine.ModifiedOn = DateTime.Now;

                if (bookFine.Id == 0)
                {
                    bookFine.CreatedBy = 1;
                    dbEntities.BookMasters.AddObject(bookFine);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "Book".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    BookMaster bookFineInDb = dbEntities.BookMasters.Where(x => x.Id == bookFine.Id).FirstOrDefault<BookMaster>();
                    if (bookFineInDb == null)
                    {
                        return Json(new { success = false, message = "Book".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (bookFine.IsDeleted)
                        {
                            bookFineInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(bookFineInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            bookFine.ModifiedBy = 1;
                            dbEntities.Detach(bookFineInDb);
                            dbEntities.AttachTo("BookMasters", bookFine);
                            dbEntities.ObjectStateManager.ChangeObjectState(bookFine, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (bookFineInDb.IsDeleted)
                        {
                            return Json(new { success = true, message = "Book".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "Book".ObjUpdated() }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}