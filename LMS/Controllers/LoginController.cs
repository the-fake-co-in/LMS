using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(UserMaster objUser)
        //{
        //    if (true || ModelState.IsValid)
        //    {
        //        using (LMSEntities db = new LMSEntities())
        //        {
        //            var obj = db.UserMasters.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
        //            if (obj != null)
        //            {
        //                Session["UserID"] = obj.UserId.ToString();
        //                Session["UserName"] = obj.UserName.ToString();
        //                return RedirectToAction("LMSDashboard");
        //            }
        //            else
        //            {
        //                this.ModelState.AddModelError("AuthenticationFailed", "Enter valid UserName & password!");
        //                return View("Login");
        //            }
        //        }
        //    }
        //    return View(objUser);
        //}

        [HttpGet]
        public string VerifyLogin(string username, string password)
        {
            if (true || ModelState.IsValid)
            {
                using (LMSEntities db = new LMSEntities())
                {
                    var obj = db.UserMasters.Where(a => a.UserName.Equals(username) && a.Password.Equals(password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return "Success";
                    }
                    else
                    {
                        this.ModelState.AddModelError("AuthenticationFailed", "Enter valid UserName & password!");
                        return "Enter valid UserName & password!";
                    }
                }
            }
            return "Failed!";
        }

        [HttpGet]
        public ActionResult LMSDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
        }
    }
}
