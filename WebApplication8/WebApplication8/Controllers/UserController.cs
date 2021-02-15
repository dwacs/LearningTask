using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.Services;

namespace WebApplication8.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
       
        public UserController(IRepository<User> userRepository)
        {
            UserRepository = userRepository;
        }

        public IRepository<User>UserRepository { get; }

        public IActionResult Index()
        {
            var list = UserRepository.GetAll();
            var vm = list.Select(p => new UserViewModel
            {
                Id = p.Id,
                UserName = $"{p.UserName}",
                Age =p.RegDate
            });
            return View(vm);
        }

        public IActionResult Add()
        {
            Console.WriteLine("hhcsb");
            ViewBag.Type = "Add";
            return View();
        }
        public IActionResult Edit(int Id)
        {
            ViewBag.Type = "Edit";
            var model = UserRepository.GetById(Id);
            return View(nameof(Add), new UserInsertViewModel
            {
                Id = model.Id,
                UserName = model.UserName,
                Password = model.Password,
                RegDate = model.RegDate,
                AccessAuthority = model.AccessAuthority
            });
        }
        [HttpPost]
        public IActionResult Add(User vm)
        {
            Console.WriteLine("dwacs");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Data Error by xqx");
                return View(vm);
            }
           // var type = Request.Form["Type"];
           //if (type == "Add")
           // {
           // var result = UserRepository.Add(new User
           // {
           //     Id = vm.Id,
           //     UserName = vm.UserName,
           //     Password = vm.Password,
           //     RegDate = vm.RegDate,
           //     AccessAuthority = vm.AccessAuthority
           // });
           //}
           //   else
           // {
           //     var result = UserRepository.Edit(new User
           //     {
           //         Id = vm.Id,
           //         UserName = vm.UserName,
           //         Password = vm.Password,
           //         RegDate = vm.RegDate,
           //         AccessAuthority = vm.AccessAuthority
           //     });
           //  }

            return RedirectToAction(nameof(Index));
        }

    }


}
