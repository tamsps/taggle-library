using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaggleLib.Entities;
using TaggleLib.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaggleLib.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        #region Properties
        private readonly IAuthenticationRepository _authen;
        private readonly ILogger<AuthenticationController> _logger;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for authen ticattion
        /// </summary>
        /// <param name="authen"></param>
        public AuthenticationController(IAuthenticationRepository authen )
        {
            _authen = authen;
        }
        #endregion

        #region Method
        // GET: /<controller>/
        [HttpPost]

        public IActionResult Login([FromBody]Users user)
        {
            try
            {
               var checkLogin = _authen.Login(user.Email, user.Password);
                return Ok(checkLogin == true);

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion
    }
}
