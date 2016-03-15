using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnglishWebsite.Startup))]
namespace EnglishWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
