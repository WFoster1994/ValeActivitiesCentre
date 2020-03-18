namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Activity_ActivityID", "dbo.Activities");
            DropIndex("dbo.People", new[] { "Activity_ActivityID" });
            CreateTable(
                "dbo.ActivitySlots",
                c => new
                    {
                        ActivitySlotID = c.Int(nullable: false, identity: true),
                        ActivitySlotNUmber = c.Int(nullable: false),
                        ActivityID = c.Int(nullable: false),
                        ClientID = c.Int(),
                    })
                .PrimaryKey(t => t.ActivitySlotID)
                .ForeignKey("dbo.Activities", t => t.ActivityID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.ActivityID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        BookingStatus = c.Int(nullable: false),
                        EmailSent = c.Boolean(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.BookingActivities",
                c => new
                    {
                        Booking_BookingID = c.Int(nullable: false),
                        Activity_ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Booking_BookingID, t.Activity_ActivityID })
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingID, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityID, cascadeDelete: true)
                .Index(t => t.Booking_BookingID)
                .Index(t => t.Activity_ActivityID);
            
            AddColumn("dbo.Activities", "ActivityStatus", c => c.Int(nullable: false));
            DropColumn("dbo.People", "Activity_ActivityID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Activity_ActivityID", c => c.Int());
            DropForeignKey("dbo.ActivitySlots", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Bookings", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.BookingActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.BookingActivities", "Booking_BookingID", "dbo.Bookings");
            DropForeignKey("dbo.ActivitySlots", "ActivityID", "dbo.Activities");
            DropIndex("dbo.BookingActivities", new[] { "Activity_ActivityID" });
            DropIndex("dbo.BookingActivities", new[] { "Booking_BookingID" });
            DropIndex("dbo.Bookings", new[] { "ClientID" });
            DropIndex("dbo.ActivitySlots", new[] { "ClientID" });
            DropIndex("dbo.ActivitySlots", new[] { "ActivityID" });
            DropColumn("dbo.Activities", "ActivityStatus");
            DropTable("dbo.BookingActivities");
            DropTable("dbo.Bookings");
            DropTable("dbo.ActivitySlots");
            CreateIndex("dbo.People", "Activity_ActivityID");
            AddForeignKey("dbo.People", "Activity_ActivityID", "dbo.Activities", "ActivityID");
        }
    }
}
