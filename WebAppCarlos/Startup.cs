using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppCarlos.Startup))]
namespace WebAppCarlos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
