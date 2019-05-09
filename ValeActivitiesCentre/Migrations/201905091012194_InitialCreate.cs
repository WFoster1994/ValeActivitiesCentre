namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 255),
                        Day = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        HomePhoneNumber = c.String(maxLength: 16),
                        MobilePhoneNumber = c.String(maxLength: 16),
                        Email = c.String(maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                        IsClient = c.Boolean(nullable: false),
                        IsStaff = c.Boolean(nullable: false),
                        ImageURL = c.String(),
                        Activity_ActivityID = c.Int(),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityID)
                .Index(t => t.Activity_ActivityID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false),
                        House = c.String(nullable: false, maxLength: 30),
                        StreetName = c.String(nullable: false, maxLength: 30),
                        TownName = c.String(maxLength: 30),
                        County = c.Int(nullable: false),
                        Postcode = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.People", t => t.AddressID)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false),
                        Funding = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.People", t => t.ClientID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.ClientProfiles",
                c => new
                    {
                        ClientProfileID = c.Int(nullable: false),
                        BestComunicationApproach = c.String(),
                        PoorCoomunicationApproach = c.String(),
                        GoalsAndObjectives = c.String(),
                    })
                .PrimaryKey(t => t.ClientProfileID)
                .ForeignKey("dbo.Clients", t => t.ClientProfileID)
                .Index(t => t.ClientProfileID);
            
            CreateTable(
                "dbo.RiskAssessments",
                c => new
                    {
                        RiskAssessmentID = c.Int(nullable: false),
                        PhysicalHealthNotes = c.String(),
                        MentalHealthNotes = c.String(),
                        SocialHealthNotes = c.String(),
                        OtherNotes = c.String(),
                    })
                .PrimaryKey(t => t.RiskAssessmentID)
                .ForeignKey("dbo.Clients", t => t.RiskAssessmentID)
                .Index(t => t.RiskAssessmentID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffID = c.Int(nullable: false),
                        Department = c.Int(nullable: false),
                        JobPosition = c.Int(nullable: false),
                        Profile = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.StaffID)
                .ForeignKey("dbo.People", t => t.StaffID)
                .Index(t => t.StaffID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Activity_ActivityID", "dbo.Activities");
            DropForeignKey("dbo.Staffs", "StaffID", "dbo.People");
            DropForeignKey("dbo.RiskAssessments", "RiskAssessmentID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ClientID", "dbo.People");
            DropForeignKey("dbo.ClientProfiles", "ClientProfileID", "dbo.Clients");
            DropForeignKey("dbo.Addresses", "AddressID", "dbo.People");
            DropIndex("dbo.Staffs", new[] { "StaffID" });
            DropIndex("dbo.RiskAssessments", new[] { "RiskAssessmentID" });
            DropIndex("dbo.ClientProfiles", new[] { "ClientProfileID" });
            DropIndex("dbo.Clients", new[] { "ClientID" });
            DropIndex("dbo.Addresses", new[] { "AddressID" });
            DropIndex("dbo.People", new[] { "Activity_ActivityID" });
            DropTable("dbo.Staffs");
            DropTable("dbo.RiskAssessments");
            DropTable("dbo.ClientProfiles");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
            DropTable("dbo.People");
            DropTable("dbo.Activities");
        }
    }
}
