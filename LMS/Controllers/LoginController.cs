using System.Linq;
using System.Web.Mvc;
using LMS.Models;
using LMS.Utilities;
using System.Collections.Generic;
using System.Web.UI;

namespace LMS.Controllers
{
    public class LoginController : Controller
    {
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
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
                            //ModelState.AddModelError("UserName", "Your account is blocked! Contact Admin to unblock.");
                            objUser.LoginErrorMessage = "Your account is blocked! Contact Admin to unblock.";
                            return View("Index", objUser);
                        }
                        else if (obj.IsDeleted)
                        {
                            //ModelState.AddModelError("UserName", "Your account is no more active!");
                            objUser.LoginErrorMessage = "Your account is no more active!";
                            return View("Index", objUser);
                        }
                        else if (EncryptDecrypt.Decrypt(obj.Password) != objUser.Password)
                        {
                            //ModelState.AddModelError("UserName", "Enter valid UserName & password!");
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
                        //ModelState.AddModelError("UserName", "Enter valid UserName & password!");
                        objUser.LoginErrorMessage = "Enter valid UserName & password!";
                        return View("Index", objUser);
                    }
                }
            }
            return View("Index", objUser);
        }

        //[ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        //[ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public string ForgotUserName(string email)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                UserDetail user = dbEntities.UserDetails.FirstOrDefault(x => x.Email.Trim().ToLower() == email.Trim().ToLower());
                if (user == null)
                {
                    return "Please Enter valid UserName!";
                }
                else
                {
                    if (user.IsBlocked)
                    {
                        return "Your account is blocked! Contact Admin to unblock.";
                    }
                    else if (user.IsDeleted)
                    {
                        return "Your account is no more active!";
                    }
                    else
                    {
                        return SendEmail.SendForgotUserNameEmail(user.FirstName + " " + user.LastName, user.UserName, user.Email);
                    }
                }
            }
        }

        //[ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public string ForgotPassword(string userName, string email)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                UserDetail user = dbEntities.UserDetails.FirstOrDefault(x => x.UserName.Trim().ToLower() == userName.Trim().ToLower() && x.Email.Trim().ToLower() == email.Trim().ToLower());
                if (user == null)
                {
                    return "Please Enter valid UserName & Email!";
                }
                else
                {
                    if (user.IsBlocked)
                    {
                        return "Your account is blocked! Contact Admin to unblock.";
                    }
                    else if (user.IsDeleted)
                    {
                        return "Your account is no more active!";
                    }
                    else
                    {
                        string otp = Utility.GenerateOTP();
                        string result = SendEmail.SendForgotPasswordEmail(user.FirstName + " " + user.LastName, user.UserName, user.Email, otp);
                        if (string.IsNullOrWhiteSpace(result))
                        {
                            IEnumerable<OTPDetail> otpdetails = dbEntities.OTPDetails.Where(x => x.UserId == user.UserId);
                            if (otpdetails != null && otpdetails.Count() > 0)
                            {
                                foreach (OTPDetail otpItem in otpdetails)
                                {
                                    dbEntities.OTPDetails.DeleteObject(otpItem);
                                }
                            }

                            OTPDetail otpDetail = new OTPDetail()
                            {
                                UserId = user.UserId,
                                OTP = otp,
                                ExpiresOn = System.DateTime.Now.AddMinutes(15)
                            };

                            dbEntities.OTPDetails.AddObject(otpDetail);
                            dbEntities.SaveChanges();
                        }
                        return string.Empty;
                    }
                }
            }
        }

        //[ValidateAntiForgeryToken]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult ResetPassword()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        [OutputCache(Location=OutputCacheLocation.None, NoStore=true)]
        public ActionResult ChangePassword(ChangePassword changePwd)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                UserMaster user = dbEntities.UserMasters.FirstOrDefault(x => x.UserName.Trim().ToLower() == changePwd.UserName.Trim().ToLower());
                if (user == null)
                {
                    changePwd.ChangePwdErrMsg = "Please Enter valid UserName!";
                    return View("ResetPassword", changePwd);

                }
                else
                {
                    if (user.IsBlocked)
                    {
                        changePwd.ChangePwdErrMsg = "Your account is blocked! Contact Admin to unblock.";
                        return View("ResetPassword", changePwd);
                    }
                    else if (user.IsDeleted)
                    {
                        changePwd.ChangePwdErrMsg = "Your account is no more active!";
                        return View("ResetPassword", changePwd);
                    }
                    else
                    {
                        OTPDetail otpDetail = dbEntities.OTPDetails.Where(x => x.UserId == user.UserId).ToList().OrderBy(x => x.ExpiresOn).Reverse().FirstOrDefault();
                        if (otpDetail == null || otpDetail.ExpiresOn <= System.DateTime.Now)
                        {
                            changePwd.ChangePwdErrMsg = "Link is invalid/expired. Please try again resetting password!";
                            return View("ResetPassword", changePwd);
                        }
                        else if(otpDetail.OTP.Trim() != changePwd.OTP.Trim())
                        {
                            changePwd.ChangePwdErrMsg = "Please enter correct OTP!";
                            return View("ResetPassword", changePwd);
                        }
                        else
                        {
                            user.Password = Utilities.EncryptDecrypt.Encrypt(changePwd.Password);
                            dbEntities.ObjectStateManager.ChangeObjectState(user, System.Data.EntityState.Modified);
                            dbEntities.SaveChanges();

                            Login login = new Login() { LoginErrorMessage = "Password changed successfully!" };
                            return View("Index", login);
                        }
                    }
                }
            }
        }
    }
}