namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// CRM����
    /// </summary>
    public partial class c_house
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// ���ݱ���
        /// </summary>
        [StringLength(50)]
        public string house_code { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [StringLength(100)]
        public string house_name { get; set; }
        /// <summary>
        /// ��Ԫ
        /// </summary>
        [StringLength(20)]
        public string unit { get; set; }
        /// <summary>
        /// ¥��
        /// </summary>
        [StringLength(20)]
        public string floor { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [StringLength(20)]
        public string roomnumber { get; set; }
        /// <summary>
        /// ¥������
        /// </summary>
        [StringLength(50)]
        public string building_code { get; set; }
        ///// <summary>
        ///// ������Դ
        ///// </summary>
        //public string data_from { get; set; }
    }
}
