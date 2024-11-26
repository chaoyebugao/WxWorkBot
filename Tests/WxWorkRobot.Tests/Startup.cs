using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxWorkRobot.Options;

namespace WxWorkRobot.Tests
{
    public class Startup
    {
        /// <summary>
        /// 配置Host
        /// </summary>
        /// <param name="hostBuilder"></param>
        public void ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder
                .ConfigureHostConfiguration(builder =>
                {
                    //builder.AddEnvironmentVariables();
                })
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", false, true);
                });
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="context"></param>
        public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
        {
            //从配置文件加载配置进行依赖注入
            services.AddWxWorkBotService(context.Configuration);

            //直接指定参数
            //services.AddWxWorkBotService(
            //    webhookKey: "7b0a1288-1029-444e-9d50-22f1a9b17f47",
            //    sendingResponseLogLevel: Microsoft.Extensions.Logging.LogLevel.Information);

            //使用Option
            //services.AddWxWorkBotService(new WxWorkBotOptions()
            //{
            //    WebhookKey = "7b0a1288-1029-444e-9d50-22f1a9b17f47",
            //    SendingResponseLogLevel = Microsoft.Extensions.Logging.LogLevel.Information,
            //});
        }
    }
}
