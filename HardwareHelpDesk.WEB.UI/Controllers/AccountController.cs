using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareHelpDesk.MODELS.ViewModels;
using HardwareHelpDesk.BLL.Repository.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kuzey.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepoIdentity _userRoleRepo;

        public AccountController(IRepoIdentity userRoleRepo)
        {
            _userRoleRepo = userRoleRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userRoleRepo.RegisterUser(model);
            if (result.IdentityResult.Succeeded)
            {
                await _userRoleRepo.CreateRoles();
                await _userRoleRepo.AddRole(result.User);

                return RedirectToAction(nameof(Login));
            }
            else
            {
                var errorMsg = "";
                foreach (var error in result.IdentityResult.Errors)
                {
                    errorMsg += error.Description;
                }

                ModelState.AddModelError(String.Empty, errorMsg);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _userRoleRepo.LoginUser(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(String.Empty, "Kullanıcı adı veya şifre hatalı");
            return View(model);

        }

        public async Task<IActionResult> Logout()
        {
            await _userRoleRepo.Logout();
            return RedirectToAction("Login", "Account");
        }
    }
}