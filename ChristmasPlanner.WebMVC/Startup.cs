using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChristmasPlanner.WebMVC.Startup))]
namespace ChristmasPlanner.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
