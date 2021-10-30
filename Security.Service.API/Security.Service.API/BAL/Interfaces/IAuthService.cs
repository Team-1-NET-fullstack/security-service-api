using Security.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Service.API.BAL.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseMessege> Authenticate(UserCredential userCredential);
    }
}
