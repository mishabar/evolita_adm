using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Evolita.Admin.Web.Startup))]
namespace Evolita.Admin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
