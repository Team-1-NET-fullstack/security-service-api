using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Service.API.BAL.Interfaces
{
    public interface IUserService
    {
        bool IsAunthenticatedUser(string userName, string password);
    }
}
