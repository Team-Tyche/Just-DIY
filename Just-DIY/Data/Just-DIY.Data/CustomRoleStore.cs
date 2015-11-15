namespace Just_DIY.Data
{
    using Just_DIY.IdentityHelpers;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(Just_DIYDbContext context)
            : base(context)
        {
        }
    }
}
