using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiclient2.Models;

namespace webapiclient2
{
    public partial class ApiClient
    {


        //optional
        public async Task<List<Passenger>> GetPassengers()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Passengers/"));
            return await GetAsync<List<Passenger>>(requestUrl);
        }

        public async Task<Message<Passenger>> SavePassenger(Passenger model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Passengers/"));
            return await PostAsync<Passenger>(requestUrl, model);
        }


    }
}
