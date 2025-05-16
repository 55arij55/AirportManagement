using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        IUnitOfWork unitOfWork;
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IList<Traveller> GetPassenger(Plane plane, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IList<Staff> GetStaff(int flightId)
        {
         
            return GetById(flightId).ListTickets
                .Select(t => t.MyPassenger)
                .OfType<Staff>()
                .Distinct()
                .ToList();
        }

        public IList<Traveller> GetTravellers(Plane plane, DateTime date)
        {
            return plane.ListFlights.Where(f => f.FlightDate == date)
                .SelectMany(f => f.ListTickets)
                .Select(t => t.MyPassenger)
                .OfType<Traveller>()
                .Distinct()
                .ToList();
        }

        public IEnumerable<Flight> SortFlights()
        {
            return GetAll().OrderByDescending(f => f.FlightDate);
        }
    }
}
