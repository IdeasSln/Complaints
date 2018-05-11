using Complaints.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Permissions;
using System.DirectoryServices;

namespace Complaints.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Logon()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Logon(Credentials model)
        //{
            // Lets first check if the Model is valid or not
            //if (ModelState.IsValid)
            //{
            //    bool userValid = false;

            //    string username = model.UserName;
            //    string password = model.Password;
            //    //userValid = true;

            //    try
            //    {
            //        string domainUserName = "omh" + @"\" + username;
            //        DirectoryEntry entry = new DirectoryEntry("LDAP://omh.omhnet.dom", domainUserName, password);

            //        Object obj = entry.NativeObject;
            //        DirectorySearcher ds = new DirectorySearcher();
            //        ds.SearchRoot = new DirectoryEntry("");
            //        ds.Filter = "(|(&(objectCategory=user)(sAMAccountName=" + username + ")))";
            //        SearchResultCollection src = ds.FindAll();
            //        SearchResult sr = src[0];
            //        ResultPropertyCollection myProperties = sr.Properties;
            //        string CN = GetPropertyValue(myProperties, "cn");
            //        string strMember = GetPropertyValue(myProperties, "memberof");
            //        string[] MemberOf = strMember.Split('/');

            //        if (strMember.Contains("CN=CR_Incidents_Admin"))
            //        {
            //            userValid = true;
            //        }

            //    }
            //    catch (Exception e)
            //    {

            //    }

                // User found in the database
            //    if (userValid)
            //    {
            //        FormsAuthentication.SetAuthCookie(username, false);
            //        if (Url.IsLocalUrl(model.ReturnUrl) && model.ReturnUrl.Length > 1 && model.ReturnUrl.StartsWith("/")
            //            && !model.ReturnUrl.StartsWith("//") && !model.ReturnUrl.StartsWith("/\\"))
            //        {
            //            return Redirect(model.ReturnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index", "Main");
            //        }
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "The user name or password provided is incorrect.");
            //    }
            //}

            //// If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        private string GetPropertyValue(ResultPropertyCollection UserProperties, string Key)
        {
            string Value = "";
            foreach (Object myCollection in UserProperties[Key])
            {
                Value += myCollection.ToString() + "/";
            }
            if (Value != "")
            {
                Value = Value.Remove(Value.Length - 1);
            }
            return Value;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Main");
        }
    }
}