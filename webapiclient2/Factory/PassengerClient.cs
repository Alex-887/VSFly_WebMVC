using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapiclient2.Models;

namespace webapiclient2
{
    public partial class ApiClient
    {


        public async Task<Message<Passenger>> SavePassenger(Passenger model)
        {
            var requestUrl = CreateRequestUri("https://localhost:44378/api/Passengers");




            return await PostAsync<Passenger>(requestUrl, model);
        }







    }
}
