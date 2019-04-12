using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareHelpDesk.BLL.Repository.Abstracts;
using HardwareHelpDesk.MODELS.IdentityEntities;
using HardwareHelpDesk.MODELS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HardwareHelpDesk.WEB.UI.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private readonly IRepoBase<AppUser,string> _repoIdentity;

        public AdminController(IRepoBase<AppUser, string> repoIdentity)
        {
            _repoIdentity = repoIdentity;
        }

        public IActionResult Index()
        {
            return View(_repoIdentity.GetAll());
        }

        [HttpGet]
        public IActionResult EditUser(string Id)
        {
            try
            {
                var user = _repoIdentity.GetById(Id);
                if (user == null)
                    return RedirectToAction("Index");



                var model = new UserProfileViewModel
                {
                    AvatarPath = user.AvatarPath,
                    Name = user.Name,
                    Email = user.Email,
                    Surname = user.Surname,
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName
                };

                return View(model);

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}