using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Security.Service.API.DAL.Interfaces;
using Security.Service.API.Data;
using Security.Service.API.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Security.Service.API.DAL.Implementation
{
    public class Repository : IRepository
    {
        private readonly CTGeneralHospitalContext dbContext;
        public IConfiguration _configuration;
        public Repository(CTGeneralHospitalContext ctGeneralHospitalContext, IConfiguration configuration)
        {
            this.dbContext = ctGeneralHospitalContext;
            _configuration = configuration;
        }
        public async Task<ResponseMessege> Authenticate(UserCredential model)
        {
            var resObj = new ResponseMessege();
            var user = await dbContext.Users.FirstOrDefaultAsync(e => e.EmailId == model.EmailId && e.Password == Encoding.UTF8.GetBytes(model.Password));
            if (user != null)
            {
                resObj.IsSuccess = true;
                resObj.message = Constants.LOGINSUCCESSFULL + " " + user.FirstName + " " + user.LastName;
                resObj.NoOfAttempts = 0;
                resObj.RoleId = user.RoleId;
                resObj.email = user.EmailId;
                resObj.IsFirstTimeUser = user.IsFirstTimeUser;
                resObj.UserId = user.UserId;
                resObj.EmployeeId = user.EmployeeId;

                //Update db
                user.WorngAttempts = 0;
                await dbContext.SaveChangesAsync();

                var userRole = await dbContext.Roles.FirstOrDefaultAsync(e => e.RoleId == user.RoleId);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FirstName+user.LastName),
                    new Claim(ClaimTypes.Email, user.EmailId),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, userRole.RoleName),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddMinutes(30),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                resObj.Token = new JwtSecurityTokenHandler().WriteToken(token);
                resObj.Expires = token.ValidTo;
                return resObj;
            }
            else
            {
                var userExist = await dbContext.Users.Where(e => e.EmailId == model.EmailId).FirstOrDefaultAsync();
                if (userExist != null)
                {
                    if (userExist.WorngAttempts < 2)
                    {
                        userExist.WorngAttempts++;
                        resObj.message = Constants.InvalidLoginCredentials;
                    }
                    else
                    {
                        userExist.WorngAttempts++;
                        userExist.IsActive = false;
                        resObj.message = Constants.LoginUserLocked;
                    }

                }
                else if (userExist == null)
                {
                    resObj.message = Constants.LoginUserLocked;
                }
                else
                    resObj.message = Constants.LoginUserLocked;

                resObj.IsSuccess = false;
                // resObj.NoOfAttempts = userExist != null ?userExist.wrongAttempts : 0;
                await dbContext.SaveChangesAsync();

                return resObj;

            }
            //return Unauthorized();
        }
    }

}
