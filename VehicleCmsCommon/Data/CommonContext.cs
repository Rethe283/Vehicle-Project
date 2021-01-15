using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleCmsCommon.Models;

namespace VehicleCmsCommon.Data
{
    public class CommonContext : DbContext
    {
        public CommonContext (DbContextOptions<CommonContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<VehicleDetail>().ToTable("VehicleDetail");
        }
    }
}
