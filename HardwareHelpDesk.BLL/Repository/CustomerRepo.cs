using HardwareHelpDesk.BLL.Repository.Abstracts;
using HardwareHelpDesk.DAL;
using HardwareHelpDesk.MODELS.Enums;
using HardwareHelpDesk.MODELS.ViewModels;
using HardwareHelpDesk.MODELS.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using HardwareHelpDesk.BLL.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace HardwareHelpDesk.BLL.Repository
{
    public class CustomerRepo : RepoBase<Fault,Guid>, IRepoCustomer<Fault, Guid>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MyContext _DbContext;
        private readonly IRepoPhoto<Photo, int> _repoPhoto;

        public CustomerRepo(IHttpContextAccessor httpContextAccessor, MyContext DbContext, IRepoPhoto<Photo, int> repoPhoto) : base(DbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _DbContext = DbContext;
            _repoPhoto = repoPhoto;
        }

        public Fault Create(FaultViewModel model)
        {
            var MusteriId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            var data = new Fault
            {
                CustomerId = MusteriId,
                FaultPath = model.FaultPath,
                InvoicePath = model.InvoicePath,
                Adress = model.Adress,
                FaultDescription = model.FaultDescription,
                AssignedOperator = false,
                FaultState = FaultStates.Uncompleted,
                FaultID = model.FaultID,
            };

            Insert(data);
            _repoPhoto.AddPhotos(model);


            var Log = new FaultLog
            {
                TechnicianId = data.TechnicianId,
                CustomerId = data.CustomerId,
                Operation = "Arıza kaydı oluşturuldu",
                FaultId = data.FaultID,
                OperationDescription = data.FaultDescription
            };

            return data;
          
        }
    }
}
