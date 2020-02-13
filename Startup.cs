using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InstrumentStoreMVC.Startup))]
namespace InstrumentStoreMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
