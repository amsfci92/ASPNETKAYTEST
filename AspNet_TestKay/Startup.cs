using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNet_TestKay.Startup))]
namespace AspNet_TestKay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
