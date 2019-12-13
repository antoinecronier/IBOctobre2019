using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetModule11Security.Startup))]
namespace AspNetModule11Security
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
