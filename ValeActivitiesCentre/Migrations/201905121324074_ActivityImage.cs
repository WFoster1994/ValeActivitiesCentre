namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "ImageURL");
        }
    }
}
