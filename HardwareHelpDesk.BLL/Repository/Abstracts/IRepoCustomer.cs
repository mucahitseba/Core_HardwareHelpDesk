using HardwareHelpDesk.MODELS.Entities;
using HardwareHelpDesk.MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHelpDesk.BLL.Repository.Abstracts
{
    public interface IRepoCustomer<T,TId> where T : class
    {
        T Create(FaultProfileViewModel model);
    }
}
