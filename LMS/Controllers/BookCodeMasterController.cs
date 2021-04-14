using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;
using System.Data.Objects;

namespace LMS.Controllers
{
    public class BookCodeMasterController : Controller
    {
        private static List<GetBookCodeMaster> bookCodeMasters;

        //
        // GET: /BookCodeMaster/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BookCodeMaster/
        public ActionResult GetData(Utility.DisplayRecords displayRecords)
        {
            if (displayRecords == Utility.DisplayRecords.Default)
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    bookCodeMasters = dbEntities.GetBookCodeMaster().ToList();
                    return Json(new { data = bookCodeMasters.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
                }
            }
            else if (displayRecords == Utility.DisplayRecords.Active)
            {
                return Json(new { data = bookCodeMasters.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Deleted)
            {
                return Json(new { data = bookCodeMasters.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { data = bookCodeMasters }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult InsertOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new BookCodeMaster());
            }
            else
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    return View(dbEntities.BookCodeMasters.Where(x => x.Id == id).FirstOrDefault<BookCodeMaster>());
                }
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(BookCodeMaster bookCodeMaster)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                bookCodeMaster.CreatedOn = bookCodeMaster.ModifiedOn = DateTime.Now;

                if (bookCodeMaster.Id == 0)
                {
                    if (dbEntities.BookCodeMasters.ToArray().Any(x => x.BookCode.IsEqual(bookCodeMaster.BookCode) && x.BookId == bookCodeMaster.BookId))
                    {
                        return Json(new { success = false, message = "BookCode".objAlreadyExists("BookCode", bookCodeMaster.BookCode) }, JsonRequestBehavior.AllowGet);
                    }

                    bookCodeMaster.CreatedBy = CommonBL.UserId;
                    dbEntities.BookCodeMasters.AddObject(bookCodeMaster);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "BookCode".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    bookCodeMaster.ModifiedBy = CommonBL.UserId;
                    BookCodeMaster bookFineInDb = dbEntities.BookCodeMasters.Where(x => x.Id == bookCodeMaster.Id).FirstOrDefault<BookCodeMaster>();
                    if (bookFineInDb == null)
                    {
                        return Json(new { success = false, message = "BookCode".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        bookFineInDb.ModifiedBy = CommonBL.UserId;
                        if (bookCodeMaster.IsDeleted)
                        {
                            bookFineInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(bookFineInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            if (dbEntities.BookCodeMasters.ToArray().Any(x => x.BookCode.IsEqual(bookCodeMaster.BookCode) && x.BookId == bookCodeMaster.BookId && x.Id != bookCodeMaster.Id))
                            {
                                return Json(new { success = false, message = "BookCode".objAlreadyExists("BookCode", bookCodeMaster.BookCode) }, JsonRequestBehavior.AllowGet);
                            }

                            dbEntities.Detach(bookFineInDb);
                            dbEntities.AttachTo("BookCodeMasters", bookCodeMaster);
                            dbEntities.ObjectStateManager.ChangeObjectState(bookCodeMaster, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (bookFineInDb.IsDeleted)
                        {
                            return Json(new { success = true, message = "BookCode".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "BookCode".ObjUpdated() }, JsonRequestBehavior.AllowGet);
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