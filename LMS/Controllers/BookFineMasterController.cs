using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;
using System.Data.Objects;

namespace LMS.Controllers
{
    public class BookFineMasterController : Controller
    {
        private LMSEntities dbEntities = new LMSEntities();

        private static ObjectResult<GetBookFineMaster> bookFineMasters;

        //
        // GET: /BookFineMaster/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BookFineMaster/
        public ActionResult GetData(Utility.DisplayRecords displayRecords)
        {
            if (displayRecords == Utility.DisplayRecords.Default)
            {
                bookFineMasters = dbEntities.GetBookFineMaster();
                return Json(new { data = bookFineMasters.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Active)
            {
                return Json(new { data = bookFineMasters.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Deleted)
            {
                return Json(new { data = bookFineMasters.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            {
                bookFineMasters = dbEntities.GetBookFineMaster();
                return Json(new { data = bookFineMasters }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult InsertOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new BookFineMaster());
            }
            else
            {
                return View(dbEntities.BookFineMasters.Where(x => x.Id == id).FirstOrDefault<BookFineMaster>());
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(BookFineMaster bookFine)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                bookFine.CreatedOn = bookFine.ModifiedOn = DateTime.Now;

                if (bookFine.Id == 0)
                {
                    bookFine.CreatedBy = 1;
                    dbEntities.BookFineMasters.AddObject(bookFine);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "BookFine".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    BookFineMaster bookFineInDb = dbEntities.BookFineMasters.Where(x => x.Id == bookFine.Id).FirstOrDefault<BookFineMaster>();
                    if (bookFineInDb == null)
                    {
                        return Json(new { success = false, message = "BookFine".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
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
                            dbEntities.AttachTo("BookFineMasters", bookFine);
                            dbEntities.ObjectStateManager.ChangeObjectState(bookFine, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (bookFineInDb.IsDeleted)
                        {
                            return Json(new { success = true, message = "BookFine".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "BookFine".ObjUpdated() }, JsonRequestBehavior.AllowGet);
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