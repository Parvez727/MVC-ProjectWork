using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_ProjectWork.Startup))]
namespace MVC_ProjectWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
