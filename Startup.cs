using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Planny.Startup))]
namespace Planny
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
