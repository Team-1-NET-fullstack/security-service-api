using Microsoft.AspNetCore.Mvc;
using Security.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Service.API.DAL.Interfaces
{
    public interface IRepository
    {
        Task<ResponseMessege> Authenticate(UserCredential userCredential);
    }
}
