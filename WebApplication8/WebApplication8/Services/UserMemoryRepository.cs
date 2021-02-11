using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services
{
   
        public class UserMemoryRepository : IRepository<User> // 继承基仓储接口，并实现方法UserMemoryRepository 表示的是IRepository具体的实现类型。
        {
            private readonly List<User> users;
            public UserMemoryRepository()
            {
                users = new List<User> {
                new User{
                    Id = 1,
                    UserName = "dwacs",
                    Password = "mztknaixt",
                    RegDate = new DateTime(2021,2,4),
                   AccessAuthority = 1,
                },
                new User{
                    Id = 2,
                    UserName = "qixiang.xu15@gmail.com",
                    Password = "Mztkn9799@",
                    RegDate = new DateTime(2021,2,5),
                   AccessAuthority = 2


                }
            };
            }
            public User Add(User model)        //add a user
            {
                var maxId = users.Max(x => x.Id);
                model.Id = maxId + 1;
                users.Add(model);
                return model;
            }


            public User Edit(User vm)
            {
                var model = users.FirstOrDefault(p => p.Id == vm.Id);
                if (model != null)
                {
                    model.UserName = vm.UserName;
                    model.Password = vm.Password;
                    model.RegDate = vm.RegDate;
                    model.AccessAuthority = vm.AccessAuthority;
                    return model;
                }
                return null;
            }





            public IEnumerable<User> GetAll()
            {
                return users.AsEnumerable();
            }

            public User GetById(object Id)
            {
                return users.FirstOrDefault(p => p.Id == (int)Id);
            }
        }
    
}
