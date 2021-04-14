using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class FormTypeMasterController : Controller
    {
        private LMSEntities dbEntities = new LMSEntities();

        private static List<FormTypeMaster> formTypes = new List<FormTypeMaster>();

        //
        // GET: /FormTypeMaster/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /FormTypeMaster/
        public ActionResult GetData(Utility.DisplayRecords displayRecords)
        {
            if (displayRecords == Utility.DisplayRecords.Default)
            {
                formTypes = dbEntities.FormTypeMasters.ToList<FormTypeMaster>();
                return Json(new { data = formTypes.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Active)
            {
                return Json(new { data = formTypes.Where(x => !x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            else if (displayRecords == Utility.DisplayRecords.Deleted)
            {
                return Json(new { data = formTypes.Where(x => x.IsDeleted) }, JsonRequestBehavior.AllowGet);
            }
            {
                formTypes = dbEntities.FormTypeMasters.ToList<FormTypeMaster>();
                return Json(new { data = formTypes }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult InsertOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new FormTypeMaster());
            }
            else
            {
                return View(dbEntities.FormTypeMasters.Where(x => x.Id == id).FirstOrDefault<FormTypeMaster>());
            }
        }

        [HttpPost]
        public ActionResult InsertUpdateOrDelete(FormTypeMaster formType)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                formType.CreatedOn = formType.ModifiedOn = DateTime.Now;

                if (formType.Id == 0)
                {
                    if (dbEntities.FormTypeMasters.ToArray().Any(x => x.Type.IsEqual(formType.Type)))
                    {
                        return Json(new { success = false, message = "FormType".objAlreadyExists("Type", formType.Type) }, JsonRequestBehavior.AllowGet);
                    }

                    formType.CreatedBy = CommonBL.UserId;
                    dbEntities.FormTypeMasters.AddObject(formType);
                    dbEntities.SaveChanges();
                    return Json(new { success = true, message = "FormType".ObjCreated() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    formType.ModifiedBy = CommonBL.UserId;
                    FormTypeMaster formTypeInDb = dbEntities.FormTypeMasters.Where(x => x.Id == formType.Id).FirstOrDefault<FormTypeMaster>();
                    if (formTypeInDb == null)
                    {
                        return Json(new { success = false, message = "FormType".ObjNotFoundInDb() }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        formTypeInDb.ModifiedBy = CommonBL.UserId;
                        if (formType.IsDeleted)
                        {
                            formTypeInDb.IsDeleted = true;
                            dbEntities.ObjectStateManager.ChangeObjectState(formTypeInDb, System.Data.EntityState.Modified);
                        }
                        else
                        {
                            if (dbEntities.FormTypeMasters.ToArray().Any(x => x.Type.IsEqual(formType.Type) && x.Id != formType.Id))
                            {
                                return Json(new { success = false, message = "FormType".objAlreadyExists("Type", formType.Type) }, JsonRequestBehavior.AllowGet);
                            }

                            dbEntities.Detach(formTypeInDb);
                            dbEntities.AttachTo("FormTypeMasters", formType);
                            dbEntities.ObjectStateManager.ChangeObjectState(formType, System.Data.EntityState.Modified);
                        }
                        dbEntities.SaveChanges();

                        if (formTypeInDb.IsDeleted)
                        {
                            return Json(new { success = true, message = "FormType".ObjDeleted() }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, message = "FormType".ObjUpdated() }, JsonRequestBehavior.AllowGet);
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