using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCarService.Startup))]
namespace MyCarService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
