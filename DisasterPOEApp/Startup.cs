using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DisasterPOEApp.Startup))]
namespace DisasterPOEApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
