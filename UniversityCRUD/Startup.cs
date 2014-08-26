using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityCRUD.Startup))]
namespace UniversityCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
