using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
        public async Task<IActionResult> Buy([Bind("PassengerId,Name,Firstname,FK_FlightNo,SalePrice")] Passenger passenger, decimal price, int id, string name, string firstname )
        {

            if (ModelState.IsValid)
            {

                passenger.SalePrice = price;
                passenger.FK_FlightNo = id;
                passenger.Firstname = firstname;
                passenger.Name = name;

                var data = await ApiClientFactory.Instance.SavePassenger(passenger);


                return RedirectToAction(nameof(Index));

            }
            return View(passenger);
        }

     


        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == -1)
            {
                return NotFound();
            }


            var data = await ApiClientFactory.Instance.GetFlight(id);

            ViewBag.price = data.Price;

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }


    }
}
