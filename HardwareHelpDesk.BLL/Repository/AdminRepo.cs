using HardwareHelpDesk.BLL.Repository.Abstracts;
using HardwareHelpDesk.DAL;
using HardwareHelpDesk.MODELS.Entities;
using HardwareHelpDesk.MODELS.IdentityEntities;
using HardwareHelpDesk.MODELS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHelpDesk.BLL.Repository
{
    public class AdminRepo : IRepoAdmin
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MyContext _DbContext;
        private readonly IRepoPhoto<Photo, int> _repoPhoto;

        public AdminRepo(UserManager<AppUser> userManager, MyContext DbContext, IRepoPhoto<Photo, int> repoPhoto)
        {
            _userManager = userManager;
            _DbContext = DbContext;
            _repoPhoto = repoPhoto;
        }

        public async Task<UserResultViewModel> EditUser(FaultProfileViewModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.UserProfileViewModel.Id);

                user.Name = model.UserProfileViewModel.Name;
                user.Surname = model.UserProfileViewModel.Surname;
                user.PhoneNumber = model.UserProfileViewModel.PhoneNumber;
                user.Email = model.UserProfileViewModel.Email;

                _repoPhoto.AddPhotos(model);
                var result = await _userManager.UpdateAsync(user);
                return new UserResultViewModel()
                {
                    IdentityResult = result,
                    User = user
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditUserRoles(UserProfileViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task GetDetail(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task SendCode(string Id)
        {
            throw new NotImplementedException();
        }

        public Task SendPassword(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
