namespace Just_DIY.IdentityHelpers
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole()
        {
        }

        public CustomRole(string name)
        {
            this.Name = name;
        }
    }
}
