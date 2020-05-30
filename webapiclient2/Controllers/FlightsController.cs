using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using webapiclient2.Factory;
using webapiclient2.Models;
using webapiclient2.Utility;

namespace MVC_PartnerSite.Controllers
{
    public class FlightsController : Controller
    {
        private readonly ILogger<FlightsController> _logger;
        private readonly IOptions<MySettingsModel> appSettings;

        public FlightsController(ILogger<FlightsController> logger, IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            _logger = logger;
        }



        // GET: Flights

        //Version donnée par le tuto
        public async Task<IActionResult> IndexAsync()
        {
            var data = await ApiClientFactory.Instance.GetFlights();
            return View(data);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Buy()
        {
            return View();
        }

        //ADD A PASSENGER
        //UPDATE THE NUMBER OF THE SEATS
        //CREATE A BOOKING WITH FLIGHT NO AND ASSIGN IT TO THE RIGHT CLIENT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy([Bind("PassengerId,Name,Firstname,FK_FlightNo,SalePrice")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
               
                var data = await ApiClientFactory.Instance.SavePassenger(passenger);
                return RedirectToAction(nameof(Index));

            }
            return View(passenger);
        }





/*
     
        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == -1)
            {
                return NotFound();
            }

            var data = await ApiClientFactory.Instance.GetFlight(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }


        
        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightNo,Departure,Destination,Date,Seats,Price")] Flight flight)
        {
            if (id != flight.FlightNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }


        
     // GET: Flights/Delete/5
     public async Task<IActionResult> Delete(int? id)
     {
         if (id == null)
         {
             return NotFound();
         }

         var flight = await _context.Flight
             .FirstOrDefaultAsync(m => m.FlightNo == id);
         if (flight == null)
         {
             return NotFound();
         }

         return View(flight);
     }

     // POST: Flights/Delete/5
     [HttpPost, ActionName("Delete")]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> DeleteConfirmed(int id)
     {
         var flight = await _context.Flight.FindAsync(id);
         _context.Flight.Remove(flight);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
     }

     private bool FlightExists(int id)
     {
         return _context.Flight.Any(e => e.FlightNo == id);
     }



      // GET: Flights/Delete/5
     public async Task<IActionResult> Delete(int? id)
     {
         if (id == null)
         {
             return NotFound();
         }


         var data = await ApiClientFactory.Instance.DeleteFlight(id);




         if (flight == null)
         {
             return NotFound();
         }

         return View(flight);
     }

     // POST: Flights/Delete/5
     [HttpPost, ActionName("Delete")]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> DeleteConfirmed(int id)
     {
         var flight = await _context.Flight.FindAsync(id);
         _context.Flight.Remove(flight);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
     }

     private bool FlightExists(int id)
     {
         return _context.Flight.Any(e => e.FlightNo == id);
     }

 */
    }
}
