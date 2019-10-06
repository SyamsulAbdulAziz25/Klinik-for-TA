using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(K_System.Startup))]
namespace K_System
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
