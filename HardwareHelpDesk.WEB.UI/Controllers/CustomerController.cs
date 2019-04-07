﻿using System;
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
        private readonly IRepoCustomer<Fault,Guid> _repoCustomer;

        public CustomerController(IRepoCustomer<Fault, Guid> repoCustomer)
        {
            _repoCustomer = repoCustomer;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFault(FaultViewModel model)
        {
            var sonuc = _repoCustomer.Create(model);
            TempData["Message"] = $"{sonuc.FaultID} no'lu kayıt başarıyla eklenmiştir";
            return RedirectToAction("Index");
        }
    }
}