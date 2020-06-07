using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationsApp.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string Result { get; set; }

        public int StartDate { get; set; }


        public int EndDate { get; set; }

        public Nullable<int> Room_id { get; set; }
        [ForeignKey("Room_id")]
        public virtual Room Room { get; set; }
    }
}