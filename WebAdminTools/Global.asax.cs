using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AdminToolsDAL;

namespace WebAdminTools
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ////數據庫自動遷移
            //Database.SetInitializer<DAL.AdminToolsDB>(new MigrateDatabaseToLatestVersion<DAL.AdminToolsDB,Migrations.Configuration>());
            //var dbMigrator = new DbMigrator(new WebAdminTools.Migrations.Configuration());
            //dbMigrator.Update();
            AdminToolsDB.DBAutoMigration();
        }
    }
}
