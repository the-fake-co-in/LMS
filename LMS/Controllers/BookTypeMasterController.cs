using System;
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
    public class BookTypeMasterController : Controller
    {
        private LMSEntities db = new LMSEntities();

        //
        // GET: /BookTypeMaster/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BookTypeMaster/
        public ActionResult GetData()
        {
            List<BookTypeMaster> bookTypes = db.BookTypeMasters.ToList<BookTypeMaster>();
            return Json(new { data = bookTypes }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult InsertOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new BookTypeMaster());
            }
            else
            {
                return View(db.BookTypeMasters.Where(x => x.Id == id).FirstOrDefault<BookTypeMaster>());
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(BookTypeMaster bookType)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                bookType.CreatedOn = bookType.ModifiedOn = DateTime.Now;

                if (bookType.Id == 0)
                {
                    bookType.CreatedBy = 1;
                    dbEntities.BookTypeMasters.AddObject(bookType);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "BookType".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    BookTypeMaster bookTypeInDb = dbEntities.BookTypeMasters.Where(x => x.Id == bookType.Id).FirstOrDefault<BookTypeMaster>();
                    if (bookTypeInDb == null)
                    {
                        return Json(new { success = false, message = "BookType".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (bookType.IsDeleted)
                        {
                            bookTypeInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(bookTypeInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            bookType.ModifiedBy = 1;
                            dbEntities.Detach(bookTypeInDb);
                            dbEntities.AttachTo("BookTypeMasters", bookType);
                            dbEntities.ObjectStateManager.ChangeObjectState(bookType, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (bookTypeInDb.IsDeleted)
                        {
                            return Json(new { success = true, message = "BookType".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "BookType".ObjUpdated() }, JsonRequestBehavior.AllowGet);
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