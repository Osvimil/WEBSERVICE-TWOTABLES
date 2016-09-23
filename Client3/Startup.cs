using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Client3.Startup))]
namespace Client3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
