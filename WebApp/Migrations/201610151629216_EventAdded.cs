namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventDate = c.DateTime(nullable: false),
                        EventDateEnd = c.DateTime(nullable: false),
                        EventName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.EventUsers",
                c => new
                    {
                        Event_EventID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_EventID, t.User_ID })
                .ForeignKey("dbo.Events", t => t.Event_EventID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.Event_EventID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventUsers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.EventUsers", "Event_EventID", "dbo.Events");
            DropIndex("dbo.EventUsers", new[] { "User_ID" });
            DropIndex("dbo.EventUsers", new[] { "Event_EventID" });
            DropTable("dbo.EventUsers");
            DropTable("dbo.Events");
        }
    }
}
