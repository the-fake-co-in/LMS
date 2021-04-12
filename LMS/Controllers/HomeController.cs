using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using System.IO;
using LMS.Utilities;

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
                    UserInfo UserInfo = dbEntities.UserInfoes.FirstOrDefault(x => x.Userid == userId);
                    if (UserInfo == null)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        return View(UserInfo);
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult UpdateProfile(UserInfo userInfo)
        {
            using (LMSEntities dbEntities = new LMSEntities())
            {
                UserInfo userInDb = dbEntities.UserInfoes.Where(x => x.Userid == userInfo.Userid).FirstOrDefault<UserInfo>();
                dbEntities.Detach(userInDb);
                dbEntities.AttachTo("UserInfoes", userInfo);
                dbEntities.ObjectStateManager.ChangeObjectState(userInfo, System.Data.EntityState.Modified);
                dbEntities.SaveChanges();
                return View("Index");
            }
        }

        public string ChangeProfPic(FormCollection fc, HttpPostedFileBase file)
        {
            try
            {
                string[] allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
                string Image_url = file.ToString(); //getting complete url  
                var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    int userId = Convert.ToInt32(Session["UserId"]);
                    string serverFileName = userId + ext; //appending the name with id  
                    // store the file inside ~/project folder(Img)
                    string path = Path.Combine(Server.MapPath("../Content/Images/ProfilePhotos"), serverFileName);
                    file.SaveAs(path);

                    serverFileName = serverFileName.Replace(".", DateTime.Now.ToString("_yyMMddfffffff."));
                    path = Path.Combine(Server.MapPath("../Content/Images/ProfilePhotos/Temp"), serverFileName);
                    file.SaveAs(path);

                    return "../Content/Images/ProfilePhotos/Temp/" + serverFileName;
                }
                return "";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string GetProfPic()
        {
            try
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                string path = Path.Combine(Server.MapPath("../Content/Images/ProfilePhotos"));
                string[] allFiles = System.IO.Directory.GetFiles(path);
                string sourceFileName = allFiles.FirstOrDefault(x => x.Contains(userId.ToString() + "."));
                if (!string.IsNullOrWhiteSpace(sourceFileName)) //check what type of extension  
                {
                    string tempFileName = sourceFileName.Replace("\\ProfilePhotos","\\ProfilePhotos\\Temp").Replace(".", DateTime.Now.ToString("_yyMMddfffffff."));
                    System.IO.File.Copy(sourceFileName, tempFileName);

                    return "../Content/Images/ProfilePhotos/Temp/" + Path.GetFileName(tempFileName);
                }
            }
            catch (Exception ex)
            {
                return "../../Content/Images/UserImage.png";
            }
            return "../../Content/Images/UserImage.png";
        }
    }
}
