namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// CRM¥��
    /// </summary>
    public partial class c_building
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// ¥������
        /// </summary>
        [StringLength(50)]
        public string building_code { get; set; }
        /// <summary>
        /// ¥������
        /// </summary>
        [StringLength(100)]
        public string building_name { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [StringLength(50)]
        public string project_code { get; set; }
        ///// <summary>
        ///// ������Դ
        ///// </summary>
        //public string data_from { get; set; }
    }
}
