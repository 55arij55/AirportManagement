using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AM.ApplicationCore.Domain
{
    [PrimaryKey("FlightFK","PassengerFK")]
    public class Ticket
    {
        public double prix { get; set; }
        public int siege { get; set; }
        public bool VIP { get; set; }
        public virtual Flight MyFlight { get; set; }
        public virtual Passenger MyPassenger { get; set; }
        [ForeignKey("MyFlight")]
        public int FlightFK { get; set; }
        [ForeignKey("MyPassenger")]
        public String PassengerFK { get; set; }
    }
}