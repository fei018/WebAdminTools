namespace AdminToolsDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 20),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.CSPCall",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 3),
                        Location = c.String(nullable: false, maxLength: 30),
                        ContactPerson = c.String(nullable: false, maxLength: 30),
                        Symptom = c.String(nullable: false),
                        ScheduleTime = c.String(nullable: false, maxLength: 5),
                        ServeTime1 = c.String(nullable: false, maxLength: 5),
                        ServeTime2 = c.String(nullable: false, maxLength: 5),
                        ServiceDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Account", new[] { "UserName" });
            DropTable("dbo.CSPCall");
            DropTable("dbo.Account");
        }
    }
}
