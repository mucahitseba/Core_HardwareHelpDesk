using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HardwareHelpDesk.MODELS.IdentityEntities;
using Microsoft.EntityFrameworkCore;

namespace HardwareHelpDesk.DAL
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
    }
}
