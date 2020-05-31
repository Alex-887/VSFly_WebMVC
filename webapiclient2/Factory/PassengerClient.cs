using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiclient2.Models;

namespace webapiclient2
{
    public partial class ApiClient
    {

        //WHEN BUYING A TICKET, A NEW PASSENGER IS CREATED
        readonly string baseuri = "https://localhost:44378/api/Passengers";

        public async Task<Message<Passenger>> SavePassenger(Passenger model)
        {
            var requestUrl = CreateRequestUri(baseuri);

            return await PostAsync<Passenger>(requestUrl, model);
        }

    }
}
