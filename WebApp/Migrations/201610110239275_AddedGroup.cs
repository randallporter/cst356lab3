namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.GroupUsers",
                c => new
                    {
                        Group_GroupID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_GroupID, t.User_ID })
                .ForeignKey("dbo.Groups", t => t.Group_GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.Group_GroupID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupUsers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.GroupUsers", "Group_GroupID", "dbo.Groups");
            DropIndex("dbo.GroupUsers", new[] { "User_ID" });
            DropIndex("dbo.GroupUsers", new[] { "Group_GroupID" });
            DropTable("dbo.GroupUsers");
            DropTable("dbo.Groups");
        }
    }
}
