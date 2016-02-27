using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtmUi.Startup))]
namespace AtmUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
