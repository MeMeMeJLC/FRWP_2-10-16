using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FRWP.Startup))]
namespace FRWP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
