using HardwareHelpDesk.MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareHelpDesk.BLL.Repository.Abstracts
{
    public interface IRepoPhoto<T, TId> where T : class
    {
        void AddPhotos(FaultViewModel model);
    }
}
