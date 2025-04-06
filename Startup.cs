using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CareerClimbers.Startup))]
namespace CareerClimbers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
