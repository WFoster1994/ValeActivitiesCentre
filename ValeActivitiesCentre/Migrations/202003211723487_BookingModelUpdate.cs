namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "ActivityName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Bookings", "FirstName", c => c.String());
            AddColumn("dbo.Bookings", "LastName", c => c.String());
            AddColumn("dbo.Bookings", "ActivityName", c => c.String());
            AddColumn("dbo.Bookings", "ActivitySlotNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Time", c => c.Int(nullable: false));
            DropColumn("dbo.Activities", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "Name", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Bookings", "Time");
            DropColumn("dbo.Bookings", "Day");
            DropColumn("dbo.Bookings", "ActivitySlotNumber");
            DropColumn("dbo.Bookings", "ActivityName");
            DropColumn("dbo.Bookings", "LastName");
            DropColumn("dbo.Bookings", "FirstName");
            DropColumn("dbo.Activities", "ActivityName");
        }
    }
}
