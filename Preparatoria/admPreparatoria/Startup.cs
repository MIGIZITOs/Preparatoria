using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admPreparatoria.Startup))]
namespace admPreparatoria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
