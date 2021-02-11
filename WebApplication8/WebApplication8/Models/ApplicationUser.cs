using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class ApplicationUser : IdentityUser // IdentityUser 必须引用 Microsoft.AspNetCore.Identity;
    {
        public ApplicationUser()
        {
            Claims = new List<IdentityUserClaim<string>>();
            Logins = new List<IdentityUserLogin<string>>();
            Tokens = new List<IdentityUserToken<string>>();
            UserRoles = new List<IdentityUserRole<string>>();
        }

        // 在 IdentityUser 的基础上拓展两个字段属性。
        public string NickName { get; set; }
       // public int Gender { get; set; }

        // 以下四个属性是 Identity 内置的四个权限属性，照着添加上去再权限校验的时候用到。
        public ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public ICollection<IdentityUserRole<string>> UserRoles { get; set; }
    }
}
