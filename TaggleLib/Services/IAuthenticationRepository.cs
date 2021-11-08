using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggleLib.Services
{
    public interface IAuthenticationRepository
    {
        bool Login(string userId, string password);
    }
}
