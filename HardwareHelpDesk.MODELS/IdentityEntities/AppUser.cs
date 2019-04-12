using HardwareHelpDesk.MODELS.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HardwareHelpDesk.MODELS.IdentityEntities
{
    public class AppUser : IdentityUser
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Surname { get; set; }

        public DateTime RegisteredDate { get; set; } = DateTime.Now;
        public string ActivationCode { get; set; }
        public string AvatarPath { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
