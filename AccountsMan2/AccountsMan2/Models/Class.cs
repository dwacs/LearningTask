using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsMan2.Models
{
    public class Users
    {
         
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegDate { get; set; }
        public int AccessAuthority { get; set; }
    
}
}
