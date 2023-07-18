
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Web.Providers.Entities;
using TravelApi.Data.Entity;

namespace TravelApi.Data
{
    public class AppEFContext :DbContext
    {
        public AppEFContext(DbContextOptions<AppEFContext> options)
            : base(options)
        {

        }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<VacationEntity> Products { get; set; }
        public DbSet<VacationImagesEntity> VacationImages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        

        }
    }
}
   
