using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelApi.Constant;
using TravelApi.Data.Entity;
using TravelApi.Data.Entity.Identity;

namespace TravelApi.Data
{
    public static class SeederDB
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetRequiredService<AppEFContext>();
                var userManager = service.GetRequiredService<UserManager<UserEntity>>();
                var roleManager = service.GetRequiredService<RoleManager<RoleEntity>>();
                context.Database.Migrate();

                if (!context.Categories.Any())
                {
                    CategoryEntity categoryEntity = new CategoryEntity()
                    {
                        Name = "DefaultCategory",
                        Image = "1.jpg",
                        Priority = 1,
                        DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                        Description = "DefaultDescription"
                    };
                    context.Add(categoryEntity);
                    context.SaveChanges();
                }
                if (!context.Roles.Any())
                {
                    foreach (string name in Roles.All)
                    {
                        var role = new RoleEntity
                        {
                            Name = name
                        };
                        var result =roleManager.CreateAsync(role).Result;
                    }
                }
                if (!context.Users.Any())
                {
                    var user = new UserEntity()
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@gmail.com",
                        UserName = "admin@gmail.com",
                        Image="3.jpg"
                    };
                    var result = userManager.CreateAsync(user, "123456").Result;
                    if (result.Succeeded)
                    {
                        result = userManager.AddToRoleAsync(user, Roles.Admin).Result;
                    }
                }

            }
        }
    }
}

