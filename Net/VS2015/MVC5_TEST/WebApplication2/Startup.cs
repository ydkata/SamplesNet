using Microsoft.Owin;
using Owin;
using System.Diagnostics;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        public void ConfigureServices(ServiceCollection services)
        {
            Debug.WriteLine("Log# Call ConfigureServices");
            // ISmileServiceをDIサービスコンテナに登録
           // services.AddTransient<ISmileService, SmileService>();

            // Add framework services.
            //services.AddMvc();
        }

    }
}
