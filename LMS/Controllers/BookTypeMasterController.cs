using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class BookTypeMasterController : Controller
    {
        private LMSEntities dbEntities = new LMSEntities();

        private static List<BookTypeMaster> bookTypes = new List<BookTypeMaster>();

        //
        // GET: /BookTypeMaster/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BookTypeMaster/
        public ActionResult GetData(Utility.DisplayRecords displayRecords)
        {
            if (displayRecords == Utility.DisplayRecords.Default)
            {
                bookTypes = dbEntities.BookTypeMasters.ToList<BookTypeMaster>();
                return Json(new { data = bookTypes.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Active)
            {
                return Json(new { data = bookTypes.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Deleted)
            {
                return Json(new { data = bookTypes.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            {
                bookTypes = dbEntities.BookTypeMasters.ToList<BookTypeMaster>();
                return Json(new { data = bookTypes }, JsonRequestBehavior.AllowGet);
            }
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
                return View(dbEntities.BookTypeMasters.Where(x => x.Id == id).FirstOrDefault<BookTypeMaster>());
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
                    if (dbEntities.BookTypeMasters.ToArray().Any(x => x.Type.IsEqual(bookType.Type)))
                    {
                        return Json(new { success = false, message = "BookType".objAlreadyExists("Type", bookType.Type) }, JsonRequestBehavior.AllowGet);
                    }

                    bookType.CreatedBy = CommonBL.UserId;
                    dbEntities.BookTypeMasters.AddObject(bookType);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "BookType".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    bookType.ModifiedBy = CommonBL.UserId;
                    BookTypeMaster bookTypeInDb = dbEntities.BookTypeMasters.Where(x => x.Id == bookType.Id).FirstOrDefault<BookTypeMaster>();
                    if (bookTypeInDb == null)
                    {
                        return Json(new { success = false, message = "BookType".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        bookTypeInDb.ModifiedBy = CommonBL.UserId;
                        if (bookType.IsDeleted)
                        {
                            bookTypeInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(bookTypeInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            if (dbEntities.BookTypeMasters.ToArray().Any(x => x.Type.IsEqual(bookType.Type) && x.Id != bookType.Id))
                            {
                                return Json(new { success = false, message = "BookType".objAlreadyExists("Type", bookType.Type) }, JsonRequestBehavior.AllowGet);
                            }

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
            dbEntities.Dispose();
            base.Dispose(disposing);
        }
    }
}