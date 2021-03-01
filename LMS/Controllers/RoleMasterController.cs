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
            List<RoleMaster> Roles = db.RoleMasters.ToList<RoleMaster>();
            return Json(new { data = Roles }, JsonRequestBehavior.AllowGet);
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
        public ActionResult InsertUpdateOrDelete(RoleMaster Role)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                Role.CreatedOn = Role.ModifiedOn = DateTime.Now;

                if (Role.Id == 0)
                {
                    Role.CreatedBy = 1;
                    dbEntities.RoleMasters.AddObject(Role);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "Role".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    RoleMaster RoleInDb = dbEntities.RoleMasters.Where(x => x.Id == Role.Id).FirstOrDefault<RoleMaster>();
                    if (RoleInDb == null)
                    {
                        return Json(new { success = false, message = "Role".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (Role.IsDeleted)
                        {
                            RoleInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(RoleInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            Role.ModifiedBy = 1;
                            dbEntities.Detach(RoleInDb);
                            dbEntities.AttachTo("RoleMasters", Role);
                            dbEntities.ObjectStateManager.ChangeObjectState(Role, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (RoleInDb.IsDeleted)
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