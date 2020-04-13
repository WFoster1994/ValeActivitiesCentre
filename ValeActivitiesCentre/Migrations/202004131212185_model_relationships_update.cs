namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model_relationships_update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivitySlots", "Client_ClientID", "dbo.Clients");
            DropIndex("dbo.ActivitySlots", new[] { "Client_ClientID" });
            AddColumn("dbo.Activities", "StaffID", c => c.Int(nullable: false));
            CreateIndex("dbo.Activities", "StaffID");
            AddForeignKey("dbo.Activities", "StaffID", "dbo.Staffs", "StaffID", cascadeDelete: true);
            DropColumn("dbo.ActivitySlots", "Client_ClientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActivitySlots", "Client_ClientID", c => c.Int());
            DropForeignKey("dbo.Activities", "StaffID", "dbo.Staffs");
            DropIndex("dbo.Activities", new[] { "StaffID" });
            DropColumn("dbo.Activities", "StaffID");
            CreateIndex("dbo.ActivitySlots", "Client_ClientID");
            AddForeignKey("dbo.ActivitySlots", "Client_ClientID", "dbo.Clients", "ClientID");
        }
    }
}
