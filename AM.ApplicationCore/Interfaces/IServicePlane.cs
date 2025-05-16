using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {
        IList<Traveller> GetPassengers(Plane plane);
        IList<Flight> getNFlightsOrderdByDate(int n);
        bool IsAvailable(int n, Flight flight);
        void DeleteOldPlanes();
    }
}
