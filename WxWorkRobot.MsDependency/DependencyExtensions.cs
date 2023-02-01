using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <param name="serviceLifetime"></param>
        /// <returns></returns>
        public static IServiceCollection AddWxWorkBotService(this IServiceCollection services, string key, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            var serviceDescriptor = new ServiceDescriptor(typeof(WxWorkBotClient), sp => WxWorkBotClient.WithKey(key), serviceLifetime);
            services.Add(serviceDescriptor);

            return services;
        }

    }
}
