using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Service.API.DAL.Interfaces
{
    public interface IUserRepository
    {
        bool IsAuthenticatedUser(string userName, string password);
    }
}
