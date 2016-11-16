using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(example1.Startup))]
namespace example1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
