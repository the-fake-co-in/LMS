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
        public static List<SelectListItem> DDLForGender()
        {
            List<SelectListItem> lstStates = new List<SelectListItem>();
            lstStates.Add(new SelectListItem() { Value = "M", Text = "Male" });
            lstStates.Add(new SelectListItem() { Value = "F", Text = "Female" });
            return lstStates;
        }

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

        public static List<SelectListItem> DDLForUserMaster()
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                return dbEntities.UserDetails
                    .Where(x => !x.IsDeleted).ToList()
                    .Select(y => new SelectListItem() { Text = y.FirstName + " " + y.LastName, Value = y.UserId.ToString() })
                    .OrderBy(z => z.Value).ToList<SelectListItem>();
            }
        }

        public static List<SelectListItem> DDLForIssueBook()
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                return dbEntities.UserDetails
                    .Where(x => !x.IsDeleted && (x.RoleId == 1 || x.RoleId == 3)).ToList()
                    .Select(y => new SelectListItem() { Text = y.FirstName + " " + y.LastName, Value = y.UserId.ToString() })
                    .OrderBy(z => z.Value).ToList<SelectListItem>();
            }
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

        public static List<SelectListItem> DDLForBookCodeMaster(int bookCodeId)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                return (from BCM in dbEntities.BookCodeMasters.ToList()
                        join BM in dbEntities.BookMasters.ToList()
                        on BCM.BookId equals BM.Id
                        where BCM.Id == bookCodeId || (!BCM.IsDeleted && !BM.IsDeleted && !BCM.IsLost
                        && !BCM.IsIssued && CommonBL.GetAvailbleBookCodeId(dbEntities, BCM.BookId) > 0)
                        select new SelectListItem() { Text = BM.Name + " - " + BCM.BookCode, Value = BCM.Id.ToString() })
                       .OrderBy(x => x.Text).ToList<SelectListItem>();
            }
        }

        public static List<SelectListItem> DDLForBookCodeForFinePayment(int bookIssueId)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            using (LMSEntities dbEntities = new LMSEntities())
            {
                Dictionary<int, int> dictIds = dbEntities.BookIssues.Where(x => !x.IsDeleted && x.ReceivedBy == 0).ToDictionary(x => x.Id, x => x.BookCodeId);
                foreach (int key in dictIds.Keys)
			    {
                    int bookId = dbEntities.BookCodeMasters.Where(x => x.Id == dictIds[key]).Select(x => x.BookId).First();
                    string bookCode = dbEntities.BookCodeMasters.Where(x => x.Id == dictIds[key]).Select(x => x.BookCode).First();
                    string bookName = dbEntities.BookMasters.Where(x => x.Id == bookId).Select(x => x.Name).First();

                    selectListItems.Add(new SelectListItem() { Text = bookName + " - " + bookCode, Value = key.ToString() });
			    }
            }
            return selectListItems.OrderBy(x => x.Text).ToList<SelectListItem>();
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

        public static List<SelectListItem> DDLForRoleMaster()
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                return dbEntities.RoleMasters
                    .Where(x => !x.IsDeleted).ToList()
                    .Select(y => new SelectListItem() { Text = y.Name, Value = y.Id.ToString() })
                    .OrderBy(z => z.Value).ToList<SelectListItem>();
            }
        }
    }
}