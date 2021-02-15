using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class AccountClaimsViewModel
    {
        public AccountClaimsViewModel()
        {
            Claims = new List<string>();
        }
        public string UserId { get; set; }
        public string UserClaim { get; set; }
        public List<string> Claims { get; set; }
    }
}
