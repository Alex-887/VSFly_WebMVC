using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiclient2.Models;

namespace webapiclient2
{
    public partial class ApiClient
    {



        //GET FLIGHTS = DISPLAY ALL THE FLIGHTS
        //GET FLIGHT(ID) = DETAIL OF A CHOSEN FLIGHT


        readonly string uriFlight = "https://localhost:44378/api/Flights/";


        public async Task<List<Flight>> GetFlights()
        {
            //string.Format(System.Globalization.CultureInfo.InvariantCulture, "Flights/")

            var requestUrl = CreateRequestUri(uriFlight);
            return await GetAsync<List<Flight>>(requestUrl);
        }



        public async Task<Flight> GetFlight(int id)
        {
            //string.Format(System.Globalization.CultureInfo.InvariantCulture, "Flights/")

            var requestUrl = CreateRequestUri(uriFlight + id);
            return await GetAsync<Flight>(requestUrl);
        }


    }
}
