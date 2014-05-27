using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Seeker.Web.Startup))]
namespace Seeker.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
