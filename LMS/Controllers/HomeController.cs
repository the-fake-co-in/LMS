using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS;
using LMS.Models;
using WebMatrix.WebData;
using System.Web.UI.HtmlControls;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Home()
        {
            //WebSecurity.Logout();
            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public string Login(string username, string password)
        {
            using (LMSEntities db = new LMSEntities())
            {
                var obj = db.UserMasters.Where(a => a.UserName.Trim().ToLower() == username.Trim().ToLower()
                    && a.Password == password).FirstOrDefault();
                if (obj != null)
                {
                    if (obj.IsBlocked)
                    {
                        return "Error: Your account is blocked! Contact Admin to unblock.";
                    }
                    else if (obj.IsDeleted)
                    {
                        return "Error: Your account is no more active!";
                    }
                    else
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return "Success";
                    }
                }
                else
                {
                    return "Error: Enter valid UserName & password!";
                }
            }
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public string Logout()
        {
            Session["UserId"] = null;
            //WebSecurity.Logout();
            return "Success";
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Dashboard()
        {
            if (Session["UserID"] != null)
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    int userId = Convert.ToInt32(Session["UserID"]);
                    UserDetail userDetail = dbEntities.UserDetails.FirstOrDefault(x => x.UserId == userId);
                    if (userDetail != null)
                    {
                        return View(userDetail);
                    }
                    else
                    {
                        return RedirectToAction("Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Home");
            }
        }
    }
}
