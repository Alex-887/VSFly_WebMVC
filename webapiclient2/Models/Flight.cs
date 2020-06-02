using System;
using System.ComponentModel.DataAnnotations;

namespace webapiclient2.Models
{

        public class Flight
        {

        [Key]
        public int FlightNo { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public int Seats { get; set; }
        public decimal Price { get; set; }
        public int SeatsAvailable { get; set; }

        }
    
}
