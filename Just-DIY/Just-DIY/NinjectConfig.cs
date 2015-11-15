namespace Just_DIY
{
    using IdentityHelpers;
    using Data;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Ninject;
    using System;
    using System.Reflection;
    using Data.Data;

    public static class NinjectConfig
    {
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        });

        private static void RegisterServices(KernelBase kernel)
        {
            kernel.Bind<IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>>().To<Just_DIYDbContext>();
            kernel.Bind<IJustDIYData>().To<JustDIYData>();
        }
    }
}