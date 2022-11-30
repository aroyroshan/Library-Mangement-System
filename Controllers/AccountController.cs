using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMgmts.Controllers
{
    public class AccountController : Controller
    {
        private readonly LibraryContext Context = new LibraryContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(string userName, string passWord)
        {
            try
            {
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(passWord))
                {
                    UserEntity  validUser = Context.User.Where(a => a.UserName.Equals(userName) && a.Password.Equals(passWord)).FirstOrDefault();
                    if (validUser != null)
                    {
                        Session["Id"] = validUser.Id;
                        Session["UserName"] = userName; // adding user into session
                        return RedirectToAction("SdtIndex", "Student");
                    }
                    else
                    {
                        ViewBag.Error = "Invalid login";
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Error = "Cannot read empty records";
                return RedirectToAction("Index");


            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }

}
