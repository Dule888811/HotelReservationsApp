using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationsApp.Repository
{
    public class BaseRepository
    {
        protected readonly Models.HotelReservationsApp context;

        public BaseRepository(Models.HotelReservationsApp context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}