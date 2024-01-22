using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkRobot
{
    public static class ClientConfigurationExtensions
    {
        /// <summary>
        /// 配置URL（如果已有默认配置则会覆盖默认配置）
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="url">webhook地址</param>
        /// <returns></returns>
        public static WxWorkBotClient SetUrl(this WxWorkBotClient client, string url)
        {
            client.SetUrl(url);

            return client;
        }

        /// <summary>
        /// 根据Key配置URL（如果已有默认配置则会覆盖默认配置）
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="key">Webhook key</param>
        /// <returns></returns>
        public static WxWorkBotClient SetKey(this WxWorkBotClient client, string key)
        {
            client.SetKey(key);

            return client;
        }
    }
}
