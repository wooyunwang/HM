namespace HM.FacePlatform.Model
{
    using HM.Enum_.FacePlatform;
    using System;

    /// <summary>
    /// ����ע��
    /// </summary>
    public partial class RegisterManageDto
    {
        /// <summary>
        /// f_Register��id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// С���û�Ψһ��ʶ
        /// </summary>
        public string user_uid { get; set; }
        /// <summary>
        /// ��������ID
        /// </summary>
        public string face_id { get; set; }
        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string photo_path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tc_path { get; set; }
        /// <summary>
        /// ע������
        /// </summary>
        public RegisterType register_type { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime change_time { get; set; }
        /// <summary>
        /// ���״̬
        /// </summary>
        public CheckType check_state { get; set; }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public IsDelType is_del { get; set; }
        /// <summary>
        /// �û�����
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// ��Ч��
        /// </summary>
        public DateTime end_time { get; set; }
        /// <summary>
        /// �ֻ�����
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// סַ(��������)
        /// </summary>
        public string house_name { get; set; }
        /// <summary>
        /// �û�����
        /// </summary>
        public UserType user_type { get; set; }
        /// <summary>
        /// С���û��뷿�ݵĹ�ϵ
        /// </summary>
        public string relation { get; set; }
    }
}
