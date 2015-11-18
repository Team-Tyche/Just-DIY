using Microsoft.Owin;

[assembly: OwinStartup(typeof(Just_DIY.Startup))]

namespace Just_DIY
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Clients;
    using Microsoft.Owin.Cors;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

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
