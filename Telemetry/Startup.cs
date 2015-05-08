using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Telemetry.Startup))]
namespace Telemetry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
