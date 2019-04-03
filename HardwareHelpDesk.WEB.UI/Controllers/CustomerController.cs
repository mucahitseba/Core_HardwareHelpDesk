using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareHelpDesk.BLL.Repository.Abstracts;
using HardwareHelpDesk.MODELS.Entities;
using HardwareHelpDesk.MODELS.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HardwareHelpDesk.WEB.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepoCustomer<Fault,Guid> repoCustomer;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFault(FaultViewModel model)
        {
            return View();
        }
    }
}