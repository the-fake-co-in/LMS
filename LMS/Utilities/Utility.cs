using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Models;
using LMS.Controllers;

namespace LMS.Utilities
{
    public class Utility
    {
        public const string PROJECT_TITLE = "Library Management Software";

        public static LMSEntities dbEntities = new LMSEntities();

        public static IEnumerable<FormMaster> GetForms(int userId)
        {
            IEnumerable<FormMaster> forms = FormController.forms;

            forms = userId == 1 ? forms : forms
                .Where(x => x.ReadAcces == "0" || x.WriteAccess == "0"
                    || x.ReadAcces == userId.ToString()
                    || x.WriteAccess == userId.ToString());

            return forms;
        }

        public static IEnumerable<FormMaster> GetForms(int userId, int formtypeId)
        {
            IEnumerable<FormMaster> forms = GetForms(userId);
            return forms.Where(x => x.FormTypeId == formtypeId);
        }
    }
}