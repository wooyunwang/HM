using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{
    public class IP_Net_Result
    {
        public IP_Net_Result(byte catCode, string content, DateTime pingTime)
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                if (content.Contains("ping", StringComparison.OrdinalIgnoreCase) || content.Contains("telnet", StringComparison.OrdinalIgnoreCase))
                {
                    OK = content.IndexOf("恢复") > 0 || (content.IndexOf("ping不通") < 0 && content.IndexOf("telnet不通") < 0);
                    IP = Utils.GetIP(content);
                    PingKey = Utils.GetPingKey(content);
                }
            }
            CatCode = catCode;
            Content = content;
            PingTime = pingTime;
        }
        public byte CatCode { get; set; }

        public string PingKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool OK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PingTime { get; set; }

    }
}
