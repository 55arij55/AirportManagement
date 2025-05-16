using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            ////Configuration Many To Many
            //builder.HasMany(f => f.ListPassengers)
            //    .WithMany(p => p.Flights)
            //    .UsingEntity(j => j.ToTable("ReservationFlightPassenger")
            //);

            ////Configuration One To Many
            //builder.HasOne(p => p.Plane)
            //    .WithMany(f => f.ListFlights)
            //    .HasForeignKey(f => f.PlaneId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
