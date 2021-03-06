using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Service.API.Models
{
    public class UserCredential
    {
        [Required(ErrorMessage = "User Name is required")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
