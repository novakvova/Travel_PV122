
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelApi.Data.Entity;
using TravelApi.Data.Entity.Identity;

namespace TravelApi.Data
{
    public class AppEFContext : IdentityDbContext<UserEntity, RoleEntity, int,
         IdentityUserClaim<int>, UserRoleEntity, IdentityUserLogin<int>,
         IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppEFContext(DbContextOptions<AppEFContext> options)
            : base(options)
        {

        }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<VacationEntity> Vacation { get; set; }
        public DbSet<VacationImagesEntity> VacationImages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRoleEntity>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(r => r.RoleId)
                    .IsRequired();

                ur.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(u => u.UserId)
                    .IsRequired();
            });
        }
    }
}

