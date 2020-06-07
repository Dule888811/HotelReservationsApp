using HotelReservationsApp.Models;
using HotelReservationsApp.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationsApp.Repository
{
    public class BookingsRepository : BaseRepository, IBookingsRepository
    {
        public BookingsRepository(Models.HotelReservationsApp context) : base(context)
        {

        }
        public List<Booking> Get(string id)
        {
            List<Booking> BookingsList = new List<Booking>();
            if(id == "1")
            {
                BookingsList.Add(this.GetById(140));
                BookingsList.Add(this.GetById(141));
               
            }
            if (id == "2")
            {
                BookingsList.Add(this.GetById(3));
                BookingsList.Add(this.GetById(114));
                BookingsList.Add(this.GetById(115));
                BookingsList.Add(this.GetById(116));
                BookingsList.Add(this.GetById(117));
                BookingsList.Add(this.GetById(139));

            }
            if (id == "3")
            {
                BookingsList.Add(this.GetById(152));
                BookingsList.Add(this.GetById(153));
                BookingsList.Add(this.GetById(154));
                BookingsList.Add(this.GetById(155));

            }
            if (id == "4")
            {
                BookingsList.Add(this.GetById(156));
                BookingsList.Add(this.GetById(157));
                BookingsList.Add(this.GetById(158));
                BookingsList.Add(this.GetById(159));
                BookingsList.Add(this.GetById(162));
                BookingsList.Add(this.GetById(163));
                BookingsList.Add(this.GetById(165));
                BookingsList.Add(this.GetById(166));
                BookingsList.Add(this.GetById(167));

            }
            return BookingsList;
        }

        public Booking GetById(int id)
        {
            return context.Bookings.Find(id);
        }

        public void AddBooking(Booking Booking)
        {
            context.Bookings.Add(Booking);
            base.SaveChanges();
        }

    }
}