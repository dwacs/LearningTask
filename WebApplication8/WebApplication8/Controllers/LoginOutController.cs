using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class LoginOutController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public LoginOutController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "登录异常！");
                return View();
            }
            var user = await userManager.FindByNameAsync(vm.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "用户不存在！");
                return View();
            }
            // 后面的两个参数，一个是是否应用到浏览器Cookie，一个是登录失败是否锁定账户。
            var result = await signInManager.PasswordSignInAsync(user, vm.PassWord, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "账户或密码不正确");
            return View(vm);
        }

        //登出，并且跳转到登录页面
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
