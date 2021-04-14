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
        private static List<BookWishList> bookWishList = new List<BookWishList>();
        private static List<GetBookIssue> bookIssues = new List<GetBookIssue>();

        #region Book Search/Reserve

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
                        availableBook.IsAlreadyReserved = CommonBL.IsBookAlreadyReserved(dbEntitiy, availableBook.Id);
                        availableBook.IsAvailable = CommonBL.GetAvailbleBookCodeId(dbEntitiy, availableBook.Id) > 0;
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
                if (CommonBL.IsBookAlreadyIssued(dbEntities, bookReservation.Id))
                {
                    return Json(new { success = false, message = "Book is already issued by you!" }, JsonRequestBehavior.AllowGet);
                }

                if (CommonBL.IsBookAlreadyReserved(dbEntities, bookReservation.Id))
                {
                    return Json(new { success = false, message = "Book is already reserved by you!" }, JsonRequestBehavior.AllowGet);
                }

                string msg = string.Empty;
                bookReservation.ReservedOn = DateTime.Now;
                bookReservation.UserId = CommonBL.UserId;
                bookReservation.BookCodeId = CommonBL.GetAvailbleBookCodeId(dbEntities, bookReservation.Id);
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
                    return Json(new { success = true, message = "Book reserved successfully!" + Environment.NewLine + "Please collect book from Library within 24 Hours." }, JsonRequestBehavior.AllowGet);
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

        #endregion

        #region Add To WishList

        public ActionResult AddToWishlist()
        {
            return View();
        }

        public ActionResult GetBookWishList(Utility.DisplayRecords displayRecords)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                if (displayRecords == Utility.DisplayRecords.Default)
                {
                    bookWishList = dbEntities.BookWishLists.ToList<BookWishList>();
                    return Json(new { data = bookWishList.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
                }
                else if (displayRecords == Utility.DisplayRecords.Active)
                {
                    return Json(new { data = bookWishList.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
                }
                else if (displayRecords == Utility.DisplayRecords.Deleted)
                {
                    return Json(new { data = bookWishList.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
                }
                {
                    bookWishList = dbEntities.BookWishLists.ToList<BookWishList>();
                    return Json(new { data = bookWishList }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpGet]
        public ActionResult InsertOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new BookWishList());
            }
            else
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    return View(dbEntities.BookWishLists.Where(x => x.Id == id).FirstOrDefault<BookWishList>());
                }
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(BookWishList bookWish)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                bookWish.CreatedOn = bookWish.ModifiedOn = DateTime.Now;

                if (bookWish.Id == 0)
                {
                    bookWish.CreatedBy = CommonBL.UserId;
                    dbEntities.BookWishLists.AddObject(bookWish);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "BookWish".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    bookWish.ModifiedBy = CommonBL.UserId;

                    BookWishList bookWishInDB = dbEntities.BookWishLists.Where(x => x.Id == bookWish.Id).FirstOrDefault<BookWishList>();
                    if (bookWishInDB == null)
                    {
                        return Json(new { success = false, message = "BookWish".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (bookWish.IsDeleted)
                        {
                            if (bookWishInDB.IsDeleted)
                            {
                                dbEntities.ObjectStateManager.ChangeObjectState(bookWishInDB, System.Data.EntityState.Modified);
                                return Json(new { success = false, message = "BookWish".ObjAlreadyDeleted() }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                bookWishInDB.IsDeleted = true;
                                dbEntities.ObjectStateManager.ChangeObjectState(bookWishInDB, System.Data.EntityState.Modified);
                            }
                        }
                        else
                        {
                            dbEntities.Detach(bookWishInDB);
                            dbEntities.AttachTo("BookWishLists", bookWish);
                            dbEntities.ObjectStateManager.ChangeObjectState(bookWish, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (bookWishInDB.IsDeleted)
                        {
                            return Json(new { success = true, message = "BookWish".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "BookWish".ObjUpdated() }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
        }

        #endregion

        #region Issue Book
        public ActionResult Issue()
        {
            return View();
        }

        public ActionResult GetIssuedBooks(Utility.DisplayRecords displayRecords)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                if (displayRecords == Utility.DisplayRecords.Default)
                {
                    bookIssues = dbEntities.GetBookIssue().ToList<GetBookIssue>();
                    return Json(new { data = bookIssues.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
                }
                else if (displayRecords == Utility.DisplayRecords.Active)
                {
                    return Json(new { data = bookIssues.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
                }
                else if (displayRecords == Utility.DisplayRecords.Deleted)
                {
                    return Json(new { data = bookIssues.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    bookIssues = dbEntities.GetBookIssue().ToList<GetBookIssue>();
                    return Json(new { data = bookIssues }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpGet]
        public ActionResult GetIssuedBook(int id = 0)
        {
            if (id == 0)
            {
                return View(new BookIssue());
            }
            else
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    return View(dbEntities.BookIssues.Where(x => x.Id == id).FirstOrDefault<BookIssue>());
                }
            }
        }

        [HttpPost]
        public ActionResult IssueBook(BookIssue bookIssue)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                bookIssue.CreatedOn = bookIssue.ModifiedOn = DateTime.Now;

                if (bookIssue.Id == 0)
                {
                    bookIssue.CreatedBy = CommonBL.UserId;
                    bookIssue.IssuedOn = DateTime.Now;
                    dbEntities.BookIssues.AddObject(bookIssue);

                    BookCodeMaster bookCodeMaster = dbEntities.BookCodeMasters.FirstOrDefault(x => x.Id == bookIssue.BookCodeId);
                    bookCodeMaster.IsIssued = true;
                    dbEntities.ObjectStateManager.ChangeObjectState(bookCodeMaster, System.Data.EntityState.Modified);

                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "BookIssue".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    bookIssue.ModifiedBy = CommonBL.UserId;

                    BookIssue bookIssueInDB = dbEntities.BookIssues.Where(x => x.Id == bookIssue.Id).FirstOrDefault<BookIssue>();
                    if (bookIssueInDB == null)
                    {
                        return Json(new { success = false, message = "BookIssue".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        int bookCodeId = dbEntities.BookIssues.FirstOrDefault(x => x.Id == bookIssue.Id).BookCodeId;
                        if (bookIssue.IsDeleted)
                        {
                            if (bookIssueInDB.IsDeleted)
                            {
                                dbEntities.ObjectStateManager.ChangeObjectState(bookIssueInDB, System.Data.EntityState.Modified);
                                return Json(new { success = false, message = "BookIssue".ObjAlreadyDeleted() }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                bookIssueInDB.IsDeleted = true;
                                dbEntities.ObjectStateManager.ChangeObjectState(bookIssueInDB, System.Data.EntityState.Modified);
                            }
                            BookCodeMaster bookCodeMaster = dbEntities.BookCodeMasters.FirstOrDefault(x => x.Id == bookCodeId);
                            dbEntities.ObjectStateManager.ChangeObjectState(bookCodeMaster, System.Data.EntityState.Modified);
                            bookCodeMaster.IsIssued = false;
                        }
                        else
                        {
                            bookIssue.ReturnedOn = DateTime.Now;

                            if (bookIssue.BookCodeId != bookIssueInDB.BookCodeId)
                            {
                                BookCodeMaster bookCodeMaster1 = dbEntities.BookCodeMasters.FirstOrDefault(x => x.Id == bookIssue.BookCodeId);
                                bookCodeMaster1.IsIssued = true;
                                dbEntities.ObjectStateManager.ChangeObjectState(bookCodeMaster1, System.Data.EntityState.Modified);
                                
                                BookCodeMaster bookCodeMaster2 = dbEntities.BookCodeMasters.FirstOrDefault(x => x.Id == bookIssueInDB.BookCodeId);
                                bookCodeMaster2.IsIssued = false;
                                dbEntities.ObjectStateManager.ChangeObjectState(bookCodeMaster2, System.Data.EntityState.Modified);
                            }

                            dbEntities.Detach(bookIssueInDB);
                            dbEntities.AttachTo("BookIssues", bookIssue);
                            dbEntities.ObjectStateManager.ChangeObjectState(bookIssue, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (bookIssueInDB.IsDeleted)
                        {
                            return Json(new { success = true, message = "BookIssue".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "BookIssue".ObjUpdated() }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
