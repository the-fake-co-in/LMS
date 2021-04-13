using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class BookController : Controller
    {
        private static List<GetBookAvailability> availableBooks = null;

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult GetBookDetails()
        {
            using (LMSEntities dbEntitiy = new LMSEntities())
            {
                availableBooks = dbEntitiy.GetBookAvailability().ToList();

                if (availableBooks != null && availableBooks.Count > 0)
                {
                    foreach (GetBookAvailability availableBook in availableBooks)
                    {
                        availableBook.IsAlreadyReserved = IsBookAlreadyReserved(dbEntitiy, availableBook.Id);
                        availableBook.IsAvailable = GetAvailbleBookCodeId(dbEntitiy, availableBook.Id) > 0;
                    }
                }
            }
            return Json(new { data = availableBooks }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Reserve(BookReservation bookReservation)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                if (IsBookAlreadyIssued(dbEntities, bookReservation.Id))
                {
                    return Json(new { success = false, message = "Book is already issued by you!" }, JsonRequestBehavior.AllowGet);
                }

                if (IsBookAlreadyReserved(dbEntities, bookReservation.Id))
                {
                    return Json(new { success = false, message = "Book is already reserved by you!" }, JsonRequestBehavior.AllowGet);
                }

                string msg = string.Empty;
                bookReservation.ReservedOn = DateTime.Now;
                bookReservation.UserId = CommonBL.UserId;
                bookReservation.BookCodeId = GetAvailbleBookCodeId(dbEntities, bookReservation.Id);
                if (bookReservation.BookCodeId == 0)
                {
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        return Json(new { success = false, message = msg }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Book is no more Available now!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    dbEntities.BookReservations.AddObject(bookReservation);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "Book reserved successfully!" + Environment.NewLine +"Please collect book from Library within 24 Hours." }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult CancelReserve(BookReservation bookReservation)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                int[] bookCodeIds = dbEntities.BookCodeMasters.Where(x => x.BookId == bookReservation.Id).Select(x => x.Id).ToArray();
                BookReservation bookReservationInDB = dbEntities.BookReservations.Where(x => !x.IsDeleted && x.UserId == CommonBL.UserId && bookCodeIds.Contains(x.BookCodeId)).FirstOrDefault<BookReservation>();
                if (bookReservationInDB == null)
                {
                    return Json(new { success = false, message = "Book Resevation".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (bookReservationInDB.IsDeleted)
                    {
                        return Json(new { success = true, message = "Book Resevation".ObjAlreadyDeleted() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        bookReservationInDB.IsDeleted = true;
                        dbEntities.ObjectStateManager.ChangeObjectState(bookReservationInDB, System.Data.EntityState.Modified);
                        dbEntities.SaveChanges();
                        return Json(new { success = true, message = "Book Resevation".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }

        private bool IsBookAlreadyIssued(LMSEntities dbEntities, int bookId)
        {
            return dbEntities.BookIssues.ToList().FirstOrDefault(
                x => dbEntities.BookCodeMasters.ToList().FirstOrDefault(y => y.Id == x.BookCodeId).BookId == bookId
                    && x.IssuedFor == CommonBL.UserId && x.ReturnedOn != null) != null;
        }

        private bool IsBookAlreadyReserved(LMSEntities dbEntities, int bookId)
        {
            List<BookCodeMaster> bookCodeMasters = dbEntities.BookCodeMasters.Where(x => x.BookId == bookId).ToList();
            if (bookCodeMasters != null && bookCodeMasters.Count > 0)
            {
                for (int i = 0; i < bookCodeMasters.Count; i++)
                {
                    if (dbEntities.BookReservations.ToList().Any(
                        x => x.BookCodeId == bookCodeMasters[i].Id && !x.IsDeleted && x.UserId == CommonBL.UserId && x.ReservedOn.AddDays(1) > DateTime.Now))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int GetAvailbleBookCodeId(LMSEntities dbEntities, int bookId)
        {
            List<BookCodeMaster> bookCodeMasters = dbEntities.BookCodeMasters.Where(x => x.BookId == bookId).ToList();
            if (bookCodeMasters != null && bookCodeMasters.Count > 0)
            {
                for (int i = 0; i < bookCodeMasters.Count; i++)
                {
                    if (!dbEntities.BookReservations.ToList().Any(
                        x => x.BookCodeId == bookCodeMasters[i].Id && !x.IsDeleted && x.ReservedOn.AddDays(1) > DateTime.Now))
                    {
                        return bookCodeMasters[i].Id;
                    }
                }
            }
            return 0;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
