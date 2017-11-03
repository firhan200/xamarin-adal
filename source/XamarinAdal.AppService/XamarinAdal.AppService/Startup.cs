using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(XamarinAdal.AppService.Startup))]

namespace XamarinAdal.AppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}