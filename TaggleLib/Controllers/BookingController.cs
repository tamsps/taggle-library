using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        #endregion

        #region Constructor
        public BookingController(ServiceResolverHelper.ServiceResolver serviceAccessor)
        {
            _dbContex = serviceAccessor("JSON");
            //// Depend on which db type that we use exactly data base
            ////_dbContex = serviceAccessor("SQL");
            ////_dbContex = serviceAccessor("ORACLE");
        }
        #endregion
        #region Method
        [HttpPost]

        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            try
            {
                _dbContex.CreateBooking(booking.BookId, booking.Email);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion
    }
}