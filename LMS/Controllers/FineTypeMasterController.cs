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
                    if (dbEntities.FineTypeMasters.ToArray().Any(x => x.Type.IsEqual(fineType.Type)))
                    {
                        return Json(new { success = false, message = "FineType".objAlreadyExists("Type", fineType.Type) }, JsonRequestBehavior.AllowGet);
                    }

                    fineType.CreatedBy = CommonBL.UserId;
                    dbEntities.FineTypeMasters.AddObject(fineType);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "FineType".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    fineType.ModifiedBy = CommonBL.UserId;
                    FineTypeMaster fineTypeInDb = dbEntities.FineTypeMasters.Where(x => x.Id == fineType.Id).FirstOrDefault<FineTypeMaster>();
                    if (fineTypeInDb == null)
                    {
                        return Json(new { success = false, message = "FineType".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        fineTypeInDb.ModifiedBy = CommonBL.UserId;
                        if (fineType.IsDeleted)
                        {
                            fineTypeInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(fineTypeInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            if (dbEntities.FineTypeMasters.ToArray().Any(x => x.Type.IsEqual(fineType.Type) && x.Id != fineType.Id))
                            {
                                return Json(new { success = false, message = "FineType".objAlreadyExists("Type", fineType.Type) }, JsonRequestBehavior.AllowGet);
                            }

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