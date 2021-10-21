using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Security.Service.API.BAL.Implementation;
using Security.Service.API.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _iConfig;
        private readonly IUserService _userService;



        public AuthController(IConfiguration iConfig, IUserService userService)
        {
            _userService = userService;
            _iConfig = iConfig;

        }
        [HttpGet("GetJWTToken")]
        public ActionResult<string> GetJWTToken()
        {
            //IUserService userService = new UserService();
            //userService.IsAunthenticatedUser("Username","Password");
            return "Praveen";
        }

    }
}
