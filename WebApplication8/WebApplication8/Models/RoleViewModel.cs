using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required, Display(Name = "角色")]
        public string Name { get; set; }
    }
}
