using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;

namespace LMS.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(Login objUser)
        {
            if (ModelState.IsValid)
            {
                using (LMSEntities db = new LMSEntities())
                {
                    var obj = db.UserMasters.Where(a => a.UserName.Trim().ToLower() == objUser.UserName.Trim().ToLower()).FirstOrDefault();
                    if (obj != null)
                    {
                        if (obj.IsBlocked)
                        {
                            ModelState.AddModelError("UserName", "Your account is blocked! Contact Admin to unblock.");
                            objUser.LoginErrorMessage = "Your account is blocked! Contact Admin to unblock.";
                            return View("Index", objUser);
                        }
                        else if (obj.IsDeleted)
                        {
                            ModelState.AddModelError("UserName", "Your account is no more active!");
                            objUser.LoginErrorMessage = "Your account is no more active!";
                            return View("Index", objUser);
                        }
                        else if(EncryptDecrypt.Decrypt(obj.Password) != objUser.Password)
                        {
                            ModelState.AddModelError("UserName", "Enter valid UserName & password!");
                            objUser.LoginErrorMessage = "Enter valid UserName & password!";
                            return View("Index", objUser);
                        }
                        else
                        {
                            Session["UserId"] = obj.UserId.ToString();
                            Session["UserName"] = obj.UserName.ToString();
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "Enter valid UserName & password!");
                        objUser.LoginErrorMessage = "Enter valid UserName & password!";
                        return View("Index", objUser);
                    }
                }
            }
            return View("Index", objUser);
        }

        //[ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}