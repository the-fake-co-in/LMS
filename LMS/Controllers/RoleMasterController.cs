using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class RoleMasterController : Controller
    {
        private LMSEntities dbEntities = new LMSEntities();

        private static List<RoleMaster> roles = new List<RoleMaster>();

        //
        // GET: /RoleMaster/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /RoleMaster/
        public ActionResult GetData(Utility.DisplayRecords displayRecords)
        {
            if (displayRecords == Utility.DisplayRecords.Default)
            {
                roles = dbEntities.RoleMasters.ToList<RoleMaster>();
                return Json(new { data = roles.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Active)
            {
                return Json(new { data = roles.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Deleted)
            {
                return Json(new { data = roles.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            {
                roles = dbEntities.RoleMasters.ToList<RoleMaster>();
                return Json(new { data = roles }, JsonRequestBehavior.AllowGet);
            }
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
                return View(dbEntities.RoleMasters.Where(x => x.Id == id).FirstOrDefault<RoleMaster>());
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
                    if (dbEntities.RoleMasters.ToArray().Any(x => x.Name.IsEqual(role.Name)))
                    {
                        return Json(new { success = false, message = "Role".objAlreadyExists("Name", role.Name) }, JsonRequestBehavior.AllowGet);
                    }

                    role.CreatedBy = CommonBL.UserId;
                    dbEntities.RoleMasters.AddObject(role);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "Role".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    role.ModifiedBy = CommonBL.UserId;
                    RoleMaster roleInDb = dbEntities.RoleMasters.Where(x => x.Id == role.Id).FirstOrDefault<RoleMaster>();
                    if (roleInDb == null)
                    {
                        return Json(new { success = false, message = "Role".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        roleInDb.ModifiedBy = CommonBL.UserId;
                        if (role.IsDeleted)
                        {
                            roleInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(roleInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            if (dbEntities.RoleMasters.ToArray().Any(x => x.Name.IsEqual(role.Name) && x.Id != role.Id))
                            {
                                return Json(new { success = false, message = "Role".objAlreadyExists("Name", role.Name) }, JsonRequestBehavior.AllowGet);
                            } 
                            
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
            dbEntities.Dispose();
            base.Dispose(disposing);
        }
    }
}