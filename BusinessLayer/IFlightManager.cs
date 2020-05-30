using System;

namespace BusinessLayer
{
    public interface IFlightManager
    {

        int BuyTicket(int FlightNo, int BookingNo, decimal SalePrice);


    }
}
