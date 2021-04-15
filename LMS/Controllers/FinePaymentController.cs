using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class FinePaymentController : Controller
    {
        private static List<GetFinePayment> finePayment = null;

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult GetFinePayments()
        {
            using (LMSEntities dbEntitiy = new LMSEntities())
            {
                finePayment = dbEntitiy.GetFinePayment().ToList();
            }
            return Json(new { data = finePayment }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDetails(int id = 0)
        {
            if (id == 0)
            {
                return View(new BookIssue());
            }
            else
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    return View(dbEntities.FinePayments.Where(x => x.Id == id).FirstOrDefault<FinePayment>());
                }
            }
        }

        [HttpPost]
        public ActionResult PayFine(FinePayment finePayment)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                finePayment.CreatedOn = finePayment.ModifiedOn = DateTime.Now;

                if (finePayment.Id == 0)
                {
                    finePayment.CreatedBy = CommonBL.UserId;
                    finePayment.PaidOn = DateTime.Now;
                    dbEntities.FinePayments.AddObject(finePayment);

                    int bookCodeId = dbEntities.BookIssues.FirstOrDefault(x => x.Id == finePayment.BookIssueId).BookCodeId;
                    BookCodeMaster bookCodeMaster = dbEntities.BookCodeMasters.FirstOrDefault(x => x.Id == bookCodeId);
                    bookCodeMaster.IsIssued = false;
                    dbEntities.ObjectStateManager.ChangeObjectState(bookCodeMaster, System.Data.EntityState.Modified);

                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "BookIssue".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    finePayment.ModifiedBy = CommonBL.UserId;

                    BookIssue bookIssueInDB = dbEntities.BookIssues.Where(x => x.Id == finePayment.Id).FirstOrDefault<BookIssue>();
                    if (bookIssueInDB == null)
                    {
                        return Json(new { success = false, message = "BookIssue".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        dbEntities.Detach(bookIssueInDB);
                        dbEntities.AttachTo("BookIssues", finePayment);
                        dbEntities.ObjectStateManager.ChangeObjectState(finePayment, System.Data.EntityState.Modified);
                        dbEntities.SaveChanges();
                        return Json(new { success = true, message = "BookIssue".ObjUpdated() }, JsonRequestBehavior.AllowGet);
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