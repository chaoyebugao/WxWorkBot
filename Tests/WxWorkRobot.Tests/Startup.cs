using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxWorkRobot.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddWxWorkBotService(
            //    webhookKey: "7b0a1288-1029-444e-9d50-22f1a9b17f47",
            //    sendingResponseLogLevel: Microsoft.Extensions.Logging.LogLevel.Information);

            services.AddWxWorkBotService(new WxWorkBotOptions()
            {
                WebhookKey = "7b0a1288-1029-444e-9d50-22f1a9b17f47",
                SendingResponseLogLevel = Microsoft.Extensions.Logging.LogLevel.Information,
            });
        }
    }
}
