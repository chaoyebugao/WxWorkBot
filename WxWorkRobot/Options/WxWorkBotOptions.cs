using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkRobot
{
    public class WxWorkBotOptions
    {
        /// <summary>
        /// 初始化回调Key
        /// </summary>
        public string WebhookKey { get; set; }

        /// <summary>
        /// 回调URL模板，默认为<code>https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={0}</code>
        /// </summary>
        public string WebhookUrlTemplate { get; set; } = WxWorkBotClient.DEFAULT_WEBHOOK_URL_TEMP;

        /// <summary>
        /// 对于发送结果输出日志。默认为None，不输出
        /// </summary>
        public LogLevel SendingResponseLogLevel { get; set; } = LogLevel.None;
    }
}
