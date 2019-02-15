using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using AdminToolsModel.Account;
using AdminToolsModel.CSPCall;

namespace AdminToolsDAL
{
    public class AdminToolsDB : DbContext
    {
        static AdminToolsDB()
        {
            // ROLA - This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
            // As it is installed in the GAC, Copy Local does not work. It is required for probing.
            // Fixed "Provider not loaded" error
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        
        /// <summary>
        /// 數據庫自動遷移
        /// </summary>
        public static void DBAutoMigration()
        {
            Database.SetInitializer<AdminToolsDB>(new MigrateDatabaseToLatestVersion<AdminToolsDB, Migrations.Configuration>());
            var dbmirgator = new DbMigrator(new Migrations.Configuration());
            dbmirgator.Update();
        }
         
        #region Table ORM
        public DbSet<LoginUser> Accounts { get; set; }

        public DbSet<CSPCallDetails> CSPCall { get; set; } 
        #endregion
    }
}