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
    public class RoleMasterController : Controller
    {
        private LMSEntities db = new LMSEntities();

        //
        // GET: /RoleMaster/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /RoleMaster/
        public ActionResult GetData()
        {
            List<RoleMaster> roles = db.RoleMasters.ToList<RoleMaster>();
            return Json(new { data = roles }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult InsertOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new RoleMaster());
            }
            else
            {
                return View(db.RoleMasters.Where(x => x.Id == id).FirstOrDefault<RoleMaster>());
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(RoleMaster role)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                role.CreatedOn = role.ModifiedOn = DateTime.Now;

                if (role.Id == 0)
                {
                    role.CreatedBy = 1;
                    dbEntities.RoleMasters.AddObject(role);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "Role".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    RoleMaster roleInDb = dbEntities.RoleMasters.Where(x => x.Id == role.Id).FirstOrDefault<RoleMaster>();
                    if (roleInDb == null)
                    {
                        return Json(new { success = false, message = "Role".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (role.IsDeleted)
                        {
                            roleInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(roleInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            role.ModifiedBy = 1;
                            dbEntities.Detach(roleInDb);
                            dbEntities.AttachTo("RoleMasters", role);
                            dbEntities.ObjectStateManager.ChangeObjectState(role, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (roleInDb.IsDeleted)
                        {
                            return Json(new { success = true, message = "Role".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "Role".ObjUpdated() }, JsonRequestBehavior.AllowGet);
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