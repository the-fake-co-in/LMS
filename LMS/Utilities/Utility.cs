using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using LMS.Controllers;
using LMS.Models;
using System.Web;

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

        public const int MAX_DAYS_FOR_ISSUE = 5;

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

        public static string objAlreadyExists(this string table, string fieldName, string fieldValue)
        {
            return string.Format("{0} already exists with same {1}: {2}", table, fieldName, fieldValue);
        }

        public static string ObjAlreadyDeleted(this string input)
        {
            return string.Format("{0} is already deleted!", input);
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

        public static bool IsEqual(this string input, string compareTo)
        {
            return input.Trim().ToLower() == compareTo.Trim().ToLower();
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