using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HotelReservationsApp.Models
{
    public class HotelReservationsApp : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Room>()
                .HasMany(s => s.Booking)
                .WithOptional(c => c.Room)
                .HasForeignKey(c => c.Room_id)
                .WillCascadeOnDelete(false);
        }
    }
}