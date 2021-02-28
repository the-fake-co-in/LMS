using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class RoleMasterController : Controller
    {
        //
        // GET: /RoleMaster/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(GetAllRoleMaster());
        }

        IEnumerable<RoleMaster> GetAllRoleMaster()
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                return dbEntities.RoleMasters.ToList<RoleMaster>();
            }
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            RoleMaster role = new RoleMaster();
            if (id != 0)
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    role = dbEntities.RoleMasters.Where(x => x.Id == id).FirstOrDefault<RoleMaster>();
                }
            }
            return View(role);
        }

        [HttpPost]
        public ActionResult AddOrEdit(RoleMaster role)
        {
            try
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    role.CreatedOn = role.ModifiedOn = DateTime.Now;
                    if (role.Id == 0)
                    {
                        role.CreatedBy = 1;
                        dbEntities.RoleMasters.AddObject(role);
                        dbEntities.SaveChanges();
                    }
                    else
                    {
                        role.ModifiedBy = 1;
                        dbEntities.AttachTo("RoleMasters", role);
                        dbEntities.ObjectStateManager.ChangeObjectState(role, System.Data.EntityState.Modified);
                        dbEntities.SaveChanges();
                    }
                }
                return Json(new { success = true, html = Utilities.Utility.RenderRazorViewToString(this, "ViewAll", GetAllRoleMaster()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    RoleMaster role = dbEntities.RoleMasters.Where(x => x.Id == id).FirstOrDefault<RoleMaster>();
                    role.IsDeleted = true;
                    dbEntities.SaveChanges();
                }
                return Json(new { success = true, html = Utilities.Utility.RenderRazorViewToString(this, "ViewAll", GetAllRoleMaster()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}