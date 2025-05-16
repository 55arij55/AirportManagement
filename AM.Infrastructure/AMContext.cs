using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Traveller> Travllers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=ArijDB;
                                        Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //La Premiere Methode
            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            modelBuilder.ApplyConfiguration(new PlaneConfiguration());

            modelBuilder.ApplyConfiguration(new PassengerConfiguration());

            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            modelBuilder.Entity<Staff>().ToTable("Staffs");

            modelBuilder.ApplyConfiguration(new TicketConfiguration()); //FluentAPI


            //La Deuxieme Methode
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName,
                full =>
                {
                    full.Property(f => f.FirstName).HasColumnName("PassFirstName")
                        .HasMaxLength(30);
                    full.Property(f => f.LastName).HasColumnName("PassLastName")
                        .IsRequired();
                });
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //Changer DateTime2 en Date
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("date");
        }
    }
}
