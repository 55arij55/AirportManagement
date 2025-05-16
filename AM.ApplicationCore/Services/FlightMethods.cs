using System.Numerics;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = [];

        public Action<Domain.Plane> FlightDetailsDel;
        public Func<string,float> DurationAverageDel;

        public FlightMethods ()
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;

            FlightDetailsDel = p => {
                var query = from f in Flights
                            where f.Plane == p
                            select f;
                foreach (var flight in query)
                {
                    Console.WriteLine(flight.FlightDate + " " + flight.Destination);
                }
            };

            DurationAverageDel = dest =>
            {
                var query = from f in Flights
                            where f.Destination.Equals(dest)
                            select f.EstimatedDuration;
                return query.Average();
            };
        }

        public void DestinationGroupedFlights()
        {
            //var query = Flights.GroupBy(f => f.Destination)
            //    .ToList();
            //foreach (var group in lambdaQuery)
            //{
            //    Console.WriteLine("Destination " + group.Key);
            //    foreach (var flight in group)
            //    {
            //        Console.WriteLine("Decollage :" + flight.FlightDate);
            //    }
            //}

            var lambdaQuery = Flights.GroupBy(f => f.Destination)
                .ToList();

            foreach (var group in lambdaQuery)
                {
                Console.WriteLine("Destination " + group.Key);
                foreach (var flight in group)
                {
                    Console.WriteLine("Decollage :" + flight.FlightDate);
                }
            }
        }

        public IList<IList<Flight>> DestinationGroupedFlights1()
        {
            var query = Flights.GroupBy(f => f.Destination)
                .Select(group => (IList<Flight>)group.ToList())
                .ToList();
            return query;
        }


        public float DurationAverage(string destination)
        {
            //var query = from f in Flights
            //            where f.Destination.Equals(destination)
            //            select f.EstimatedDuration;
            //return query.Average();

            var lambdaQuery = Flights
                .Where(f => f.Destination.Equals(destination))
                                     .Select(f => f.EstimatedDuration);
            return lambdaQuery.Average();
        }

        //Avec For
        //public IList<DateTime> GetFlightDates(string destination)
        //{
        //    IList<DateTime> dates = new List<DateTime> { };
        //    for (int i = 0; i < Flights.Count; i++)
        //    {
        //        if (Flights[i].Destination.Equals(destination))
        //        {
        //            dates.Add(Flights[i].FlightDate);
        //        }
        //    }
        //    return dates;
        //}

        //Avec ForEach
        //public IList<DateTime> GetFlightDates(string destination)
        //{
        //    IList<DateTime> dates = new List<DateTime> { };
        //    foreach (var flight in Flights)
        //    {
        //        {
        //            if (flight.Destination.Equals(destination))
        //            {
        //                dates.Add(flight.FlightDate);
        //            }
        //        }
        //    }
        //    return dates;
        //}

        //Avec Linq
        public IList<DateTime> GetFlightDates(string destination)
        {
            //var query = from f in Flights
            //            where f.Destination.Equals(destination)
            //            select f.FlightDate;
            //return query.ToList();

            //Question 19
            var lambdaQuery = Flights.Where(f => f.Destination.Equals(destination))
                                     .Select(f => f.FlightDate);

            return lambdaQuery.ToList();
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination.Equals(filterValue))
                        {
                            Console.WriteLine(flight.ToString());
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(flight.ToString());
                        }
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in Flights)
                    {
                        if (flight.EffectiveArrival == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(flight.ToString());
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (var flight in Flights)
                    {
                        if (flight.EstimatedDuration == float.Parse(filterValue))
                        {
                            Console.WriteLine(flight.ToString());
                        }
                    }
                    break;
            }
        }

        public IList<Flight> OrderedDurationFlights()
        {
            //var query = from f in Flights
            //            orderby f.EstimatedDuration
            //            select f;
            //return query.ToList();

            var lambdaQuery = Flights.OrderByDescending(f => f.EstimatedDuration);
            return lambdaQuery.ToList();
        }

        ////Methode 1
        //public int ProgrammedFlightNumber(DateTime startDate)
        //{
        //    var query = from f in Flights
        //                where DateTime.Compare(f.FlightDate, startDate) >= 0
        //                && (f.FlightDate - startDate).TotalDays < 7
        //                select f;
        //    return query.Count();
        //}

        //Methode 2
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var query = from f in Flights
            //            where f.FlightDate >= startDate
            //            && (f.FlightDate < startDate.AddDays(7))
            //            select f;   
            //return query.Count();

            var lambdaQuery = Flights
                .Where(f => f.FlightDate >= startDate
                        && f.FlightDate < startDate.AddDays(7));

            return lambdaQuery.Count();
        }

        //public IList<Traveller> SeniorTravellers(Flight flight)
        //{
        //    //return flight.ListPassengers
        //    //             .OfType<Traveller>()
        //    //             .OrderByDescending(p => p.BirthDate)
        //    //             .Take(3)
        //    //             .ToList();

        //    var lambdaQuery = flight.ListPassengers
        //        .OfType<Traveller>()
        //        .OrderByDescending(p => p.BirthDate)
        //        .Take(3)
        //        .ToList();

        //    return lambdaQuery.ToList();
        //}

        public void ShowFlightDetails(Domain.Plane plane)
        {
            //var query = from f in Flights
            //            where f.Plane == plane
            //            select f;
            //foreach (var flight in query)
            //{
            //    Console.WriteLine(flight.FlightDate + " " + flight.Destination);
            //}

            var lambdaQuery = Flights.Where(f => f.Plane == plane);
            foreach (var flight in lambdaQuery)
            {
                Console.WriteLine(flight.FlightDate + " " + flight.Destination);
            }
        }
    }
}