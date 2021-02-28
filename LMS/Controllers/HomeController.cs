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
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            if (userId != 0)
            {
                using (LMSEntities dbEntities = new LMSEntities())
                {
                    UserDetail userDetail = dbEntities.UserDetails.FirstOrDefault(x => x.UserId == userId);
                    if (userDetail == null)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        return View(userDetail);
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
