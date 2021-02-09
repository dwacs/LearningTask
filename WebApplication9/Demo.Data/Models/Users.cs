using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public class Users
    {
        public int Id { get; set; }
      [Required]
        [MaxLength(100)]
        public string Name { get; set; }
      
        [Required, MaxLength(50)]
        public string Surname { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        
        // public bool EmailValid { get; set; }
    }
}
