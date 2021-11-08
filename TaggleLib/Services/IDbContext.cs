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
        public void CreateBooking(int bookId, string email);

    }
}
