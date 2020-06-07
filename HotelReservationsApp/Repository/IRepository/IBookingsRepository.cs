using HotelReservationsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationsApp.Repository.IRepository
{
   public interface IBookingsRepository
    {
        List<Booking> Get(string id);
        Booking GetById(int id);
        void AddBooking(Booking Booking);
    }
}
