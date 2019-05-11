namespace ValeActivitiesCentre.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ValeActivitiesCentre.DAL;
    using ValeActivitiesCentre.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ValeActivitiesCentre.DAL.ValeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ValeActivitiesCentre.DAL.ValeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            SeedActivities(context);
            SeedAddresses(context);
            SeedClients(context);
            SeedClientProfiles(context);
            SeedPeople(context);
            SeedStaff(context);
            SeedRiskAssessments(context);
        }

        //Seed methods displayed in alphabetical order
        private void SeedActivities(ValeDbContext context)
        {
            var ActivityList = new List<Activity>
            {
                //First 5 are Mon - Fri AM activities
                new Activity
                {
                    ActivityID = 1,
                    Name = "Social Outing",
                    Description = "An opportunity for members " +
                    "to get out into the town for a drink and to " +
                    "chat with other members and staff.",
                    Day = DayOptions.MONDAY,
                    Time = TimeOptions.AM
                },
                new Activity
                {
                    ActivityID = 2,
                    Name = "Hobbies and Games",
                    Description = "A relaxed session for our members who " +
                    "prefer to stay in ",
                    Day = DayOptions.TUESDAY,
                    Time = TimeOptions.AM
                },
                new Activity
                {
                    ActivityID = 3,
                    Name = "Makaton Communication",
                    Description = "A chance for our memebers to learn some " +
                    "makaton sign lanaguage from our trained staff team.",
                    Day = DayOptions.WEDNESAY,
                    Time = TimeOptions.AM
                },
                new Activity
                {
                    ActivityID = 4,
                    Name = "Baking",
                    Description = "With a slightly more sweeter emphasis, " +
                    "our baking session allowing members to craft some classic " +
                    "baking recipes including many different kinds of cakes and buscuits.",
                    Day = DayOptions.THURSDAY,
                    Time = TimeOptions.AM
                },
                new Activity
                {
                    ActivityID = 5,
                    Name = "Personal Shopping",
                    Description = "A chance for our members to go out" +
                    "into town to indulge in some retail therapy that " +
                    "they may wish to do. Afterwards, we'll always " +
                    "stop for a coffee somewhere.",
                    Day = DayOptions.FRIDAY,
                    Time = TimeOptions.AM
                },
                //6-10 are Mon - Fri PM activities
                new Activity
                {
                    ActivityID = 6,
                    Name = "Music Making",
                    Description = "A chance for members to flex their " +
                    "creative muscles with a musical session. We have some " +
                    "musically inclined staff members and selection of instuments " +
                    "from Keyboards and Guitars to Tin Whistles.",
                    Day = DayOptions.MONDAY,
                    Time = TimeOptions.PM
                },
                new Activity
                {
                    ActivityID = 7,
                    Name = "Healthy Eating",
                    Description = "A cooking session with an " +
                    "emphasis on healthy ingredients and healthy " +
                    "recipes.",
                    Day = DayOptions.TUESDAY,
                    Time = TimeOptions.PM
                },
                new Activity
                {
                    ActivityID = 8,
                    Name = "Pub Trip",
                    Description = "For some of us, relaxing in " +
                    "the pub with friends is a big part of our" +
                    " social life. We work to enable this for " +
                    "our members who value this as part of their " +
                    "lives.",
                    Day = DayOptions.WEDNESAY,
                    Time = TimeOptions.PM
                },
                new Activity
                {
                    ActivityID = 9,
                    Name = "Social Outing",
                    Description = "An opportunity to go out " +
                    "into the town, have a coffee and chat with " +
                    "people, and generally enjoy the outdoors. ",
                    Day = DayOptions.THURSDAY,
                    Time = TimeOptions.PM
                },
                new Activity
                {
                    ActivityID = 10,
                    Name = "Relaxation",
                    Description = "To wind down the week before " +
                    "the weekend, we hold a relaxation session " +
                    "where various relaxation techniques like mindfulness " +
                    "are practiced to promote staying in the here and now.",
                    Day = DayOptions.FRIDAY,
                    Time = TimeOptions.PM
                }
            };
            ActivityList.ForEach(s => context.Activities.AddOrUpdate(p => p.ActivityID, s));
        }

        private void SeedAddresses(ValeDbContext context)
        {
            var AddressList = new List<Address>
            {
                new Address
                {
                    AddressID = 1,
                    House = "8",
                    StreetName = "Kestrel Way",
                    TownName = "Aylesbury",
                    Postcode = "HP190GH",
                    County = Counties.BUCKINGHAMSHIRE
                },
                new Address
                {
                    AddressID = 2,
                    House = "22",
                    StreetName = "Iron Road",
                    TownName = "Aylesbury",
                    Postcode = "HP208UG",
                    County = Counties.BUCKINGHAMSHIRE
                },
                new Address
                {
                    AddressID = 3,
                    House = "12",
                    StreetName = "Mercia Close",
                    TownName = "Aylesbury",
                    Postcode = "HP214OF",
                    County = Counties.BUCKINGHAMSHIRE
                },
                new Address
                {
                    AddressID = 4,
                    House = "23",
                    StreetName = "Potters Way",
                    TownName = "Chesham",
                    Postcode = "HP236LV",
                    County = Counties.BUCKINGHAMSHIRE
                },
                new Address
                {
                    AddressID = 5,
                    House = "18",
                    StreetName = "Victory Way",
                    TownName = "Oxford",
                    Postcode = "OX181LT",
                    County = Counties.OXFORDSHIRE
                },
                new Address
                {
                    AddressID = 6,
                    House = "Forresters Cottage",
                    StreetName = "Woodland Road",
                    TownName = "Cloverfield",
                    Postcode = "HP38UK",
                    County = Counties.HERTFORDSHIRE
                },
                new Address
                {
                    AddressID = 7,
                    House = "11",
                    StreetName = "Gediminas Road",
                    TownName = "Camden",
                    Postcode = "NW35VI",
                    County = Counties.LONDON
                },
                new Address
                {
                    AddressID = 8,
                    House = "Old Station House",
                    StreetName = "Cane Row",
                    TownName = "Smith's Hearth",
                    Postcode = "OX217ME",
                    County = Counties.OXFORDSHIRE
                },
                new Address
                {
                    AddressID = 9,
                    House = "26",
                    StreetName = "Brunel Avenue",
                    TownName = "Gospel Oak",
                    Postcode = "NW42AQ",
                    County = Counties.LONDON
                },
                new Address
                {
                    AddressID = 10,
                    House = "14",
                    StreetName = "Roses Close",
                    TownName = "Towton",
                    Postcode = "AL4 E61",
                    County = Counties.BEDFORDSHIRE
                },
                new Address
                {
                    AddressID = 11,
                    House = "4",
                    StreetName = "Stables Road",
                    TownName = "Forgeton",
                    Postcode = "HP01 9SK",
                    County = Counties.BUCKINGHAMSHIRE
                },
                new Address
                {
                    AddressID = 12,
                    House = "19",
                    StreetName = "Sun Close",
                    TownName = "Watermill",
                    Postcode = "HP5 7JW",
                    County = Counties.HERTFORDSHIRE
                },
                new Address
                {
                    AddressID = 13,
                    House = "6",
                    StreetName = "Ashlyns Road",
                    TownName = "Berkhamsted",
                    Postcode = "HP4 1AB",
                    County = Counties.BUCKINGHAMSHIRE
                },
                new Address
                {
                    AddressID = 14,
                    House = "4",
                    StreetName = "Skyforger Street",
                    TownName = "Tiurada",
                    Postcode = "HP28 1AC",
                    County = Counties.BUCKINGHAMSHIRE
                }
            };
            AddressList.ForEach(s => context.Addresses.AddOrUpdate(p => p.AddressID, s));
        }

        private void SeedClients(ValeDbContext context)
        {
            var ClientList = new List<Client>
            {
                new Client
                {
                    ClientID = 8,
                    Funding = FundingOptions.COUNCIL_FUNDED
                },
                new Client
                {
                    ClientID = 9,
                    Funding = FundingOptions.COUNCIL_FUNDED
                },
                new Client
                {
                    ClientID = 10,
                    Funding = FundingOptions.PRIVATE_FUNDING
                },
                new Client
                {
                    ClientID = 11,
                    Funding = FundingOptions.COUNCIL_FUNDED
                },
                new Client
                {
                    ClientID = 12,
                    Funding = FundingOptions.COUNCIL_FUNDED
                },
                new Client
                {
                    ClientID = 13,
                    Funding = FundingOptions.PRIVATE_FUNDING
                },
                new Client
                {
                    ClientID = 14,
                    Funding = FundingOptions.PRIVATE_FUNDING
                }
            };
            ClientList.ForEach(s => context.Clients.AddOrUpdate(p => p.ClientID, s));
        }

        private void SeedClientProfiles(ValeDbContext context)
        {
            var ClientProfileList = new List<ClientProfile>
            {
                new ClientProfile
                {
                    ClientProfileID = 8,
                    BestComunicationApproach = "Simple signing and short sentances.",
                    PoorCoomunicationApproach = "Long or drawn out sentances.",
                    GoalsAndObjectives = "To become more independent."
                },
                new ClientProfile
                {
                    ClientProfileID = 9,
                    BestComunicationApproach = "Full sentances, as you would with anyone else.",
                    PoorCoomunicationApproach = "Fast speech that would be difficult for most " +
                    "people to catch. Slowly spoken sentances that could be seen as patronising.",
                    GoalsAndObjectives = "Find a meaningful job."
                },
                new ClientProfile
                {
                    ClientProfileID = 10,
                    BestComunicationApproach = "A set of signs that are unique and understood " +
                    "by myself. Short, often, two word phrases also work for me.",
                    PoorCoomunicationApproach = "Excessive spoken communication " +
                    "all at one time does not work for me. This can be overly stimulating.",
                    GoalsAndObjectives = "To be happy and see other people more often."
                },
                new ClientProfile
                {
                    ClientProfileID = 11,
                    BestComunicationApproach = "Full and ordinary sentances.",
                    PoorCoomunicationApproach = "Technical terms that are not generally " +
                    "used by ordinary people.",
                    GoalsAndObjectives = "To find a house or flat of my own to live in."
                },
                new ClientProfile
                {
                    ClientProfileID = 12,
                    BestComunicationApproach = "Simple signing and short sentances. I also " +
                    "appreciate these sentances to be clearly spoken.",
                    PoorCoomunicationApproach = "Long or overly complicated sentances.",
                    GoalsAndObjectives = "To learn new skills."
                },
                new ClientProfile
                {
                    ClientProfileID = 13,
                    BestComunicationApproach = "A set of key words and phrases that are " +
                    "understood by me.",
                    PoorCoomunicationApproach = "Long sentances as these are difficult for me " +
                    "to understand.",
                    GoalsAndObjectives = "To see and be around people more."
                },
                new ClientProfile
                {
                    ClientProfileID = 14,
                    BestComunicationApproach = "Simple signing and short sentances.",
                    PoorCoomunicationApproach = "Long sentances. I also don't appreciate " +
                    "these short sentances being spoken in a way that would seem patronising.",
                    GoalsAndObjectives = "To increase my confidence around other people"
                }
            };
            ClientProfileList.ForEach(s => context.ClientProfiles.AddOrUpdate(p => p.ClientProfileID, s));
        }

        private void SeedPeople(ValeDbContext context)
        {          

            var PersonList = new List<Person>
            {
                //Staff List Below
                new Person
                {
                    PersonID = 1,
                    FirstName = "William",
                    LastName = "Foster",
                    HomePhoneNumber = "01296123123",
                    MobilePhoneNumber = "07762123123",
                    Email = "William@vac.org.uk",
                    DateOfBirth = new System.DateTime(1994, 8, 28),
                    IsClient = false,
                    IsStaff = true,
                    ImageURL = "WFavatar.JPG"
                },
                new Person
                {
                    PersonID = 2,
                    FirstName = "Bethany",
                    LastName = "Dale",
                    HomePhoneNumber = "01296647431",
                    MobilePhoneNumber = "07771123123",
                    Email = "Bethany@vac.org.uk",
                    DateOfBirth = new System.DateTime(1982, 6, 15),
                    IsClient = false,
                    IsStaff = true,
                    ImageURL = "BDavatar.JPG",            
                },
                new Person
                {
                    PersonID = 3,
                    FirstName = "Katy",
                    LastName = "Smith",
                    HomePhoneNumber = "01494234567",
                    MobilePhoneNumber = "07987123876",
                    Email = "Katy@vac.org.uk",
                    DateOfBirth = new System.DateTime(1972, 3, 21),
                    IsClient = false,
                    IsStaff = true,
                    ImageURL = "KSavatar.JPG",
                },
                new Person
                {
                    PersonID = 4,
                    FirstName = "Hendrik",
                    LastName = "Braun",
                    HomePhoneNumber = "01746826591",
                    MobilePhoneNumber = "07435172123",
                    Email = "Hendrik1@mail.com",
                    DateOfBirth = new System.DateTime(1990, 7, 11),
                    IsClient = false,
                    IsStaff = true,
                    ImageURL = "HGavatar.JPG"
                },
                new Person
                {
                    PersonID = 5,
                    FirstName = "Jacob",
                    LastName = "Fields",
                    HomePhoneNumber = "01234987654",
                    MobilePhoneNumber = "07983456789",
                    Email = "Jocob1@mail.com",
                    DateOfBirth = new System.DateTime(1992, 11, 12),
                    IsClient = false,
                    IsStaff = true,
                    ImageURL = ""
                },
                new Person
                {
                    PersonID = 6,
                    FirstName = "Sophia",
                    LastName = "Eastland",
                    HomePhoneNumber = "01234987321",
                    MobilePhoneNumber = "07654123456",
                    Email = "Julia1@mail.com",
                    DateOfBirth = new System.DateTime(1981, 12, 29),
                    IsClient = false,
                    IsStaff = true,
                    ImageURL = ""
                },
                new Person
                {
                    PersonID = 7,
                    FirstName = "Aidan",
                    LastName = "Smith",
                    HomePhoneNumber = "01576876543",
                    MobilePhoneNumber = "07890654321",
                    Email = "Aidan1@mail.com",
                    DateOfBirth = new System.DateTime(1990, 4, 23),
                    IsClient = false,
                    IsStaff = true,
                    ImageURL = ""
                },
                //Client List Begins
                new Person
                {
                    PersonID = 8,
                    FirstName = "Michael",
                    LastName = "Barclay",
                    HomePhoneNumber = "01296456788",
                    MobilePhoneNumber = "0777554321",
                    Email = "Michael@mail.com",
                    DateOfBirth = new System.DateTime(1976, 12, 26),
                    IsClient = true,
                    IsStaff = false,
                    ImageURL = ""
                },
                new Person
                {
                    PersonID = 9,
                    FirstName = "Stephen",
                    LastName = "Gough",
                    HomePhoneNumber = "01746276354",
                    MobilePhoneNumber = "07497735243",
                    DateOfBirth = new System.DateTime(1994, 2, 28),
                    IsClient = true,
                    IsStaff = false,
                    ImageURL = ""
                },
                new Person
                {
                    PersonID = 10,
                    FirstName = "MaryAnne",
                    LastName = "Perry",
                    HomePhoneNumber = "01294325764",
                    MobilePhoneNumber = "07945172223",
                    Email = "MaryAnne@mail.com",
                    DateOfBirth = new System.DateTime(1982, 3, 11),
                    IsClient = true,
                    IsStaff = false,
                    ImageURL = ""
                },
                new Person
                {
                    PersonID = 11,
                    FirstName = "Ellie",
                    LastName = "Stillford",
                    HomePhoneNumber = "01746827345",
                    MobilePhoneNumber = "07163543210",
                    Email = "Ellie1@mail.com",
                    DateOfBirth = new System.DateTime(1989, 9, 6),
                    IsClient = true,
                    IsStaff = false,
                    ImageURL = ""
                },
                new Person
                {
                    PersonID = 12,
                    FirstName = "Tasmin",
                    LastName = "Adams",
                    MobilePhoneNumber = "07364555231",
                    DateOfBirth = new System.DateTime(1999, 10, 31),
                    IsClient = true,
                    IsStaff = false,
                    ImageURL = ""
                },
                new Person
                {
                    PersonID = 13,
                    FirstName = "Millie",
                    LastName = "Roche",
                    HomePhoneNumber = "01746987243",
                    MobilePhoneNumber = "07942987365",
                    Email = "Millie1@mail.com",
                    DateOfBirth = new System.DateTime(1966, 11, 16),
                    IsClient = true,
                    IsStaff = false,
                    ImageURL = ""
                },
                new Person
                {
                    PersonID = 14,
                    FirstName = "Oliver",
                    LastName = "White",
                    HomePhoneNumber = "01832765946",
                    DateOfBirth = new System.DateTime(1968, 9, 17),
                    IsClient = true,
                    IsStaff = false,
                    ImageURL = ""
                }
            };
            PersonList.ForEach(s => context.People.AddOrUpdate(p => p.PersonID, s));
                        
        }

        private void SeedRiskAssessments(ValeDbContext context)
        {
            var RiskAssessmentList = new List<RiskAssessment>
            {
                new RiskAssessment
                {
                    RiskAssessmentID = 8,
                    PhysicalHealthNotes = "Lorem ipsum dolor sit amet, " +
                    "consectetur adipiscing elit, sed do eiusmod tempor " +
                    "incididunt ut labore et dolore magna aliqua",
                    MentalHealthNotes = "Ut enim ad minim veniam, quis " +
                    "nostrud exercitation ullamco laboris nisi ut aliquip " +
                    "ex ea commodo consequat.",
                    SocialHealthNotes = "uis aute irure dolor in reprehenderit " +
                    "in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    OtherNotes = ""
                },
                new RiskAssessment
                {
                    RiskAssessmentID = 9,
                    PhysicalHealthNotes = "Excepteur sint occaecat cupidatat non " +
                    "proident, sunt in culpa qui officia deserunt mollit anim id " +
                    "est laborum.",
                    MentalHealthNotes = "Viverra suspendisse potenti nullam ac tortor. " +
                    "Nisl nunc mi ipsum faucibus vitae aliquet nec ullamcorper sit. " +
                    "Placerat duis ultricies lacus sed. Dapibus ultrices in iaculis " +
                    "nunc sed augue. Semper auctor neque vitae tempus quam pellentesque nec",
                    SocialHealthNotes = "Arcu odio ut sem nulla pharetra diam. Porttitor leo a " +
                    "diam sollicitudin tempor id eu. Odio ut enim blandit volutpat maecenas " +
                    "volutpat blandit aliquam etiam.",
                    OtherNotes = "Pretium viverra suspendisse potenti nullam ac tortor."
                },
                new RiskAssessment
                {
                    RiskAssessmentID = 10,
                    PhysicalHealthNotes = "Lorem ipsum dolor sit amet, " +
                    "consectetur adipiscing elit, sed do eiusmod tempor " +
                    "incididunt ut labore et dolore magna aliqua",
                    MentalHealthNotes = "Ut enim ad minim veniam, quis " +
                    "nostrud exercitation ullamco laboris nisi ut aliquip " +
                    "ex ea commodo consequat.",
                    SocialHealthNotes = "uis aute irure dolor in reprehenderit " +
                    "in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    OtherNotes = "Pharetra massa massa ultricies mi."
                },
                new RiskAssessment
                {
                    RiskAssessmentID = 11,
                    PhysicalHealthNotes = "Sed ut perspiciatis unde omnis iste " +
                    "natus error sit voluptatem accusantium doloremque laudantium.",
                    MentalHealthNotes = "Lorem ipsum dolor sit amet, consectetur " +
                    "adipiscing elit, sed do eiusmod tempor incididunt ut labore " +
                    "et dolore magna aliqua.",
                    SocialHealthNotes = "It is a long established fact that a " +
                    "reader will be distracted by the readable content of a page when looking at its layout.",
                    OtherNotes = "Lorem Ipsum is simply dummy text of the " +
                    "printing and typesetting industry. Lorem Ipsum has been " +
                    "the industry's standard dummy text ever since the 1500s"
                },
                new RiskAssessment
                {
                    RiskAssessmentID = 12,
                    PhysicalHealthNotes = "Lorem ipsum dolor sit amet, " +
                    "consectetur adipiscing elit, sed do eiusmod tempor " +
                    "incididunt ut labore et dolore magna aliqua",
                    MentalHealthNotes = "Ut enim ad minim veniam, quis " +
                    "nostrud exercitation ullamco laboris nisi ut aliquip " +
                    "ex ea commodo consequat.",
                    SocialHealthNotes = "uis aute irure dolor in reprehenderit " +
                    "in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    OtherNotes = ""
                },
                new RiskAssessment
                {
                    RiskAssessmentID = 13,
                    PhysicalHealthNotes = "Te consequuntur conclusionemque nec.",
                    MentalHealthNotes = "Vix tation doctus reprimique ut. " +
                    "Vel at maiestatis reprehendunt, ex mel verterem gloriatur " +
                    "abhorreant. In labores nostrum his, duo ea soleat " +
                    "euripidis ullamcorper. Vim et elit meis",
                    SocialHealthNotes = "Id nec dico laudem aliquam, offendit " +
                    "recteque forensibus no quo, per suscipit ullamcorper instructior in." +
                    " His voluptua dignissim no. Pro id dolor senserit accusamus, " +
                    "quo ea postea option discere. Eum semper corrumpit voluptaria cu. " +
                    "Ex pri quem nobis scribentur. An mei aliquip inimicus, modus " +
                    "eligendi cum in, per tation adipisci no.",
                    OtherNotes = "Ea putant torquatos scripserit sea, " +
                    "ius veri aperiri deleniti te, duo cu quas scripta."
                },
                new RiskAssessment
                {
                    RiskAssessmentID = 14,
                    PhysicalHealthNotes = "Lorem ipsum dolor sit amet, " +
                    "consectetur adipiscing elit, sed do eiusmod tempor " +
                    "incididunt ut labore et dolore magna aliqua",
                    MentalHealthNotes = "Ut enim ad minim veniam, quis " +
                    "nostrud exercitation ullamco laboris nisi ut aliquip " +
                    "ex ea commodo consequat.",
                    SocialHealthNotes = "uis aute irure dolor in reprehenderit " +
                    "in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    OtherNotes = ""
                }
            };
            RiskAssessmentList.ForEach(s => context.RiskAssessments.AddOrUpdate(p => p.RiskAssessmentID, s));
        }

        private void SeedStaff(ValeDbContext context)
        {
            var StaffList = new List<Staff>
            {
                new Staff
                {
                    StaffID = 1,
                    Department = DepartmentOptions.CARE,
                    JobPosition = JobPositionOptions.ACTIVITIES_ORGANISER,
                    Profile = "Lorem ipsum dolor sit amet, " +
                    "consectetur adipiscing elit, sed do eiusmod tempor " +
                    "incididunt ut labore et dolore magna aliqua"
                },
                new Staff
                {
                    StaffID = 2,
                    Department = DepartmentOptions.MANAGEMENT,
                    JobPosition = JobPositionOptions.COMPANY_DIRECTOR,
                    Profile = "Ea putant torquatos scripserit sea, " +
                    "ius veri aperiri deleniti te, duo cu quas scripta."
                },
                new Staff
                {
                    StaffID = 3,
                    Department = DepartmentOptions.MANAGEMENT,
                    JobPosition = JobPositionOptions.COMPANY_DIRECTOR,
                    Profile = "uis aute irure dolor in reprehenderit " +
                    "in voluptate velit esse cillum dolore eu fugiat nulla pariatur."
                },
                new Staff
                {
                    StaffID = 4,
                    Department = DepartmentOptions.MANAGEMENT,
                    JobPosition = JobPositionOptions.SITE_MANAGER,
                    Profile = "Ut enim ad minim veniam, quis " +
                    "nostrud exercitation ullamco laboris nisi ut aliquip " +
                    "ex ea commodo consequat."
                },
                new Staff
                {
                    StaffID = 5,
                    Department = DepartmentOptions.CARE,
                    JobPosition = JobPositionOptions.ACTIVITIES_ORGANISER,
                    Profile = "Ea putant torquatos scripserit sea, " +
                    "ius veri aperiri deleniti te, duo cu quas scripta."
                },
                new Staff
                {
                    StaffID = 6,
                    Department = DepartmentOptions.CARE,
                    JobPosition = JobPositionOptions.SITE_SUPERVISOR,
                    Profile = "uis aute irure dolor in reprehenderit " +
                    "in voluptate velit esse cillum dolore eu fugiat nulla pariatur."
                },
                new Staff
                {
                    StaffID = 7,
                    Department = DepartmentOptions.CARE,
                    JobPosition = JobPositionOptions.APPRENTICE,
                    Profile = "Ea putant torquatos scripserit sea, " +
                    "ius veri aperiri deleniti te, duo cu quas scripta."
                }
            };
            StaffList.ForEach(s => context.Staffs.AddOrUpdate(p => p.StaffID, s));
        }
    }
}
