using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoneraAdmin.Startup))]
namespace PoneraAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
