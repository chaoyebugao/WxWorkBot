using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WxWorkRobot.MsDependency
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
        /// <param name="webhookKey">默认Webhook Key</param>
        /// <param name="serviceLifetime">注入的生命周期</param>
        /// <returns></returns>
        public static IServiceCollection AddWxWorkBotService(this IServiceCollection services, string webhookKey, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(WxWorkBotClient), sp => WxWorkBotClient.WithKey(webhookKey), serviceLifetime);
            services.Add(serviceDescriptor);

            return services;
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

            return AddWxWorkBotService(services, webhookKey, serviceLifetime);
        }

    }
}
