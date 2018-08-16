namespace HM.FacePlatform.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using HM.Utils_;

    /// <summary>
    /// ����һ���
    /// </summary>
    public partial class Mao : BaseModel
    {
        public Mao()
        {
            SetDefaultToProperties(this);
            last_pull_date = DateTime.MinValue;
        }
        /// <summary>
        /// ����һ�������
        /// </summary>
        [Required]
        [StringLength(50)]
        public string mao_no { get; set; }
        /// <summary>
        /// ����һ�������
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
        /// �˿�
        /// </summary>
        [Required]
        [StringLength(5)]
        public string port { get; set; }
        /// <summary>
        /// �Ƿ��ʼ��
        /// </summary>
        public bool is_init { get; set; }
        /// <summary>
        /// ����ȡ����ʱ�䣬ͬ��������
        /// </summary>
        public DateTime? last_pull_date { get; set; }
        /// <summary>
        /// ����һ�����¥����ϵ����
        /// </summary>
        public virtual ICollection<MaoBuilding> MaoBuildings { get; set; }
        /// <summary>
        /// ��ȡIP
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
        /// ��ȡ�˿�
        /// </summary>
        /// <returns></returns>
        public int GetPort()
        {
            return port.ToInt_() ?? 8080;
        }
    }
}
