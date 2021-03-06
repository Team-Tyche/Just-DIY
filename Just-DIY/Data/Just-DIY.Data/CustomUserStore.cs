﻿namespace Just_DIY.Data
{
    using Just_DIY.IdentityHelpers;
    using Just_DIY.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class CustomUserStore : UserStore<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(Just_DIYDbContext context)
            : base(context)
        {
        }
    }
}
