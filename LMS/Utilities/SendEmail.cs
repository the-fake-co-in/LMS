using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Reflection;

namespace LMS.Utilities
{
    public static class SendEmail
    {
        private static string appPath = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority;

        public static bool Send(ref string errorMsg, string receiver, string emailSubject, string emailBody)
        {
            try
            {
                var senderEmail = new MailAddress("lms.sa.1234567@gmail.com", "Library Management System");
                var receiverEmail = new MailAddress(receiver, "Receiver");
                var password = "Super@dmin@1";
                var sub = emailSubject;
                var body = emailBody;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var message = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = emailSubject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }

        }

        public static string SendForgotUserNameEmail(string name, string userName, string email)
        {
            string errorMsg = string.Empty;
            string path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"Content\HTML\ForgotUserNameTemplate.html");
            string template = File.ReadAllText(path).Replace("@@@NAME@@@", name).Replace("@@@USERNAME@@@", userName).Replace("@@@APP_PATH@@@", appPath);
            Send(ref errorMsg, email, "Library Management System - Forgot UserName", template);
            return errorMsg;
        }

        public static string SendForgotPasswordEmail(string name, string userName, string email, string otp)
        {
            string errorMsg = string.Empty;
            string path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"Content\HTML\ForgotPasswordTemplate.html");
            string template = File.ReadAllText(path).Replace("@@@NAME@@@", name).Replace("@@@USERNAME@@@", userName).Replace("@@@APP_PATH@@@", appPath).Replace("@@@OTP@@@", otp);
            Send(ref errorMsg, email, "Library Management System - Forgot Password", template);
            return errorMsg;
        }
    }
}