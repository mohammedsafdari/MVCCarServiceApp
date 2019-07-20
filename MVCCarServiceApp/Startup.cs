using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCarServiceApp.Startup))]
namespace MVCCarServiceApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
