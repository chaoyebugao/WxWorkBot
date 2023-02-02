using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxWorkRobot.Models;
using Flurl.Http;

namespace WxWorkRobot
{
    /// <summary>
    /// 企业微信机器人客户端
    /// </summary>
    public class WxWorkBotClient
    {
        private readonly string webhookUrl;

        private WxWorkBotClient(string webhookUrl)
        {
            this.webhookUrl = webhookUrl;
        }

        /// <summary>
        /// 根据Webhook地址获得实例
        /// </summary>
        /// <param name="webhookUrl"></param>
        /// <returns></returns>
        public static WxWorkBotClient WithUrl(string webhookUrl)
        {
            return new WxWorkBotClient(webhookUrl);
        }

        /// <summary>
        /// 根据回调Key获得实例
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static WxWorkBotClient WithKey(string key)
        {
            var webhookUrl = $"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={key}";
            return WithUrl(webhookUrl);
        }

        /// <summary>
        /// 发送纯文本
        /// </summary>
        /// <param name="text">纯文本</param>
        /// <returns></returns>
        public Task SendText(string text)
        {
            return webhookUrl.PostJsonAsync(new SendMsgDto()
            {
                msgtype = "text",
                text = new TextMessage()
                {
                    content = text,
                },
            });
        }

        /// <summary>
        /// 发送Markdown格式内容
        /// </summary>
        /// <param name="content">Markdown内容</param>
        /// <returns></returns>
        public Task SendMarkdown(string content)
        {
            return webhookUrl.PostJsonAsync(new SendMsgDto()
            {
                msgtype = "markdown",
                markdown = new MarkdownMessage()
                {
                     content = content,
                },
            });
        }

    }
}
