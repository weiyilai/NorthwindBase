using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthwindBase.Web.Startup))]
namespace NorthwindBase.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
