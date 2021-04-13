using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Models;
using LMS.Controllers;

namespace LMS.Utilities
{
    public static class CommonBL
    {
        public static int UserId { get { return Convert.ToInt32(HttpContext.Current.Session["UserId"]); } }

        public static bool HasAuthorAccess { get { return HasWriteAccess("Author"); } }
        public static bool HasBookTypeAccess { get { return HasWriteAccess("Book Type"); } }
        public static bool HasBookAccess { get { return HasWriteAccess("Book"); } }
        public static bool HasUserAccess { get { return HasWriteAccess("User"); } }
        public static bool HasSearchBookAccess { get { return HasWriteAccess("Search Book"); } }
        public static bool HasReserveBookAccess { get { return HasWriteAccess("Reserve Book"); } }
        public static bool HasIssueBookAccess { get { return HasWriteAccess("Issue Book"); } }
        public static bool HasAddtowishlistAccess { get { return HasWriteAccess("Add to wishlist"); } }
        public static bool HasPendingFineAccess { get { return HasWriteAccess("Pending Fine"); } }
        public static bool HasFineHistoryAccess { get { return HasWriteAccess("Fine History"); } }
        public static bool HasGetFineAccess { get { return HasWriteAccess("Get Fine"); } }
        public static bool HasBookCodeAccess { get { return HasWriteAccess("Book Code"); } }
        public static bool HasBookFineAccess { get { return HasWriteAccess("Book Fine"); } }
        public static bool HasFineTypeAccess { get { return HasWriteAccess("Fine Type"); } }
        public static bool HasRoleMasterAccess { get { return HasWriteAccess("Role Master"); } }
        public static bool HasFormTypeAccess { get { return HasWriteAccess("Form Type"); } }

        public static bool HasWriteAccess(string formName)
        {
            string roleId = new LMSEntities().UserMasters.FirstOrDefault(x => x.UserId == UserId).RoleId.ToString();

            IEnumerable<FormMaster> forms = FormController.forms;
            forms = UserId == 1 ? forms : forms
                .Where(x => !x.IsDeleted && x.Name == formName && (x.WriteAccess == "0"
                    || (!string.IsNullOrWhiteSpace(x.WriteAccess) && x.WriteAccess.Split(',').Contains(roleId.ToString()))
                    || (!string.IsNullOrWhiteSpace(x.SpecialWriteAccess) && x.SpecialWriteAccess.Split(',').Contains(UserId.ToString()))));

            return forms != null && forms.Count() > 0;
        }

        public static IEnumerable<FormMaster> GetForms(int formtypeId)
        {
            IEnumerable<FormMaster> forms = GetForms();
            return forms.Where(x => x.FormTypeId == formtypeId).OrderBy(x => x.DisplayOrder);
        }

        public static IEnumerable<FormMaster> GetForms()
        {
            string roleId = new LMSEntities().UserMasters.FirstOrDefault(x => x.UserId == UserId).RoleId.ToString();

            IEnumerable<FormMaster> forms = FormController.forms;
            forms = UserId == 1 ? forms : forms
                .Where(x => !x.IsDeleted && (x.ReadAccess == "0" || x.WriteAccess == "0"
                    || (!string.IsNullOrWhiteSpace(x.ReadAccess) && x.ReadAccess.Split(',').Contains(roleId.ToString()))
                    || (!string.IsNullOrWhiteSpace(x.WriteAccess) && x.WriteAccess.Split(',').Contains(roleId.ToString()))
                    || (!string.IsNullOrWhiteSpace(x.SpecialReadAccess) && x.SpecialReadAccess.Split(',').Contains(UserId.ToString()))
                    || (!string.IsNullOrWhiteSpace(x.SpecialWriteAccess) && x.SpecialWriteAccess.Split(',').Contains(UserId.ToString()))));

            return forms;
        }
    }
}