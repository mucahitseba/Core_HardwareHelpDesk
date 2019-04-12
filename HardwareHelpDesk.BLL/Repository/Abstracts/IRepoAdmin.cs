using HardwareHelpDesk.MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHelpDesk.BLL.Repository.Abstracts
{
    public interface IRepoAdmin
    {
        Task SendCode(string Id);
        Task SendPassword(string Id);
        Task<UserResultViewModel> EditUser(FaultProfileViewModel model);
        void EditUserRoles(UserProfileViewModel model);
        Task GetDetail(Guid Id);

    }
}
