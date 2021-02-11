using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class LoginViewModel
    {
        
        [Required, Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required, Display(Name = "Password")]
        public string PassWord { get; set; }
    
}
}
