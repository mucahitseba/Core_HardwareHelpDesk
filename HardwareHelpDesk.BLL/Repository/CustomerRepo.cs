﻿using HardwareHelpDesk.BLL.Repository.Abstracts;
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
        private readonly IRepoFaultLog _repoFaultLog;

        public CustomerRepo(IHttpContextAccessor httpContextAccessor, MyContext DbContext, IRepoPhoto<Photo, int> repoPhoto, IRepoFaultLog repoFaultLog):base(DbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _DbContext = DbContext;
            _repoPhoto = repoPhoto;
            _repoFaultLog = repoFaultLog;
        }

        public Fault Create(FaultProfileViewModel model)
        {
            var MusteriId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            var data = new Fault
            {
                CustomerId = MusteriId,
                FaultPath = model.FaultViewModel.FaultPath,
                InvoicePath = model.FaultViewModel.InvoicePath,
                Adress = model.FaultViewModel.Adress,
                FaultDescription = model.FaultViewModel.FaultDescription,
                AssignedOperator = false,
                FaultState = FaultStates.Uncompleted,
                FaultID = model.FaultViewModel.FaultID,
            };

            Insert(data);
            _repoPhoto.AddPhotos(model);
            _repoFaultLog.AddLog(data);

            return data;
          
        }
    }
}
