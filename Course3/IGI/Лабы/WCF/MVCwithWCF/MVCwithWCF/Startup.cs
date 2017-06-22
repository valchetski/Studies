using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCwithWCF.Startup))]
namespace MVCwithWCF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
