using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxWorkRobot.Models
{
    /// <summary>
    /// Markdown消息
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MarkdownMessage
    {
        /// <summary>
        /// 文本内容，最长不超过2048个字节，必须是utf8编码
        /// </summary>
        public string content { get; set; }
    }
}
