using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HardwareHelpDesk.MODELS.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using HardwareHelpDesk.MODELS.Entities;

namespace HardwareHelpDesk.DAL
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DateTime InstanceDate { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            this.InstanceDate = DateTime.Now;
        }

        public virtual DbSet<Fault> Faults { get; set; }
        public virtual DbSet<FaultLog> FaultLogs { get; set; }
    }
}
