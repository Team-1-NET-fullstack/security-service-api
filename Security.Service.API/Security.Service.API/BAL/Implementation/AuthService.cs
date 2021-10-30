using Security.Service.API.BAL.Interfaces;
using Security.Service.API.DAL.Interfaces;
using Security.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Service.API.BAL.Implementation
{
    public class AuthService:IAuthService
    {
        private readonly IRepository repository;
        public AuthService(IRepository repository)
        {
            this.repository = repository;
        }

        public Task<ResponseMessege> Authenticate(UserCredential userCredential)
        {
           return repository.Authenticate(userCredential);
        }
    }
}
