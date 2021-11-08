using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggleLib.Services;

namespace TaggleLib
{
    public static class ServiceResolverHelper
    {
        public delegate IDbContext ServiceResolver(string key);

    }
}
