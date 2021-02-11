using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{

    public class MyContext : DbContext  // 自定义的,必须继承DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) // 此构造函数是固定写法，将本身类型的options传递给父类构造函数，注意MyContext
        { }
        public DbSet<User> users { get; set; } // 添加一个model类，此实体类再migration时会再数据库中创建一个Student表
    }
}
