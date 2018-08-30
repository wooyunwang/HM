namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// ����һ���ʧ������
    /// </summary>
    public partial class MaoFailedJob : BaseModel
    {
        public MaoFailedJob()
        {
            SetDefaultToProperties(this);

            create_date = DateTime.Now;
            last_retry_date = DateTime.MinValue;
        }
        /// <summary>
        /// ע��Id�����û�Id  f_register.id
        /// </summary>
        public int register_or_user_id { get; set; }
        /// <summary>
        /// ����һ������ f_mao.id
        /// </summary>
        public int mao_id { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public JobType job_type { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime create_date { get; set; }
        /// <summary>
        /// ���Դ���
        /// </summary>
        public int retry_time { get; set; }
        /// <summary>
        /// �������ʱ��
        /// </summary>
        public DateTime last_retry_date { get; set; }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public IsDelType is_del { get; set; }
        /// <summary>
        /// ʧ��Ե��
        /// </summary>
        [MaxLength(1024)]
        public string failed_message { get; set; }
        /// <summary>
        /// ���Խ����Ϣ
        /// </summary>
        [MaxLength(1024)]
        public string retry_message { get; set; }
    }
}
