using HardwareHelpDesk.MODELS.IdentityEntities;
using HardwareHelpDesk.MODELS.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHelpDesk.BLL.Repository.Abstracts
{
    public interface IRepoIdentity
    {
        Task<CreateUserResultViewModel> RegisterUser(RegisterViewModel model);
        Task<SignInResult> LoginUser(LoginViewModel model);
        Task Logout();
        Task CreateRoles();
        Task AddRole(AppUser user);
    }
}
