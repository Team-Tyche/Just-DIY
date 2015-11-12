using Just_DIY.IdentityHelpers;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Just_DIY.Data
{
    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(Just_DIYDbContext context)
            : base(context)
        {
        }
    }
}
