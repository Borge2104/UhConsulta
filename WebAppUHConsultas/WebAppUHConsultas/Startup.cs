using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppUHConsultas.Startup))]
namespace WebAppUHConsultas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
