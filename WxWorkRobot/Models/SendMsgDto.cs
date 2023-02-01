using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxWorkRobot.Models
{
    /// <summary>
    /// 综合消息体
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SendMsgDto
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public string msgtype { get; set; }


        /// <summary>
        /// markdown类型消息
        /// </summary>
        public MarkdownMessage markdown { get; set; }

        /// <summary>
        /// 文本类型消息
        /// </summary>
        public TextMessage text { get; set; }
    }
}
