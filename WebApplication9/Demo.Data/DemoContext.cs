using Microsoft.EntityFrameworkCore;
using System;
using WebApplication9.Models;

namespace Demo.Data
{
    public class DemoContext: DbContext
    {   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Data Source=(localdb)\\MSSQLLocalDB ; Initial Catalog=Demo");
        }
        public DbSet<Users> Users { get; set; }   //把这个映射到数据库的表，所以需要数据库连接字符串
    }
}
