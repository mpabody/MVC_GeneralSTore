using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_GeneralStore.Startup))]
namespace MVC_GeneralStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
