using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boeing,
        Airbus
    }

    public class Plane
    {
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> ListFlights { get; set; }

        public override string ToString()
        {
            return "Plane ID: " + PlaneId
                + " Capacity: " + Capacity
                + " Plane Type: " + PlaneType;
        }

        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            PlaneType = pt;
            this.Capacity = capacity;
            ManufactureDate = date;
        }

        public Plane()
        {
        }
    }
}