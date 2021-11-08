using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggleLib.Entities
{
    /// <summary>
    /// Entiry for manage Users in system
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Email is primary key
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Password 
        /// </summary>
        public int AvailableCredit { get; set; }
        /// <summary>
        /// Password 
        /// </summary>
        public int TotalBookIsBorrowing { get; set; }

        /// <summary>
        /// Current booking at this time
        /// </summary>
        public List<Books> CurrentBooking { get; set; }
    }
}
