using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ecomerce.Startup))]
namespace ecomerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
