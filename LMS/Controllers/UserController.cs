using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class UserController : Controller
    {
        private LMSEntities dbEntities = new LMSEntities();

        private static List<UserDetail> userDetails = new List<UserDetail>();

        //
        // GET: /UserDetail/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /UserDetail/
        public ActionResult GetData(Utility.DisplayRecords displayRecords)
        {
            if (displayRecords == Utility.DisplayRecords.Default)
            {
                userDetails = dbEntities.UserDetails.ToList<UserDetail>();
                return Json(new { data = userDetails.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Active)
            {
                return Json(new { data = userDetails.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Deleted)
            {
                return Json(new { data = userDetails.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                userDetails = dbEntities.UserDetails.ToList<UserDetail>();
                return Json(new { data = userDetails }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult InsertOrUpdate(int userId = 0)
        {
            if (userId == 0)
            {
                return View(new UserDetail());
            }
            else
            {
                return View(dbEntities.UserDetails.Where(x => x.UserId == userId).FirstOrDefault<UserDetail>());
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(UserDetail userDetail)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                userDetail.CreatedOn = userDetail.ModifiedOn = DateTime.Now;

                if (userDetail.UserId == 0)
                {
                    userDetail.CreatedBy = 1;
                    dbEntities.UserDetails.AddObject(userDetail);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "User".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    UserDetail userInDb = dbEntities.UserDetails.Where(x => x.UserId == userDetail.UserId).FirstOrDefault<UserDetail>();
                    if (userInDb == null)
                    {
                        return Json(new { success = false, message = "User".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (userDetail.IsDeleted)
                        {
                            userInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(userInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            userDetail.ModifiedBy = 1;
                            dbEntities.Detach(userInDb);
                            dbEntities.AttachTo("UserDetails", userDetail);
                            dbEntities.ObjectStateManager.ChangeObjectState(userDetail, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (userInDb.IsDeleted)
                        {
                            return Json(new { success = true, message = "User".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "User".ObjUpdated() }, JsonRequestBehavior.AllowGet);
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