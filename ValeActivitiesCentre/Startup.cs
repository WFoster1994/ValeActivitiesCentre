using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ValeActivitiesCentre.Startup))]
namespace ValeActivitiesCentre
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
