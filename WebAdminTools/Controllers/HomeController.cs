using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdminTools.Filters;

namespace WebAdminTools.Controllers
{
    //[LoginAuthorize]
    [Filter_ActionExecuted]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            //var bvm = new BaseViewModel();
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}