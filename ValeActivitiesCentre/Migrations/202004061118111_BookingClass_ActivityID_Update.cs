namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingClass_ActivityID_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "ActivityID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "ActivityID");
        }
    }
}
