using Microsoft.Extensions.DependencyInjection;

namespace WxWorkRobot.MsDependency.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWxWorkBotService("71610d83-e679-45a9-9e14-335f235307ee");
        }
    }
}
