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
