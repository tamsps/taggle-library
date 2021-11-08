using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggleLib.Services
{
    public class AuthenticationRepository : IAuthenticationRepository, IDisposable
    {
        #region Property
        private readonly IDbContext _dbContex;

        #endregion
        #region Constructor
        public AuthenticationRepository(ServiceResolverHelper.ServiceResolver serviceAccessor)
        {
            _dbContex = serviceAccessor("JSON");
            //// Depend on which db type that we use exactly data base
            ////_dbContex = serviceAccessor("SQL");
            ////_dbContex = serviceAccessor("ORACLE");
        }

        #endregion

        public bool Login(string userId, string password)
        {
            var checkLogin = false;
            try
            {
                checkLogin = _dbContex.CheckExistUser(userId,password);

            }catch(Exception ex)
            {
                checkLogin = false;
            }
            return checkLogin;
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

    }
}
