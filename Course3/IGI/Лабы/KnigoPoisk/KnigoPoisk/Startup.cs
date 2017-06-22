using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnigoPoisk.Startup))]
namespace KnigoPoisk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
