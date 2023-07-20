using Microsoft.AspNetCore.Identity;

namespace TravelApi.Data.Entity.Identity
{
    public class RoleEntity:IdentityRole<int>
    {
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
