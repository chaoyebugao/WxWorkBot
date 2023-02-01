using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxWorkRobot.Models
{
    /// <summary>
    /// 纯文本消息
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TextMessage
    {
        /// <summary>
        /// 文本内容，最长不超过2048个字节，必须是utf8编码
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// userid的列表，提醒群中的指定成员(@某个成员)，@all表示提醒所有人，如果开发者获取不到userid，可以使用mentioned_mobile_list
        /// </summary>
        public string[] mentioned_list { get; set; }

        /// <summary>
        /// 手机号列表，提醒手机号对应的群成员(@某个成员)，@all表示提醒所有人
        /// </summary>
        public string[] mentioned_mobile_list { get; set; }
    }
}
