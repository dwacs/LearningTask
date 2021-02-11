using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class UserInsertViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User name cannot be empty")]
        [Display(Name = "UserName"), MaxLength(10, ErrorMessage = "Maximum length is 10")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        [Display(Name = "Password"), MaxLength(10, ErrorMessage = "Maximum length is 10")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Registration Date")]
        [DataType(DataType.DateTime)]
        public DateTime RegDate { get; set; }
        [Required]
        [Display(Name = "Access level")]
        public int AccessAuthority { get; set; }
    }
}
