using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PROJECT_FINAL.Startup))]
namespace PROJECT_FINAL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
