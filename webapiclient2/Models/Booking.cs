using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_PartnerSite.Models
{
    public class Booking
    {

        [Key]
        public int BookingId { get; set; }
        public int FK_FlightNo { get; set; }
        public int FK_PassengerId { get; set; }
        public decimal SalePrice { get; set; }

    }
}
