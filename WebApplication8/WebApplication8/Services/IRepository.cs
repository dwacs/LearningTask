using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Services
{
  public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Add(T model);
        T Edit(T model);
        T GetById(object Id);
    }
}
