using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheaperMarket.Startup))]
namespace CheaperMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
