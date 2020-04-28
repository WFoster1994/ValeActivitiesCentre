namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelrelationshipupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingActivities", "Booking_BookingID", "dbo.Bookings");
            DropForeignKey("dbo.BookingActivities", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.ActivitySlots", "Client_ClientID", "dbo.Clients");
            DropForeignKey("dbo.Bookings", "ClientID", "dbo.Clients");
            DropIndex("dbo.ActivitySlots", new[] { "Client_ClientID" });
            DropIndex("dbo.Bookings", new[] { "ClientID" });
            DropIndex("dbo.BookingActivities", new[] { "Booking_BookingID" });
            DropIndex("dbo.BookingActivities", new[] { "Activity_ActivityID" });
            RenameColumn(table: "dbo.Bookings", name: "ClientID", newName: "Client_ClientID");
            AddColumn("dbo.Activities", "Person_PersonID", c => c.Int());
            AddColumn("dbo.ActivitySlots", "BookingID", c => c.Int());
            AddColumn("dbo.Bookings", "PersonID", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Activity_ActivityID", c => c.Int());
            AlterColumn("dbo.Bookings", "Client_ClientID", c => c.Int());
            CreateIndex("dbo.Activities", "Person_PersonID");
            CreateIndex("dbo.ActivitySlots", "BookingID");
            CreateIndex("dbo.Bookings", "PersonID");
            CreateIndex("dbo.Bookings", "Activity_ActivityID");
            CreateIndex("dbo.Bookings", "Client_ClientID");
            AddForeignKey("dbo.Bookings", "Activity_ActivityID", "dbo.Activities", "ActivityID");
            AddForeignKey("dbo.Activities", "Person_PersonID", "dbo.People", "PersonID");
            AddForeignKey("dbo.Bookings", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
            AddForeignKey("dbo.ActivitySlots", "BookingID", "dbo.Bookings", "BookingID");
            AddForeignKey("dbo.Bookings", "Client_ClientID", "dbo.Clients", "ClientID");
            DropColumn("dbo.ActivitySlots", "Client_ClientID");
            DropColumn("dbo.Bookings", "FirstName");
            DropColumn("dbo.Bookings", "LastName");
            DropColumn("dbo.Bookings", "ActivityID");
            DropColumn("dbo.Bookings", "ActivityName");
            DropColumn("dbo.Bookings", "ActivitySlotNumber");
            DropColumn("dbo.Bookings", "Day");
            DropColumn("dbo.Bookings", "Time");
            DropTable("dbo.BookingActivities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookingActivities",
                c => new
                    {
                        Booking_BookingID = c.Int(nullable: false),
                        Activity_ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Booking_BookingID, t.Activity_ActivityID });
            
            AddColumn("dbo.Bookings", "Time", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "ActivitySlotNumber", c => c.String());
            AddColumn("dbo.Bookings", "ActivityName", c => c.String());
            AddColumn("dbo.Bookings", "ActivityID", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "LastName", c => c.String());
            AddColumn("dbo.Bookings", "FirstName", c => c.String());
            AddColumn("dbo.ActivitySlots", "Client_ClientID", c => c.Int());
            DropForeignKey("dbo.Bookings", "Client_ClientID", "dbo.Clients");
            DropForeignKey("dbo.ActivitySlots", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "PersonID", "dbo.People");
            DropForeignKey("dbo.Activities", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.Bookings", "Activity_ActivityID", "dbo.Activities");
            DropIndex("dbo.Bookings", new[] { "Client_ClientID" });
            DropIndex("dbo.Bookings", new[] { "Activity_ActivityID" });
            DropIndex("dbo.Bookings", new[] { "PersonID" });
            DropIndex("dbo.ActivitySlots", new[] { "BookingID" });
            DropIndex("dbo.Activities", new[] { "Person_PersonID" });
            AlterColumn("dbo.Bookings", "Client_ClientID", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "Activity_ActivityID");
            DropColumn("dbo.Bookings", "PersonID");
            DropColumn("dbo.ActivitySlots", "BookingID");
            DropColumn("dbo.Activities", "Person_PersonID");
            RenameColumn(table: "dbo.Bookings", name: "Client_ClientID", newName: "ClientID");
            CreateIndex("dbo.BookingActivities", "Activity_ActivityID");
            CreateIndex("dbo.BookingActivities", "Booking_BookingID");
            CreateIndex("dbo.Bookings", "ClientID");
            CreateIndex("dbo.ActivitySlots", "Client_ClientID");
            AddForeignKey("dbo.Bookings", "ClientID", "dbo.Clients", "ClientID", cascadeDelete: true);
            AddForeignKey("dbo.ActivitySlots", "Client_ClientID", "dbo.Clients", "ClientID");
            AddForeignKey("dbo.BookingActivities", "Activity_ActivityID", "dbo.Activities", "ActivityID", cascadeDelete: true);
            AddForeignKey("dbo.BookingActivities", "Booking_BookingID", "dbo.Bookings", "BookingID", cascadeDelete: true);
        }
    }
}
