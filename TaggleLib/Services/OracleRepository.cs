using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggleLib.Entities;

namespace TaggleLib.Services
{
    public class OracleRepository : IDbContext, IDisposable
    {
     
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }


        public bool CheckExistUser(string userId, string password)
        {
            throw new NotImplementedException();
        }

        public void CreateBooking(Books book, string email)
        {
            throw new NotImplementedException();
        }

        public Booking CreateBooking(int bookId, string email)
        {
            throw new NotImplementedException();
        }

        public bool ReturnBook(int bookId, string email)
        {
            throw new NotImplementedException();
        }

        public Booking ShowBooking(string email)
        {
            throw new NotImplementedException();
        }

        public List<Booking> CheckBookingExpired(string email)
        {
            throw new NotImplementedException();
        }

        public List<Booking> CheckBookingNextToExpire(string email)
        {
            throw new NotImplementedException();
        }
    }
}
