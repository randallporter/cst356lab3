namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventAdd2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventUsers", newName: "UserEvents");
            DropPrimaryKey("dbo.UserEvents");
            AddPrimaryKey("dbo.UserEvents", new[] { "User_ID", "Event_EventID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserEvents");
            AddPrimaryKey("dbo.UserEvents", new[] { "Event_EventID", "User_ID" });
            RenameTable(name: "dbo.UserEvents", newName: "EventUsers");
        }
    }
}
