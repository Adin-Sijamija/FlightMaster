using FlightMaster.WebAPI.Database.ClassModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI
{
    public class FlightMasterContext : DbContext
    {

        public FlightMasterContext()
        {
            Database.SetCommandTimeout(360);
        }

        public DbSet<Airfield> Airfields { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Luxuries> Luxuries { get; set; }
        public DbSet<LuxuryPreferences> LuxuryPreferences { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<FlightTicketLuxuries> FlightTicketLuxuries { get; set; }
        public DbSet<FlightTicketType> FlightTicketTypes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketPreferences> TicketPreferences { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
       
        public DbSet<PlaneType> PlaneType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Flight>().Property(x => x.Status).HasConversion(v => v.ToString(),
                v => (Flight.FlightStatus)Enum.Parse(typeof(Flight.FlightStatus), v));

            modelBuilder.Entity<Plane>().HasIndex(x => x.Name).IsUnique(true);
            modelBuilder.Entity<TicketPreferences>().HasKey(k => new { k.CustomerId, k.TicketTypeId });

            modelBuilder.Entity<TicketPreferences>()
                .HasOne(c => c.Customer)
                .WithMany(cc => cc.TicketPreferences)
                .HasForeignKey(k => k.CustomerId);

            modelBuilder.Entity<TicketPreferences>()
              .HasOne(c => c.TicketType)
              .WithMany(cc => cc.TicketPreferences)
              .HasForeignKey(k => k.TicketTypeId);

            modelBuilder.Entity<LuxuryPreferences>().HasKey(k => new { k.CustomerId, k.LuxuriesId });

            modelBuilder.Entity<LuxuryPreferences>()
                .HasOne(c => c.Customer)
                .WithMany(cc => cc.LuxuryPreferences)
                .HasForeignKey(k => k.CustomerId);

            modelBuilder.Entity<LuxuryPreferences>()
              .HasOne(c => c.Luxuries)
              .WithMany(cc => cc.LuxuryPreferences)
              .HasForeignKey(k => k.LuxuriesId);

            modelBuilder.Entity<FlightTicketLuxuries>()
              .HasOne(c => c.FlightTicketType)
             .WithMany(cc => cc.FlightTicketLuxuries)
             .HasForeignKey(k => k.FlightTicketTypeID);

             modelBuilder.Entity<FlightTicketLuxuries>()
            .HasOne(c => c.Luxuries)
            .WithMany(cc => cc.FlightTicketLuxuries)
            .HasForeignKey(k => k.LuxuriesID);
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = 150033; Integrated Security = True;");
        }

    }



}
