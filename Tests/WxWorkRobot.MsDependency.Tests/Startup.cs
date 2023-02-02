using Microsoft.Extensions.DependencyInjection;

namespace WxWorkRobot.MsDependency.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWxWorkBotService("you-webhook-key-here");
            //services.AddWxWorkBotService("a693c72d-8c65-4462-81b0-20220970a3b6");
        }
    }
}
