using System.Collections.Generic;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class FormController : Controller
    {
        private static LMSEntities dbEntities = Utility.dbEntities;

        [HttpGet]
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