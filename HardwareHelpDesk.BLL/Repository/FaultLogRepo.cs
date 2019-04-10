using HardwareHelpDesk.BLL.Repository.Abstracts;
using HardwareHelpDesk.DAL;
using HardwareHelpDesk.MODELS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareHelpDesk.BLL.Repository
{
    public class FaultLogRepo : RepoBase<FaultLog, int>,IRepoFaultLog
    {
        public FaultLogRepo(MyContext dbContext) : base(dbContext)
        {
        }

        public void AddLog(Fault data)
        {
            var Log = new FaultLog
            {
                TechnicianId = data.TechnicianId,
                CustomerId = data.CustomerId,
                Operation = "Arıza kaydı oluşturuldu",
                FaultId = data.FaultID,
                OperationDescription = data.FaultDescription
            };

            Insert(Log);
        }
    }
}
