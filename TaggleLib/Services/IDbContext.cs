using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggleLib.Entities;

namespace TaggleLib.Services
{
    public interface IDbContext
    {
        /// <summary>
        /// Check exist user in db
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckExistUser(string userId, string password);

        /// <summary>
        /// Create booking by email
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="email"></param>
        public Booking CreateBooking(int bookId, string email);

        /// <summary>
        /// User return a book back to library
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ReturnBook(int bookId, string email);
        /// <summary>
        /// Show all current booking of user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Booking ShowBooking(string email);
        /// <summary>
        /// Check all booking have expired of a user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<Booking> CheckBookingExpired(string email);
        /// <summary>
        /// Check booking that next to expire in next week
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<Booking> CheckBookingNextToExpire(string email);

    }
}
