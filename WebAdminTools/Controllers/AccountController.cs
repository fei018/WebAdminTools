using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AdminToolsDAL.Account;
using AdminToolsModel.Account;

namespace WebAdminTools.Controllers
{
    public class AccountController : Controller
    {
        //// GET: Account
        //public ActionResult Index()
        //{
        //    return View();
        //}
        
        public ActionResult Login()
        {
            //已經登錄就返回首頁
            if (this.Session["LoginUser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(LoginUser loginUser)
        {           
            if (ModelState.IsValid)
            {
                AccountDAL validity = new AccountDAL();
                if (!validity.IsValid(loginUser))
                {
                    ModelState.AddModelError("LoginError", "Invalid User Name or Password");
                    return View("Login");
                }
                FormsAuthentication.SetAuthCookie(loginUser.UserName, false);
                this.Session["LoginUser"] = loginUser;
                return RedirectToAction("Index", "Home");
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            if (this.Session["LoginUser"] != null)
            {
                this.Session.Abandon();
            }
            return RedirectToAction("Login");
        }
    }
}