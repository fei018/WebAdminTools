using AdminToolsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebAdminTools.Filters
{
    public class Filter_ActionExecuted : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);           

            AddLayoutLoginTitleName(ref filterContext);
        }

        private void AddLayoutLoginTitleName(ref ActionExecutedContext context)
        {
            var result = context.Result as ViewResult;
            if (result != null)
            {
                result.ViewData["LoginTitleName"] = context.HttpContext.User.Identity.Name;
            }
        }
    }
}