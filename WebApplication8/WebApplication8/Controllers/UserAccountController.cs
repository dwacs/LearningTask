using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

public class UserAccountController : Controller
{
    // UserManager 类需要引用 Microsoft.AspNetCore.Identity;
    // 注意此类是一个泛型类型，需要传递我们扩展的用户类
    private readonly UserManager<ApplicationUser> userManager;

    public UserAccountController(UserManager<ApplicationUser> userManager)
    {
        this.userManager = userManager;
    }
    // async 异步，我不知道之前的Asp.Net 有没有，但.net core项目以后将常用async方法。写法如下
    public async Task<IActionResult> Index()
    {
        // 如果是async方法，必须有await请求。
        return View(await userManager.Users.ToListAsync());
    }

    public IActionResult Add()
    {
        ViewBag.Type = "Add";
        return View();
    }
    public async Task<IActionResult> Edit(string Id)
    {
        ViewBag.Type = "Edit";
        var model = await userManager.FindByIdAsync(Id);
        return View(nameof(Add), new AccountViewModel
        {
            Id = model.Id,
            UserName = model.UserName,
            Email = model.Email,
            NickName = model.NickName,
         //   Gender = model.Gender
        });
    }

    [HttpPost]
    public async Task<IActionResult> Add(AccountViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "数据异常");
            return View();
        }
        var type = Request.Form["Type"];
        if (type == "Add")
        {
            // UserManager 添加用户的方法，注意密码是做为第二个参数传递的。数据库中的表是没有PassWord字段，而是一个加密的字段PasswordHash
            var result = await userManager.CreateAsync(new ApplicationUser
            {
                UserName = vm.UserName,
                Email = vm.Email,
                NickName = vm.NickName,
              //  Gender = vm.Gender

            }, vm.Password);
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
            var model = await userManager.FindByIdAsync(vm.Id);
            if (model == null)
            {
                ModelState.AddModelError(string.Empty, "用户不存在！");
                return View(vm);
            }
            model.UserName = vm.UserName;
            model.Email = vm.Email;
            model.NickName = vm.NickName;
           // model.Gender = vm.Gender;
            var result = await userManager.UpdateAsync(model);
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
