using System.Web.Http;

using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(Just_DIY.Startup))]

namespace Just_DIY
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            DatabaseConfig.Initialize();
            MappingConfig.Initialize();
            app.UseNinjectMiddleware(() => NinjectConfig.CreateKernel.Value);
            app.UseNinjectWebApi(config);
        }
    }
}
