using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class FormController : Controller
    {
        private static LMS.LMSEntities dbEntities = LMS.Utilities.Utility.dbEntities;

        public ActionResult Index()
        {
            return View();
        }

        private static IEnumerable<FormTypeMaster> _formTypes;
        public static IEnumerable<FormTypeMaster> formTypes
        {
            get
            {
                if (_formTypes == null)
                {
                    _formTypes = dbEntities.FormTypeMasters;
                }
                return _formTypes;
            }
            set
            {
                _formTypes = value;
            }
        }

        private static IEnumerable<FormMaster> _forms;
        public static IEnumerable<FormMaster> forms
        {
            get
            {
                if (_forms == null)
                {
                    forms = dbEntities.FormMasters;
                }
                return _forms;
            }
            set
            {
                _forms = value;
            }
        }
    }
}