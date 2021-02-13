using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await roleManager.Roles.ToListAsync());
        }

        public IActionResult Add()
        {
            ViewBag.Type = "Add";
            return View();
        }
        public async Task<IActionResult> Edit(string Id)
        {
            ViewBag.Type = "Edit";
            var model = await roleManager.FindByIdAsync(Id);
            return View(nameof(Add), new RoleViewModel
            {
                Id = model.Id,
                Name = model.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "数据异常");
                return View(vm);
            }
            var type = Request.Form["Type"];
            if (type == "Add")
            {
                var result = await roleManager.CreateAsync(new IdentityRole        //创建角色
                {
                    Name = vm.Name
                });
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                var model = await roleManager.FindByIdAsync(vm.Id);        //根据id查询角色
                if (model == null)
                {
                    ModelState.AddModelError(string.Empty, "角色不存在！");
                }
                model.Name = vm.Name;
                var result = await roleManager.UpdateAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(vm);
        }
    }
}
