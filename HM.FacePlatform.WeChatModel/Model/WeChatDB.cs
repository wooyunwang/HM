namespace HM.FacePlatform.WeChatModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WeChatDB : DbContext
    {
        public WeChatDB()
            : base("name=WeChatDB")
        {
        }
        /// <summary>
        /// 楼栋
        /// </summary>
        public virtual DbSet<c_building> c_building { get; set; }
        /// <summary>
        /// CRM数据
        /// </summary>
        public virtual DbSet<c_crm_data> c_crm_data { get; set; }
        /// <summary>
        /// 房屋
        /// </summary>
        public virtual DbSet<c_house> c_house { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public virtual DbSet<c_project> c_project { get; set; }
        /// <summary>
        /// 小区用户
        /// </summary>
        public virtual DbSet<c_user> c_user { get; set; }
        /// <summary>
        /// 小区用户与房屋关系
        /// </summary>
        public virtual DbSet<c_user_house> c_user_house { get; set; }
        /// <summary>
        /// 微信账号
        /// </summary>
        public virtual DbSet<w_account> w_account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<w_card> w_card { get; set; }
        /// <summary>
        /// 进出历史
        /// </summary>
        public virtual DbSet<w_entry_history> w_entry_history { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<w_face_mob_sms> w_face_mob_sms { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<w_face_sysparamter> w_face_sysparamter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<w_register> w_register { get; set; }
        /// <summary>
        /// 通行记录
        /// </summary>
        public virtual DbSet<w_register_bak> w_register_bak { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<w_sms> w_sms { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<w_user> w_user { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<w_user_fail> w_user_fail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<v_register> v_register { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<c_building>()
                .Property(e => e.building_code)
                .IsUnicode(false);

            modelBuilder.Entity<c_building>()
                .Property(e => e.building_name)
                .IsUnicode(false);

            modelBuilder.Entity<c_building>()
                .Property(e => e.project_code)
                .IsUnicode(false);

            modelBuilder.Entity<c_crm_data>()
                .Property(e => e.project_code)
                .IsUnicode(false);

            modelBuilder.Entity<c_crm_data>()
                .Property(e => e.building_code)
                .IsUnicode(false);

            modelBuilder.Entity<c_crm_data>()
                .Property(e => e.house_code)
                .IsUnicode(false);

            modelBuilder.Entity<c_crm_data>()
                .Property(e => e.customer_code)
                .IsUnicode(false);

            modelBuilder.Entity<c_crm_data>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<c_crm_data>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<c_crm_data>()
                .Property(e => e.id_num)
                .IsUnicode(false);

            modelBuilder.Entity<c_crm_data>()
                .Property(e => e.relation)
                .IsUnicode(false);

            modelBuilder.Entity<c_house>()
                .Property(e => e.house_code)
                .IsUnicode(false);

            modelBuilder.Entity<c_house>()
                .Property(e => e.house_name)
                .IsUnicode(false);

            modelBuilder.Entity<c_house>()
                .Property(e => e.unit)
                .IsUnicode(false);

            modelBuilder.Entity<c_house>()
                .Property(e => e.floor)
                .IsUnicode(false);

            modelBuilder.Entity<c_house>()
                .Property(e => e.roomnumber)
                .IsUnicode(false);

            modelBuilder.Entity<c_house>()
                .Property(e => e.building_code)
                .IsUnicode(false);

            modelBuilder.Entity<c_project>()
                .Property(e => e.project_code)
                .IsUnicode(false);

            modelBuilder.Entity<c_project>()
                .Property(e => e.project_name)
                .IsUnicode(false);

            modelBuilder.Entity<c_project>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<c_user>()
                .Property(e => e.user_uid)
                .IsUnicode(false);

            modelBuilder.Entity<c_user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<c_user>()
                .Property(e => e.id_num)
                .IsUnicode(false);

            modelBuilder.Entity<c_user>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<c_user>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<c_user_house>()
                .Property(e => e.house_code)
                .IsUnicode(false);

            modelBuilder.Entity<c_user_house>()
                .Property(e => e.user_uid)
                .IsUnicode(false);

            modelBuilder.Entity<c_user_house>()
                .Property(e => e.relation)
                .IsUnicode(false);

            modelBuilder.Entity<c_user_house>()
                .Property(e => e.project_code)
                .IsUnicode(false);

            modelBuilder.Entity<w_account>()
                .Property(e => e.account)
                .IsUnicode(false);

            modelBuilder.Entity<w_account>()
                .Property(e => e.user_uid)
                .IsUnicode(false);

            modelBuilder.Entity<w_account>()
                .Property(e => e.wechat_uid)
                .IsUnicode(false);

            modelBuilder.Entity<w_card>()
                .Property(e => e.user_uid)
                .IsUnicode(false);

            modelBuilder.Entity<w_card>()
                .Property(e => e.card_no)
                .IsUnicode(false);

            modelBuilder.Entity<w_card>()
                .Property(e => e.project_code)
                .IsUnicode(false);

            modelBuilder.Entity<w_entry_history>()
                .Property(e => e.photo_path)
                .IsUnicode(false);

            modelBuilder.Entity<w_entry_history>()
                .Property(e => e.face_uid)
                .IsUnicode(false);

            modelBuilder.Entity<w_entry_history>()
                .Property(e => e.mao_no)
                .IsUnicode(false);

            modelBuilder.Entity<w_entry_history>()
                .Property(e => e.project_code)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_mob_sms>()
                .Property(e => e.sms_uid)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_mob_sms>()
                .Property(e => e.sms_code)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_mob_sms>()
                .Property(e => e.receive_num)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_mob_sms>()
                .Property(e => e.msg_id)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_mob_sms>()
                .Property(e => e.sendstate)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_mob_sms>()
                .Property(e => e.reason)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_mob_sms>()
                .Property(e => e.sms_content)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_sysparamter>()
                .Property(e => e.ParamterCode)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_sysparamter>()
                .Property(e => e.ParamterName)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_sysparamter>()
                .Property(e => e.ParamterValue)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_sysparamter>()
                .Property(e => e.CheckRegx)
                .IsUnicode(false);

            modelBuilder.Entity<w_face_sysparamter>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<w_register>()
                .Property(e => e.guid_value)
                .IsUnicode(false);

            modelBuilder.Entity<w_register>()
                .Property(e => e.face_uid)
                .IsUnicode(false);

            modelBuilder.Entity<w_register>()
                .Property(e => e.photo_path)
                .IsUnicode(false);

            modelBuilder.Entity<w_register>()
                .Property(e => e.check_note)
                .IsUnicode(false);

            modelBuilder.Entity<w_register>()
                .Property(e => e.people_id)
                .IsUnicode(false);

            modelBuilder.Entity<w_register>()
                .Property(e => e.project_code)
                .IsUnicode(false);

            modelBuilder.Entity<w_register_bak>()
                .Property(e => e.guid_value)
                .IsUnicode(false);

            modelBuilder.Entity<w_register_bak>()
                .Property(e => e.face_uid)
                .IsUnicode(false);

            modelBuilder.Entity<w_register_bak>()
                .Property(e => e.photo_path)
                .IsUnicode(false);

            modelBuilder.Entity<w_register_bak>()
                .Property(e => e.check_note)
                .IsUnicode(false);

            modelBuilder.Entity<w_register_bak>()
                .Property(e => e.people_id)
                .IsUnicode(false);

            modelBuilder.Entity<w_register_bak>()
                .Property(e => e.project_code)
                .IsUnicode(false);

            modelBuilder.Entity<w_sms>()
                .Property(e => e.sms_uid)
                .IsUnicode(false);

            modelBuilder.Entity<w_sms>()
                .Property(e => e.sms_code)
                .IsUnicode(false);

            modelBuilder.Entity<w_sms>()
                .Property(e => e.receive_num)
                .IsUnicode(false);

            modelBuilder.Entity<w_sms>()
                .Property(e => e.msg_id)
                .IsUnicode(false);

            modelBuilder.Entity<w_sms>()
                .Property(e => e.sendstate)
                .IsUnicode(false);

            modelBuilder.Entity<w_sms>()
                .Property(e => e.reason)
                .IsUnicode(false);

            modelBuilder.Entity<w_sms>()
                .Property(e => e.sms_content)
                .IsUnicode(false);

            modelBuilder.Entity<w_user>()
                .Property(e => e.user_uid)
                .IsUnicode(false);

            modelBuilder.Entity<w_user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<w_user>()
                .Property(e => e.user_type)
                .IsUnicode(false);

            modelBuilder.Entity<w_user>()
                .Property(e => e.id_num)
                .IsUnicode(false);

            modelBuilder.Entity<w_user>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<w_user>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<w_user>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<w_user_fail>()
                .Property(e => e.user_uid)
                .IsUnicode(false);

            modelBuilder.Entity<w_user_fail>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<w_user_fail>()
                .Property(e => e.id_num)
                .IsUnicode(false);

            modelBuilder.Entity<w_user_fail>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<w_user_fail>()
                .Property(e => e.fail_info)
                .IsUnicode(false);

            modelBuilder.Entity<w_user_fail>()
                .Property(e => e.project_code)
                .IsUnicode(false);

            modelBuilder.Entity<v_register>()
                .Property(e => e.guid_value)
                .IsUnicode(false);

            modelBuilder.Entity<v_register>()
                .Property(e => e.face_uid)
                .IsUnicode(false);

            modelBuilder.Entity<v_register>()
                .Property(e => e.photo_path)
                .IsUnicode(false);

            modelBuilder.Entity<v_register>()
                .Property(e => e.check_note)
                .IsUnicode(false);

            modelBuilder.Entity<v_register>()
                .Property(e => e.people_id)
                .IsUnicode(false);

            modelBuilder.Entity<v_register>()
                .Property(e => e.project_code)
                .IsUnicode(false);
        }
    }
}
