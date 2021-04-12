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
        public static List<SelectListItem> DDLForState()
        {
            List<SelectListItem> lstStates = new List<SelectListItem>();
            lstStates.Add(new SelectListItem() { Value = "Andaman and Nicobar Islands", Text = "Andaman and Nicobar Islands" });
            lstStates.Add(new SelectListItem() { Value = "Andra Pradesh", Text = "Andra Pradesh" });
            lstStates.Add(new SelectListItem() { Value = "Arunachal Pradesh", Text = "Arunachal Pradesh" });
            lstStates.Add(new SelectListItem() { Value = "Assam", Text = "Assam" });
            lstStates.Add(new SelectListItem() { Value = "Bihar", Text = "Bihar" });
            lstStates.Add(new SelectListItem() { Value = "Chhattisgarh", Text = "Chhattisgarh" });
            lstStates.Add(new SelectListItem() { Value = "Dadar and Nagar Haveli", Text = "Dadar and Nagar Haveli" });
            lstStates.Add(new SelectListItem() { Value = "Daman and Diu", Text = "Daman and Diu" });
            lstStates.Add(new SelectListItem() { Value = "Delhi", Text = "Delhi" });
            lstStates.Add(new SelectListItem() { Value = "Goa", Text = "Goa" });
            lstStates.Add(new SelectListItem() { Value = "Gujarat", Text = "Gujarat" });
            lstStates.Add(new SelectListItem() { Value = "Haryana", Text = "Haryana" });
            lstStates.Add(new SelectListItem() { Value = "Himachal Pradesh", Text = "Himachal Pradesh" });
            lstStates.Add(new SelectListItem() { Value = "Jammu and Kashmir", Text = "Jammu and Kashmir" });
            lstStates.Add(new SelectListItem() { Value = "Jharkhand", Text = "Jharkhand" });
            lstStates.Add(new SelectListItem() { Value = "Karnataka", Text = "Karnataka" });
            lstStates.Add(new SelectListItem() { Value = "Kerala", Text = "Kerala" });
            lstStates.Add(new SelectListItem() { Value = "Lakshadeep", Text = "Lakshadeep" });
            lstStates.Add(new SelectListItem() { Value = "Madya Pradesh", Text = "Madya Pradesh" });
            lstStates.Add(new SelectListItem() { Value = "Maharashtra", Text = "Maharashtra" });
            lstStates.Add(new SelectListItem() { Value = "Manipur", Text = "Manipur" });
            lstStates.Add(new SelectListItem() { Value = "Meghalaya", Text = "Meghalaya" });
            lstStates.Add(new SelectListItem() { Value = "Mizoram", Text = "Mizoram" });
            lstStates.Add(new SelectListItem() { Value = "Nagaland", Text = "Nagaland" });
            lstStates.Add(new SelectListItem() { Value = "Orissa", Text = "Orissa" });
            lstStates.Add(new SelectListItem() { Value = "Pondicherry", Text = "Pondicherry" });
            lstStates.Add(new SelectListItem() { Value = "Punjab", Text = "Punjab" });
            lstStates.Add(new SelectListItem() { Value = "Rajasthan", Text = "Rajasthan" });
            lstStates.Add(new SelectListItem() { Value = "Sikkim", Text = "Sikkim" });
            lstStates.Add(new SelectListItem() { Value = "Tamil Nadu", Text = "Tamil Nadu" });
            lstStates.Add(new SelectListItem() { Value = "Telagana", Text = "Telagana" });
            lstStates.Add(new SelectListItem() { Value = "Tripura", Text = "Tripura" });
            lstStates.Add(new SelectListItem() { Value = "Uttaranchal", Text = "Uttaranchal" });
            lstStates.Add(new SelectListItem() { Value = "Uttar Pradesh", Text = "Uttar Pradesh" });
            lstStates.Add(new SelectListItem() { Value = "West Bengal", Text = "West Bengal" });
            return lstStates;
        }

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