using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceSchedulerApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ServiceSchedulerApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        private static ApplicationDbContext _Context;

        public static ApplicationDbContext Instance
        {
            get
            {
                if (_Context == null)
                {
                    _Context = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>() { });
                    SeedData(_Context);
                }

                return _Context;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ServiceSchedulerApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ServiceOperator> ServiceOperators { get; set; }

        public DbSet<ScheduledAppointments> ScheduledAppointments { get; set; }

        private static void SeedData(ApplicationDbContext context)
        {
            if(context.ServiceOperators.Count() == 0)
            {
                context.ServiceOperators.Add(new ServiceOperator() { Name = "Service Operator 1", City = "Pune", Address = "Baner", GeoLatitude = (float)8.1, GeoLongitude = (float)19.1 });
                context.ServiceOperators.Add(new ServiceOperator() { Name = "Service Operator 2", City = "Mumbai", Address = "Andheri", GeoLatitude = (float)9.3, GeoLongitude = (float)21.1 });
                context.ServiceOperators.Add(new ServiceOperator() { Name = "Service Operator 3", City = "Nashik", Address = "Panvel", GeoLatitude = (float)7.9, GeoLongitude = (float)22.1 });
                context.SaveChanges();
            }
        }

    }
}
