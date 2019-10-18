using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using UnfiConnect;
using UniFiPortal.Common;
using UniFiPortal.Models;

namespace UniFiPortal.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            if (ConfigurationManager.AppSettings["LogRequest"] == "true")
            {
                using (var stream = new StreamWriter(new FileStream(Server.MapPath("~/log.txt"), FileMode.Append, FileAccess.Write, FileShare.ReadWrite), Encoding.UTF8))
                {
                    stream.AutoFlush = true;

                    var dict = Utility.NvcToDictionary(Request.Form, true);
                    string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
                    stream.WriteLine("------------------------------------------------------------------------\r\n" +
                                     DateTime.Now + "\r\n\r\n" +
                                     Request.Url.AbsoluteUri + "\r\n\r\n" +
                                     "Refer url: " + Request?.UrlReferrer?.AbsoluteUri + "\r\n\r\n" +
                                     json);
                }
            }

            var model = new WifiLoginModel
            {
                Id = Request["id"],//Mac address of device login wifi
                Ap = Request["ap"],
                T = Request["t"],
                Url = Request["url"],
                Ssid = Request["ssid"]
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(WifiLoginModel model)
        {
            if (model.Fullname.HasValue() == false)
            {
                ViewBag.Message = "Full name is required!";
                return View(model);
            }

            if (model.Email.HasValue()==false || !Utility.IsValidEmailAddress(model.Email))
            {
                ViewBag.Message = "Please enter valid email!";
                return View(model);
            }

            if (!model.Id.HasValue())
            {
                ViewBag.Message = "Please check the device again!";
                return View(model);
            }

            #region Get config value
            var urlWifi = ConfigurationManager.AppSettings["UrlWifi"] ?? "https://192.168.100.14:8443";
            var userName = ConfigurationManager.AppSettings["UserName"] ?? "admin";
            var password = ConfigurationManager.AppSettings["Password"] ?? "admin";
            var siteId = ConfigurationManager.AppSettings["SiteId"] ?? "default";
            var redirectUrl = ConfigurationManager.AppSettings["RedirectUrl"] ?? "https://vnexpress.net";
            #endregion

            try
            {
                //todo: write information of guest to database

                var uniFiApi = new Api(new Uri(urlWifi), siteId);
                uniFiApi.DisableSslValidation();
                var authenticationSuccessful = uniFiApi.AuthenticateIsSync(userName, password);
                var authorizeGuestIsSync = uniFiApi.AuthorizeGuestIsSync(model.Id);
                var logoutIsSync = uniFiApi.LogoutIsSync();
                Thread.Sleep(5);
                return Redirect(redirectUrl);
            }
            catch
            {
                ViewBag.Message = "Login failed. Please contact your System Administrator!";
                return View(model);
            }
            
        }


    }
}