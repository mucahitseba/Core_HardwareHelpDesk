using HardwareHelpDesk.BLL.Repository.Abstracts;
using HardwareHelpDesk.DAL;
using HardwareHelpDesk.MODELS.Enums;
using HardwareHelpDesk.MODELS.IdentityEntities;
using HardwareHelpDesk.MODELS.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareHelpDesk.BLL.Repository
{
    public class RoleUserRepo : IRepoIdentity
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly MyContext DbContext;

        public RoleUserRepo(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, MyContext dbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            DbContext = dbContext;
        }



        public async Task<SignInResult> LoginUser(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
            return result;
        }

        public async Task<CreateUserResultViewModel> RegisterUser(RegisterViewModel model)
        {
            var user = new AppUser()
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            return new CreateUserResultViewModel()
            {
                IdentityResult = result,
                User = user
            };
        }

        public async Task CreateRoles()
        {
            var roles = Enum.GetNames(typeof(IdentityRoles));
            foreach (var role in roles)
            {
                if (!_roleManager.RoleExistsAsync(role).Result)
                {
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = role
                    });
                }
            }
        }

        public async Task AddRole(AppUser user)
        {
            if (_userManager.Users.Count() == 1)
            {
                var result = await _userManager.AddToRoleAsync(user, IdentityRoles.Admin.ToString());
            }
            else
            {
                var result = await _userManager.AddToRoleAsync(user, IdentityRoles.User.ToString());
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
