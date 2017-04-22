using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArEnMVCTemplate.Startup))]
namespace ArEnMVCTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
