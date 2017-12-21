using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdventOfCodeWeb2017.Startup))]
namespace AdventOfCodeWeb2017
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
