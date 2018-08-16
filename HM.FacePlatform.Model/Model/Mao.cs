namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using HM.Utils_;

    /// <summary>
    /// 人脸一体机
    /// </summary>
    public partial class Mao : BaseModel
    {
        public Mao()
        {
            SetDefaultToProperties(this);
            last_pull_date = DateTime.MinValue;
        }
        /// <summary>
        /// 人脸一体机编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string mao_no { get; set; }
        /// <summary>
        /// 人脸一体机名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string mao_name { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ip { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        [Required]
        [StringLength(5)]
        public string port { get; set; }
        /// <summary>
        /// 是否初始化
        /// </summary>
        public bool is_init { get; set; }
        /// <summary>
        /// 最后获取数据时间，同步数据用
        /// </summary>
        public DateTime? last_pull_date { get; set; }
        /// <summary>
        /// 人脸一体机与楼栋关系集合
        /// </summary>
        public virtual ICollection<MaoBuilding> MaoBuildings { get; set; }
        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public string GetIP()
        {
            if (Validate_.IsIPAddress(ip))
            {
                return ip;
            }
            else if (ip.IndexOf("http://") == 0 || ip.IndexOf("https://") == 0)
            {
                return new Uri(ip).Host;
            }
            else
            {
                return ip;
            }
        }
        /// <summary>
        /// 获取端口
        /// </summary>
        /// <returns></returns>
        public int GetPort()
        {
            return port.ToInt_() ?? 8080;
        }
    }
}
