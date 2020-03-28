namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlotNumberUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ActivitySlots", "ActivitySlotNumber", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Bookings", "ActivitySlotNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "ActivitySlotNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.ActivitySlots", "ActivitySlotNumber", c => c.Int(nullable: false));
        }
    }
}
