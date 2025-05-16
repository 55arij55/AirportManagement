using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight:IService<Flight>
    {
        IList<Staff> GetStaff(int flightId);
        IList<Traveller> GetPassenger(Plane plane, DateTime date);
        IEnumerable<Flight> SortFlights();

    }
}
