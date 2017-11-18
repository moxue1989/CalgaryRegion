namespace CalgaryHacks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pointsofinterest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        TrumbaUniqueId = c.String(),
                        EventfulUniqueId = c.String(),
                        MeetupUniqueId = c.String(),
                        TicketMasterUniqueId = c.String(),
                        URL = c.String(),
                        EventDate = c.DateTime(),
                        Type = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Longitude = c.String(nullable: false),
                        Latitude = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PointsOfInterests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Location = c.String(),
                        HoursOfOperation = c.String(),
                        Type = c.String(),
                        Community = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Event_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Event_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.UserEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.UserEvents", "User_Id", "dbo.Users");
            DropIndex("dbo.UserEvents", new[] { "Event_Id" });
            DropIndex("dbo.UserEvents", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Location_Id" });
            DropTable("dbo.UserEvents");
            DropTable("dbo.PointsOfInterests");
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
            DropTable("dbo.Events");
        }
    }
}
