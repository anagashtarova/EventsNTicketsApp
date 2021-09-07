using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventsNTicketsApp.Startup))]
namespace EventsNTicketsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
