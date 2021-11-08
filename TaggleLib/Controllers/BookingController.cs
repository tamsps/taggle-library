using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaggleLib.Entities;
using TaggleLib.Services;

namespace TaggleLib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        #region properties
        private readonly IDbContext _dbContex;
        private readonly IConfiguration Configuration;

        #endregion

        #region Constructor
        public BookingController(ServiceResolverHelper.ServiceResolver serviceAccessor, IConfiguration _config)
        {

            Configuration = _config;
            var curDb = Configuration["CurrDb"];
            _dbContex = serviceAccessor(curDb);
            //// Depend on which db type that we use exactly data base
            ////_dbContex = serviceAccessor("SQL");
            ////_dbContex = serviceAccessor("ORACLE");
        }
        #endregion
        #region Method
        [HttpPost]
        public Booking CreateBooking([FromBody] Booking booking)
        {
            try
            {
                var order = _dbContex.CreateBooking(booking.BookId, booking.Email);
                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}