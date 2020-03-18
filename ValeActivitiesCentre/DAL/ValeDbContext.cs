using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ValeActivitiesCentre.Models;

namespace ValeActivitiesCentre.DAL
{
    public class ValeDbContext : DbContext
    {
        public ValeDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivitySlot> ActivitySlots { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientProfile> ClientProfiles { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<RiskAssessment> RiskAssessments { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}