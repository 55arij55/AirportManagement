using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

/****** Atelier 1 ******/

////Plane plane1 = new Plane();
////plane1.Capacity = 100;
////plane1.ManufactureDate = new DateTime(2024, 05, 23);
////plane1.PlaneId = 1;
////plane1.PlaneType = PlaneType.Boeing;
////Console.WriteLine(plane1.ToString());
////Plane plane2 = new Plane(PlaneType.Airbus, 200, DateTime.Now);
////Console.WriteLine(plane2.ToString());

//Plane plane3 = new Plane
//{
//    Capacity = 300,
//    ManufactureDate = DateTime.Now,
//    PlaneId = 3,
//    PlaneType = PlaneType.Airbus
//};
//Plane plane4 = new Plane { };
//Console.WriteLine(plane3.ToString());
//Console.WriteLine(plane4.ToString());

Passenger passenger = new()
{
    FullName = new FullName
    {
        FirstName = "seif",
        LastName = "ZNATI"
    },
    EmailAddress = "seifeddine.znati@esprit.tn"
};
Console.WriteLine("Before Extension");
Console.WriteLine(passenger.ToString());
Console.WriteLine("After Extension");
passenger.UpperFullName();
Console.WriteLine(passenger.ToString());
Console.WriteLine("Before Extension");
Console.WriteLine(passenger.ToString());
Console.WriteLine("After Extension");
passenger.UpperFullName();
Console.WriteLine(passenger.ToString());

//Console.WriteLine(passenger.ToString());
//Console.WriteLine(passenger.CheckProfile("Seif", "Znati"));
//Console.WriteLine(passenger.CheckProfile("Ons", "Znati"));
//Console.WriteLine(passenger.CheckProfile("Seif", "Znati", "seifeddine.znati@esprit.tn"));
//Console.WriteLine(passenger.CheckProfile("Seif", "Znati", "znatiseif@gmail.com"));
//passenger.PassengerType();
//Staff staff = new Staff
//{
//    FirstName = "StaffFName",
//    LastName = "StaffLN"
//};
//Traveller traveller = new Traveller
//{
//    Nationality = "Tunisian",
//    FirstName = "FNTraveller"
//};
//staff.PassengerType();
//traveller.PassengerType();

/*******Atelier 2*******/
FlightMethods flightMethods = new()
{
    Flights = TestData.listFlights
};

foreach (var item in flightMethods.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}

flightMethods.GetFlights("Destination", "Paris");

flightMethods.ShowFlightDetails(TestData.BoingPlane);

Console.WriteLine(flightMethods.ProgrammedFlightNumber(new DateTime(2022, 01, 04, 15, 10, 10)));

Console.WriteLine(flightMethods.DurationAverage("Madrid")+" Heures");

foreach (var item in flightMethods.OrderedDurationFlights())
{
    Console.WriteLine(item.ToString());
}

Console.WriteLine("Senior Travellers");

//foreach (var item in flightMethods.SeniorTravellers(TestData.flight1))
//{
//    Console.WriteLine(item.ToString());
//}

flightMethods.DestinationGroupedFlights();

var groupedFlights = flightMethods.DestinationGroupedFlights1();
foreach (var group in groupedFlights)
{
    Console.WriteLine("Destination: " + group.First().Destination);
    foreach (var flight in group)
    {
        Console.WriteLine(flight.ToString());
    }
}

Console.WriteLine("Delegate Functions");
flightMethods.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine(flightMethods.DurationAverage("Paris"));

AMContext context = new AMContext();
//context.Flights.Add(TestData.flight2);
//context.SaveChanges();

Console.WriteLine(context.Flights.First().Plane.Capacity);