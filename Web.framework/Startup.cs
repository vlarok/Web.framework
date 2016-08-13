using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.framework.Startup))]
namespace Web.framework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
