using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssessmentTask2.Startup))]
namespace AssessmentTask2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
