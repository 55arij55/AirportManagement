using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        private readonly IServiceFlight _flightService;
        private readonly IServicePlane _planeService;

        public FlightController(IServiceFlight serviceFlight, IServicePlane planeService)
        {
            _flightService = serviceFlight;
            _planeService = planeService;
        }

        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
                return View(_flightService.GetAll().ToList());
            else
                return
                View(_flightService.GetMany(f => f.FlightDate.Date.Equals(dateDepart)).ToList());
        }

        public ActionResult Sort()
        {
            return View("Index", _flightService.SortFlights());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.Planes = new SelectList(_planeService.GetAll().ToList(),
"PlaneId", "PlaneId");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight,IFormFile PilotImage)
        {
            try
            {
                if(PilotImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", PilotImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PilotImage.CopyTo(stream);
                    flight.Pilot = PilotImage.FileName;
                }
                _flightService.Add(flight);
                _flightService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5  
        public ActionResult Edit(int id)
        {
            var flight = _flightService.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }

            var planes = _planeService.GetAll().ToList();
            ViewBag.Planes = new SelectList(planes, "PlaneId", "PlaneId", flight.PlaneId);

            return View(flight);
        }



        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight flight, IFormFile PilotImage)
        {
            try
            {
                if (PilotImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", PilotImage.FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        PilotImage.CopyTo(stream);
                    }
                    flight.Pilot = PilotImage.FileName;
                }

                _flightService.Update(flight);
                _flightService.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(flight);
            }
        }


        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var flight = _flightService.GetById(id);
                if (flight != null)
                {
                    _flightService.Delete(flight);
                    _flightService.Commit();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
