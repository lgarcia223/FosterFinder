using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FosterFinder.WebMVC.Startup))]
namespace FosterFinder.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
