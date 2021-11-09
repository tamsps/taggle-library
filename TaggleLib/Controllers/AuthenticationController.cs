using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration Configuration;

        #endregion

        #region Constructor
        //public AuthenticationController(IAuthenticationRepository authen)
        //{
        //    _authen = authen;
        //}
        /// <summary>
        /// Constructor for authen ticattion
        /// </summary>
        /// <param name="authen"></param>
        public AuthenticationController(IAuthenticationRepository authen , IConfiguration _config)
        {
            _authen = authen;
            Configuration = _config;

        }
        #endregion

        #region Method
        // GET: /<controller>/
        [HttpPost]

        public bool Login([FromBody]Users user)
        {
            try
            {
                var checkLogin = _authen.Login(user.Email, user.Password);
                return checkLogin;

            }catch(Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
