using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareHelpDesk.MODELS.ViewModels;
using HardwareHelpDesk.BLL.Repository.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HardwareHelpDesk.MODELS.IdentityEntities;
using Microsoft.AspNetCore.Authorization;

namespace Kuzey.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepoIdentity _userRoleRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IRepoIdentity userRoleRepo, IHttpContextAccessor httpContextAccessor, SignInManager<AppUser> signInManager)
        {
            _userRoleRepo = userRoleRepo;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin") && _signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Admin");
            if (_httpContextAccessor.HttpContext.User.IsInRole("Operator") && _signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Operator");
            if (_httpContextAccessor.HttpContext.User.IsInRole("Technician") && _signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Technician");
            if (_httpContextAccessor.HttpContext.User.IsInRole("Customer") && _signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Customer");
                
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _userRoleRepo.LoginUser(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Account");
            }

            ModelState.AddModelError(String.Empty, "Kullanıcı adı veya şifre hatalı");
            return View(model);

        }


        public async Task<IActionResult> Logout()
        {
            await _userRoleRepo.Logout();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult UserProfile()
        {
            return View();
        }
    }
}