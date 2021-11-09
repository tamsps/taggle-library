using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggleLib.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int BookId { get; set; }
        public string Email { get; set; }
        public string CreatedDate { get; set; }
        public string ExpDate { get; set; }
    }
}
