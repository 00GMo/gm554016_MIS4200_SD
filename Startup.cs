using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gm554016.Startup))]
namespace gm554016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
