using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HM.Socket_.Common
{
    /// <summary>
    /// 自定义报警类型
    /// </summary>
    public enum UserDefineType
    {
        Unknow = 0,
        IP = 1,
        GPIO = 2
    }
    /// <summary>
    /// 自定义告警
    /// </summary>
    public class GetUserDefineAbnormalSignalCMD
    {
        /// <summary>
        /// 例如: BlackCatId="01"
        /// </summary>
        public byte BlackCatId { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// 内容（报文多种多样）
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 自定义报警类型
        /// </summary>
        public UserDefineType UserDefineType
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Content))
                {
                    return UserDefineType.Unknow;
                }
                else if (Content.StartsWith("GPIO板｜"))
                {
                    return UserDefineType.GPIO;
                }
                else if (Content.Contains("ping", StringComparison.OrdinalIgnoreCase))
                {
                    return UserDefineType.IP;
                }
                else
                {
                    return UserDefineType.Unknow;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> To_GIOP_DicKey_Map()
        {
            if (UserDefineType == UserDefineType.GPIO)
            {
                string json = Content.Replace("GPIO板｜", "");
                try
                {
                    return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IP_Net_Result To_IP_Net_Result()
        {
            if (UserDefineType == UserDefineType.IP)
            {
                return new IP_Net_Result(BlackCatId, Content, Date ?? DateTime.Now);
            }
            else
            {
                return null;
            }
        }
    }
}
