using HardwareHelpDesk.MODELS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareHelpDesk.BLL.Repository.Abstracts
{
    public interface IRepoFaultLog
    {
        void AddLog(Fault model);
    }
}
