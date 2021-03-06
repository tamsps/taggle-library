using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggleLib.Entities;

namespace TaggleLib.Services
{
    public class JsonRepository : IDbContext, IDisposable
    {
        public bool CheckExistUser(string userId, string password)
        {
            bool isExist = false;
            try
            {
                ////Get data from JSON file
                string contentJson = System.IO.File.ReadAllText(@"Data\Users.json");
                var listUser = JsonConvert.DeserializeObject<List<Users>>(contentJson);
                //// Check exist user from JSON file
                var existUser = listUser.FirstOrDefault(d => string.Equals(d.Email, userId) == true && string.Equals(d.Password, password) == true);
                return existUser != null;

            }
            catch(Exception ex)
            {
                isExist = false;
            }
            return isExist;
        }

        /// <summary>
        /// Create new booking for each borrow
        /// </summary>
        /// <param name="book"></param>
        /// <param name="email"></param>
        public Booking CreateBooking(int bookId, string email)
        {
            try
            {
                var contentJson = System.IO.File.ReadAllText(@"Data\Booking.json");
                var listBooking = JsonConvert.DeserializeObject<List<Booking>>(contentJson);

                ////Check book available or not
                var checkAvailableBook = CheckAvailableBookByBookId(bookId);
                var checkValidUser = checkValidUserByEmail(email);
                //// Check valid of book and user have enough credit to borrow and user not over 5 book 
                if(checkAvailableBook != null && checkValidUser != null && checkValidUser.AvailableCredit >= checkAvailableBook.PriceCredit)
                {
                    ////Create new booking with expire date = now + 30 days
                    var newBooking = new Booking() { BookId = bookId, BookingId = (listBooking!=null? listBooking.Count() + 1:1) , Email = email, CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"), ExpDate = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy") };
                    if (listBooking == null)
                        listBooking = new List<Booking>();

                    listBooking.Add(newBooking);
                    var bookingStr = JsonConvert.SerializeObject(listBooking);
                    System.IO.File.WriteAllText(@"Data\Booking.json", bookingStr);

                    ////Update user info
                    UpdateUser(checkValidUser,checkAvailableBook.PriceCredit);

                    //// Update book
                    UpdateBook(checkAvailableBook);
                    return newBooking;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;

        }

        private void UpdateBook(Books checkAvailableBook)
        {
            var contentBookJson = System.IO.File.ReadAllText(@"Data\Books.json");
            var listBooks = JsonConvert.DeserializeObject<List<Books>>(contentBookJson);

            var curBook = listBooks.FirstOrDefault(d => d.BookId == checkAvailableBook.BookId);
            if (curBook != null)
            {
                curBook.RemainAvailable -= 1; 
            }
            var booksStr = JsonConvert.SerializeObject(listBooks);
            System.IO.File.WriteAllText(@"Data\Books.json", booksStr);
        }

        private void UpdateUser(Users checkValidUser, int priceCredit)
        {
            
            var contentUsersJson = System.IO.File.ReadAllText(@"Data\Users.json");
            var listUsers = JsonConvert.DeserializeObject<List<Users>>(contentUsersJson);
            var contentJson = System.IO.File.ReadAllText(@"Data\Booking.json");
            var listBooking = JsonConvert.DeserializeObject<List<Booking>>(contentJson);
            var bookingUser = listBooking.FindAll(d =>  string.Equals(d.Email,checkValidUser.Email) == true).ToList();

            var curUser = listUsers.FirstOrDefault(d => string.Equals(d.Email, checkValidUser.Email) == true);
            if (curUser != null)
            {
                curUser.AvailableCredit -= priceCredit;
                curUser.TotalBookIsBorrowing += 1;
                curUser.CurrentBooking = bookingUser;
            }
                

            var usersStr = JsonConvert.SerializeObject(listUsers);
            System.IO.File.WriteAllText(@"Data\Users.json", usersStr);
        }

        /// <summary>
        /// Check user still valif for borrowing
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private Users checkValidUserByEmail(string email)
        {
            try
            {
                var contentUsersJson = System.IO.File.ReadAllText(@"Data\Users.json");
                var listUsers = JsonConvert.DeserializeObject<List<Users>>(contentUsersJson);

                var findUser = listUsers.FirstOrDefault(d => string.Equals(d.Email,email));
                if (findUser != null)
                {
                    //// Check total book user is borrowing and check user's credit
                    if (findUser.TotalBookIsBorrowing < 5 && findUser.AvailableCredit >0)
                    {
                        return findUser;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// Check book valid or not
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        private Books CheckAvailableBookByBookId(int bookId)
        {
            try
            {
                var contentBookJson = System.IO.File.ReadAllText(@"Data\Books.json");
                var listBooks = JsonConvert.DeserializeObject<List<Books>>(contentBookJson);
                var findBook = listBooks.FirstOrDefault(d=>d.BookId == bookId);
                if(findBook!=null)
                {
                    //// Check quanlity of current in library
                    if(findBook.RemainAvailable > 0)
                    {
                        return findBook;
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// Create booking by list of book
        /// </summary>
        /// <param name="listBook"></param>
        /// <param name="email"></param>
        public void CreateBookingByListBook(List<Books> listBook, string email)
        {
            try
            {
                var contentJson = System.IO.File.ReadAllText(@"Data\Booking.json");
                var listBooking = JsonConvert.DeserializeObject<List<Booking>>(contentJson);
                foreach(var book in listBook)
                {
                    var newBooking = new Booking() { BookId = book.BookId, BookingId = listBooking.Count() + 1, Email = email, CreatedDate = DateTime.Now.ToString() };
                    listBooking.Add(newBooking);
                }
                
                var bookingStr = JsonConvert.SerializeObject(listBooking);
                System.IO.File.WriteAllText(@"Data\Booking.json", bookingStr);

            }
            catch (Exception ex)
            {

            }
        }

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
