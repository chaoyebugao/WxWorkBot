using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WxWorkRobot.Models;

namespace WxWorkRobot
{
    /// <summary>
    /// 企业微信机器人客户端
    /// </summary>
    public sealed class WxWorkBotClient : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly WxWorkBotOptions options;
        private readonly ILogger<WxWorkBotClient> logger;

        public WxWorkBotClient(ILogger<WxWorkBotClient> logger,
            HttpClient httpClient,
            WxWorkBotOptions options)
        {
            this.logger = logger;
            this.httpClient = httpClient;
            this.options = options;

            SetKey(options.WebhookKey);
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose() => httpClient?.Dispose();

        /// <summary>
        /// 回调URL模板
        /// </summary>
        internal const string DEFAULT_WEBHOOK_URL_TEMP = "https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={0}";

        private string webhookUrl;

        /// <summary>
        /// 设置发送URL
        /// </summary>
        /// <param name="url">webhook地址</param>
        internal void SetUrl(string url)
        {
            webhookUrl = url;
            logger.LogTrace($"WxWorkBotClient-设置了回调URL: {url}");
        }

        /// <summary>
        /// 从Key设置发送URL
        /// </summary>
        /// <param name="key">webhook key</param>
        internal void SetKey(string key)
        {
            webhookUrl = string.Format(options.WebhookUrlTemplate, key);
            logger.LogTrace($"WxWorkBotClient-设置了回调Key: {key}");
        }

        /// <summary>
        /// 异步发送纯文本
        /// </summary>
        /// <param name="text">纯文本</param>
        /// <returns></returns>
        public async Task SendText(string text)
        {
            try
            {
                // 将数据对象序列化为JSON格式
                string jsonContent = JsonConvert.SerializeObject(new SendMsgDto()
                {
                    msgtype = "text",
                    text = new TextMessage()
                    {
                        content = text,
                    },
                });

                // 创建HttpContent对象
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // 发送POST请求
                var response = await httpClient.PostAsync(webhookUrl, content);

                // 确保请求成功
                response.EnsureSuccessStatusCode();

                // 读取响应内容
                var responseString = await response.Content.ReadAsStringAsync();
                if (options.SendingResponseLogLevel != LogLevel.None)
                {
                    logger.Log(options.SendingResponseLogLevel, $"WxWorkBotClient-发送纯文本响应: {responseString}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"WxWorkBotClient-发送纯文本异常");
            }

        }

        /// <summary>
        /// 异步发送Markdown格式内容
        /// </summary>
        /// <param name="md">Markdown内容</param>
        /// <returns></returns>
        public async Task SendMarkdown(string md)
        {
            try
            {
                // 将数据对象序列化为JSON格式
                string jsonContent = JsonConvert.SerializeObject(new SendMsgDto()
                {
                    msgtype = "markdown",
                    markdown = new MarkdownMessage()
                    {
                        content = md,
                    },
                });

                // 创建HttpContent对象
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // 发送POST请求
                var response = await httpClient.PostAsync(webhookUrl, content);

                // 确保请求成功
                response.EnsureSuccessStatusCode();

                // 读取响应内容
                var responseString = await response.Content.ReadAsStringAsync();
                if (options.SendingResponseLogLevel != LogLevel.None)
                {
                    logger.Log(options.SendingResponseLogLevel, $"WxWorkBotClient-发送Markdown响应: {responseString}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"WxWorkBotClient-发送Markdown异常");
            }
        }

    }
}
