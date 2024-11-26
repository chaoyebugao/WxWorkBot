using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WxWorkRobot.Options;

namespace WxWorkRobot
{
    /// <summary>
    /// 扩展 - 依赖注入
    /// </summary>
    public static class DependencyExtensions
    {
        /// <summary>
        /// 添加企业微信机器人服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="options">选项</param>
        /// <param name="serviceLifetime">注入的生命周期</param>
        /// <returns></returns>
        public static IServiceCollection AddWxWorkBotService(this IServiceCollection services, WxWorkBotOptions options,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            services.AddHttpClient<WxWorkBotClient>();

            var svcDescOptions = new ServiceDescriptor(typeof(WxWorkBotOptions), sp => options, serviceLifetime);
            services.Add(svcDescOptions);

            var clientType = typeof(WxWorkBotClient);
            var svcDescClient = new ServiceDescriptor(serviceType: clientType, implementationType: clientType, lifetime: serviceLifetime);
            services.Add(svcDescClient);

            return services;
        }

        /// <summary>
        /// 添加企业微信机器人服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="webhookKey">初始化Webhook Key</param>
        /// <param name="webhookUrlTemplate">回调URL模板，默认为<code>https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={0}</code></param>
        /// <param name="sendingResponseLogLevel">对于发送结果输出日志。默认为None，不输出</param>
        /// <param name="serviceLifetime">注入的生命周期</param>
        /// <returns></returns>
        public static IServiceCollection AddWxWorkBotService(this IServiceCollection services, string webhookKey,
            string webhookUrlTemplate = "https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={0}",
            LogLevel sendingResponseLogLevel = LogLevel.None,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            var options = new WxWorkBotOptions()
            {
                WebhookKey = webhookKey,
                WebhookUrlTemplate = webhookUrlTemplate,
                SendingResponseLogLevel = sendingResponseLogLevel,
            };

            return AddWxWorkBotService(services, options, serviceLifetime);
        }

        /// <summary>
        /// 添加企业微信机器人服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configuration">配置（默认）</param>
        /// <param name="serviceLifetime">注入的生命周期</param>
        /// <returns></returns>
        public static IServiceCollection AddWxWorkBotService(this IServiceCollection services, IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            var webhookKey = configuration["WxWorkRobot:WebhookKey"];
            if (string.IsNullOrWhiteSpace(webhookKey))
            {
                throw new ArgumentNullException("Configuration: 'WxWorkRobot:WebhookKey' is missing.");
            }

            var webhookUrlTemplate = configuration["WxWorkRobot:WebhookUrlTemplate"];
            if (string.IsNullOrEmpty(webhookUrlTemplate))
            {
                webhookUrlTemplate = WxWorkBotClient.DEFAULT_WEBHOOK_URL_TEMP;
            }

            var sendingResponseLogLevelStr = configuration["WxWorkRobot:SendingResponseLogLevel"];
            var sendingResponseLogLevel = LogLevel.None;
            if (!string.IsNullOrEmpty(sendingResponseLogLevelStr))
            {
                Enum.TryParse(configuration["WxWorkRobot:SendingResponseLogLevel"], out sendingResponseLogLevel);
            }
            
            var options = new WxWorkBotOptions()
            {
                WebhookKey = webhookKey,
                WebhookUrlTemplate = webhookUrlTemplate,
                SendingResponseLogLevel = sendingResponseLogLevel,
            };

            return AddWxWorkBotService(services, options, serviceLifetime);
        }

    }

    
}
