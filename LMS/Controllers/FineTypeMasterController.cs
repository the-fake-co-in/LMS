using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class FineTypeMasterController : Controller
    {
        private LMSEntities dbEntities = new LMSEntities();

        private static List<FineTypeMaster> fineTypes = new List<FineTypeMaster>();

        //
        // GET: /FineTypeMaster/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /FineTypeMaster/
        public ActionResult GetData(Utility.DisplayRecords displayRecords)
        {
            if (displayRecords == Utility.DisplayRecords.Default)
            {
                fineTypes = dbEntities.FineTypeMasters.ToList<FineTypeMaster>();
                return Json(new { data = fineTypes.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Active)
            {
                return Json(new { data = fineTypes.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Deleted)
            {
                return Json(new { data = fineTypes.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            {
                fineTypes = dbEntities.FineTypeMasters.ToList<FineTypeMaster>();
                return Json(new { data = fineTypes }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult InsertOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new FineTypeMaster());
            }
            else
            {
                return View(dbEntities.FineTypeMasters.Where(x => x.Id == id).FirstOrDefault<FineTypeMaster>());
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(FineTypeMaster fineType)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                fineType.CreatedOn = fineType.ModifiedOn = DateTime.Now;

                if (fineType.Id == 0)
                {
                    fineType.CreatedBy = 1;
                    dbEntities.FineTypeMasters.AddObject(fineType);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "FineType".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    FineTypeMaster fineTypeInDb = dbEntities.FineTypeMasters.Where(x => x.Id == fineType.Id).FirstOrDefault<FineTypeMaster>();
                    if (fineTypeInDb == null)
                    {
                        return Json(new { success = false, message = "FineType".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (fineType.IsDeleted)
                        {
                            fineTypeInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(fineTypeInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            fineType.ModifiedBy = 1;
                            dbEntities.Detach(fineTypeInDb);
                            dbEntities.AttachTo("FineTypeMasters", fineType);
                            dbEntities.ObjectStateManager.ChangeObjectState(fineType, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (fineTypeInDb.IsDeleted)
                        {
                            return Json(new { success = true, message = "FineType".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "FineType".ObjUpdated() }, JsonRequestBehavior.AllowGet);
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