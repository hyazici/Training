using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerManagementApp.Startup))]
namespace CustomerManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // ConfigureAuth(app);
        }
    }
}
