using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(juvoService.Startup))]

namespace juvoService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}