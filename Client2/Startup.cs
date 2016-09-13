using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Client2.Startup))]
namespace Client2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
