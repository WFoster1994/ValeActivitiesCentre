namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivitySlots", "ActivityID", "dbo.Activities");
            DropIndex("dbo.ActivitySlots", new[] { "ActivityID" });
            RenameColumn(table: "dbo.ActivitySlots", name: "ActivityID", newName: "Activity_ActivityID");
            RenameColumn(table: "dbo.ActivitySlots", name: "ClientID", newName: "Client_ClientID");
            RenameIndex(table: "dbo.ActivitySlots", name: "IX_ClientID", newName: "IX_Client_ClientID");
            AlterColumn("dbo.ActivitySlots", "Activity_ActivityID", c => c.Int());
            CreateIndex("dbo.ActivitySlots", "Activity_ActivityID");
            AddForeignKey("dbo.ActivitySlots", "Activity_ActivityID", "dbo.Activities", "ActivityID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivitySlots", "Activity_ActivityID", "dbo.Activities");
            DropIndex("dbo.ActivitySlots", new[] { "Activity_ActivityID" });
            AlterColumn("dbo.ActivitySlots", "Activity_ActivityID", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.ActivitySlots", name: "IX_Client_ClientID", newName: "IX_ClientID");
            RenameColumn(table: "dbo.ActivitySlots", name: "Client_ClientID", newName: "ClientID");
            RenameColumn(table: "dbo.ActivitySlots", name: "Activity_ActivityID", newName: "ActivityID");
            CreateIndex("dbo.ActivitySlots", "ActivityID");
            AddForeignKey("dbo.ActivitySlots", "ActivityID", "dbo.Activities", "ActivityID", cascadeDelete: true);
        }
    }
}
