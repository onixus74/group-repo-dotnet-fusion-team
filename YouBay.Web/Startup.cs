using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YouBay.Web.Startup))]
namespace YouBay.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
