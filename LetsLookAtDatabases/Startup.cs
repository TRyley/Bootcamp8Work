using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LetsLookAtDatabases.Startup))]
namespace LetsLookAtDatabases
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
