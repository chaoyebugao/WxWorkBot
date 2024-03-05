using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxWorkRobot.Models;
using RestSharp;
using static System.Net.Mime.MediaTypeNames;

namespace WxWorkRobot
{
    /// <summary>
    /// 企业微信机器人客户端
    /// </summary>
    public class WxWorkBotClient
    {
        private string webhookUrl;

        private WxWorkBotClient(string webhookUrl)
        {
            this.webhookUrl = webhookUrl;
        }

        /// <summary>
        /// 根据Webhook地址获得实例
        /// </summary>
        /// <param name="webhookUrl">webhook地址</param>
        /// <returns></returns>
        public static WxWorkBotClient WithUrl(string webhookUrl)
        {
            return new WxWorkBotClient(webhookUrl);
        }

        /// <summary>
        /// 根据回调Key获得实例
        /// </summary>
        /// <param name="key">webhook key</param>
        /// <returns></returns>
        public static WxWorkBotClient WithKey(string key)
        {
            var webhookUrl = $"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={key}";
            return WithUrl(webhookUrl);
        }

        /// <summary>
        /// 设置发送URL
        /// </summary>
        /// <param name="url">webhook地址</param>
        internal void SetUrl(string url)
        {
            webhookUrl = url;
        }

        /// <summary>
        /// 从Key设置发送URL
        /// </summary>
        /// <param name="key">webhook key</param>
        internal void SetKey(string key)
        {
            webhookUrl = $"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={key}";
        }

        /// <summary>
        /// 发送纯文本
        /// </summary>
        /// <param name="text">纯文本</param>
        /// <returns></returns>
        public Task SendText(string text)
        {
            var client = new RestClient(webhookUrl);
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(new SendMsgDto()
            {
                msgtype = "text",
                text = new TextMessage()
                {
                    content = text,
                },
            });

            return client.PostAsync(request);
        }

        /// <summary>
        /// 发送Markdown格式内容
        /// </summary>
        /// <param name="content">Markdown内容</param>
        /// <returns></returns>
        public Task SendMarkdown(string content)
        {
            var client = new RestClient(webhookUrl);
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(new SendMsgDto()
            {
                msgtype = "markdown",
                markdown = new MarkdownMessage()
                {
                    content = content,
                },
            });

            return client.PostAsync(request);
        }

    }
}
