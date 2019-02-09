using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BookStore.Presentation.Startup))]
namespace BookStore.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}