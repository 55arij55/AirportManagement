using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public String? Departure { get; set; }
        public String? Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }

        [ForeignKey("PlaneId")]
        public int PlaneId { get; set; }
        public virtual Plane Plane { get; set; }
        public virtual ICollection<Ticket> ListTickets { get; set; }
        //public ICollection<Passenger> ListPassengers { get; set; }
        public string? AirlineLogo { get; set; }
        public string? Pilot { get; set; }

        public override string ToString()
        {
            return "Flight ID: " + FlightId
                + " Destination: " + Destination;
        }
    }
}