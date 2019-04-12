using HardwareHelpDesk.MODELS.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareHelpDesk.MODELS.ViewModels
{
    public class UserResultViewModel
    {
        public IdentityResult IdentityResult { get; set; }
        public AppUser User { get; set; }
    }
}
