using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HardwareHelpDesk.MODELS.IdentityEntities
{
    public class AppRole : IdentityRole
    {
        [StringLength(128)]
        public string Desc { get; set; }
    }
}
