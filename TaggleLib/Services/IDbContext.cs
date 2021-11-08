using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggleLib.Services
{
    public interface IDbContext
    {
        public bool CheckExistUser(string userId, string password);
    }
}
