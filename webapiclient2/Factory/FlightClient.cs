using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiclient2.Models;

namespace webapiclient2
{
    public partial class ApiClient
    {


        readonly string baseuri = "https://localhost:44378/api/Flights/";


        public async Task<List<Flight>> GetFlights()
        {
            //string.Format(System.Globalization.CultureInfo.InvariantCulture, "Flights/")

            var requestUrl = CreateRequestUri(baseuri);
            return await GetAsync<List<Flight>>(requestUrl);
        }


        public async Task<List<Flight>> GetFlight(int Id)
        {
            //string.Format(System.Globalization.CultureInfo.InvariantCulture, "Flights/")

            var requestUrl = CreateRequestUri(baseuri + Id);
            return await GetAsync<List<Flight>>(requestUrl);
        }

        public async Task<Message<Flight>> SaveFlight(Flight model)
        {
            var requestUrl = CreateRequestUri(baseuri);
            return await PostAsync<Flight>(requestUrl, model);
        }


        public async Task<Message<Flight>> UpdateSeats(Flight model)
        {
            var requestUrl = CreateRequestUri(baseuri);


            return await PutAsync<Flight>(requestUrl, model.SeatsAvailable - 1);
        }


    }
}
