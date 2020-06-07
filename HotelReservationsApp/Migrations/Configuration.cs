namespace HotelReservationsApp.Migrations
{
    using HotelReservationsApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<global::HotelReservationsApp.Models.HotelReservationsApp>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(global::HotelReservationsApp.Models.HotelReservationsApp context)
        {
                for (var i = 1; i <= 1000; i++)
            {
                context.Rooms.AddOrUpdate(x => x.id,
                   new Room() {  Name = "Room" + " " + i }
                   );
            } 
            
        }
    }
}
