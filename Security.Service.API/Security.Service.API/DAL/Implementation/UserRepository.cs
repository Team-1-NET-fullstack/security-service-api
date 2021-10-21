using Security.Service.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Service.API.DAL.Implementation
{
    public class UserRepository : IUserRepository
    {
        public bool IsAuthenticatedUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
