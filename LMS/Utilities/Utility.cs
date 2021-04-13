using System.Collections.Generic;
using System.Linq;
using LMS.Models;
using LMS.Controllers;
using System.Web.Mvc;
using System.IO;
using System;

namespace LMS.Utilities
{
    public static class Utility
    {
        public const string PROJECT_TITLE = "Library Management Software";

        public const string MAX_DATETIME = "9999-12-31";

        public enum DisplayRecords
        {
            Default,
            Active,
            Deleted,
            All
        }

        public static string AddNewObj(this string input)
        {
            return string.Format("Add new {0}", input);
        }

        public static string ObjCreated(this string input)
        {
            return string.Format("{0} inserted successfully!", input);
        }

        public static string ObjUpdated(this string input)
        {
            return string.Format("{0} updated successfully!", input);
        }

        public static string ObjDeleted(this string input)
        {
            return string.Format("{0} deleted successfully!", input);
        }

        public static string ObjNotFoundInDb(this string input)
        {
            return string.Format("Database Entry not found for selected {0}!", input);
        }

        public static string NoDataFound(this string input)
        {
            return string.Format("No Data found for {0}. Please click on <b>Add New {0}</b> Button!", input);
        }

        public static string DeleteConfirm(this string input)
        {
            return string.Format("Are you sure, you want to delete the selected {0}?", input);
        }

        public static IEnumerable<FormMaster> GetForms(int userId)
        {
            string roleId = new LMSEntities().UserMasters.FirstOrDefault(x => x.UserId == userId).RoleId.ToString();

            IEnumerable<FormMaster> forms = FormController.forms;
            forms = userId == 1 ? forms : forms
                .Where(x => !x.IsDeleted && (x.ReadAccess == "0" || x.WriteAccess == "0"
                    || x.ReadAccess.Split(',').Contains(roleId.ToString())
                    || x.WriteAccess.Split(',').Contains(roleId.ToString())
                    || x.SpecialReadAccess.Split(',').Contains(userId.ToString())
                    || x.SpecialWriteAccess.Split(',').Contains(userId.ToString())));

            return forms;
        }

        public static IEnumerable<FormMaster> GetForms(int userId, int formtypeId)
        {
            IEnumerable<FormMaster> forms = GetForms(userId);
            return forms.Where(x => x.FormTypeId == formtypeId).OrderBy(x => x.DisplayOrder);
        }

        public static string RenderRazorViewToString(Controller controller, string viewName, object model = null)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult;
                viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public static string GenerateOTP()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}