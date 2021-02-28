﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserMaster objUser)
        {
            if (ModelState.IsValid)
            {
                using (LMSEntities db = new LMSEntities())
                {
                    var obj = db.UserMasters.Where(a => a.UserName.Trim().ToLower() == objUser.UserName.Trim().ToLower()
                        && a.Password == objUser.Password).FirstOrDefault();
                    if (obj != null)
                    {
                        if (obj.IsBlocked)
                        {
                            this.ModelState.AddModelError("AuthenticationFailed", "Your account is blocked! Contact Admin to unblock.");
                            return View("Login");
                        }
                        else if (obj.IsDeleted)
                        {
                            this.ModelState.AddModelError("AuthenticationFailed", "Your account is no more active!");
                            return View("Login");
                        }
                        else
                        {
                            Session["UserID"] = obj.UserId.ToString();
                            Session["UserName"] = obj.UserName.ToString();
                            return RedirectToAction("Home");
                        }
                    }
                    else
                    {
                        this.ModelState.AddModelError("AuthenticationFailed", "Enter valid UserName & password!");
                        return View("Login");
                    }
                }
            }
            return View(objUser);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public string VerifyLogin(string username, string password)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    return "Enter valid UserName!";
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    return "Enter valid password!";
                }
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
        [ValidateAntiForgeryToken]
        public ActionResult LMSDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}