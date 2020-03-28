namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactNumberUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "MainContactNumber", c => c.String(maxLength: 16));
            AddColumn("dbo.People", "OtherContactNumber", c => c.String(maxLength: 16));
            DropColumn("dbo.People", "HomePhoneNumber");
            DropColumn("dbo.People", "MobilePhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "MobilePhoneNumber", c => c.String(maxLength: 16));
            AddColumn("dbo.People", "HomePhoneNumber", c => c.String(maxLength: 16));
            DropColumn("dbo.People", "OtherContactNumber");
            DropColumn("dbo.People", "MainContactNumber");
        }
    }
}
