using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Utilities
{
    public class DropdownListHelper
    {
        public static List<SelectListItem> DDLForAuthorMaster()
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                return dbEntities.AuthorMasters
                    .Where(x => !x.IsDeleted).ToList()
                    .Select(y => new SelectListItem() { Text = y.Name, Value = y.Id.ToString() })
                    .OrderBy(z => z.Value).ToList<SelectListItem>();
            }
        }

        public static List<SelectListItem> DDLForBookTypeMaster()
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                return dbEntities.BookTypeMasters
                    .Where(x => !x.IsDeleted).ToList()
                    .Select(y => new SelectListItem() { Text = y.Type, Value = y.Id.ToString() })
                    .OrderBy(z => z.Value).ToList<SelectListItem>();
            }
        }

        public static List<SelectListItem> DDLForBookMaster()
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                return dbEntities.BookMasters
                    .Where(x => !x.IsDeleted).ToList()
                    .Select(y => new SelectListItem() { Text = y.Name, Value = y.Id.ToString() })
                    .OrderBy(z => z.Value).ToList<SelectListItem>();
            }
        }

        public static List<SelectListItem> DDLForFineTypeMaster()
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                return dbEntities.FineTypeMasters
                    .Where(x => !x.IsDeleted).ToList()
                    .Select(y => new SelectListItem() { Text = y.Type, Value = y.Id.ToString() })
                    .OrderBy(z => z.Value).ToList<SelectListItem>();
            }
        }
    }
}