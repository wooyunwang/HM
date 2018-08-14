namespace HM.FacePlatform.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Text.RegularExpressions;
    using System.Data.Entity.Infrastructure.Pluralization;
    using System.Data.Entity.Infrastructure.DependencyResolution;

    public partial class FacePlatformDB : DbContext
    {
        public FacePlatformDB()
            : base("name=FacePlatformDB")
        {
        }

        /// <summary>
        /// 操作记录
        /// </summary>
        public virtual DbSet<ActionLog> ActionLogs { get; set; }
        /// <summary>
        /// 楼栋
        /// </summary>
        public virtual DbSet<Building> Buildings { get; set; }
        /// <summary>
        /// 枚举类型字典
        /// </summary>
        public virtual DbSet<Dictionary> Dictionarys { get; set; }
        /// <summary>
        /// 房屋
        /// </summary>
        public virtual DbSet<House> Houses { get; set; }
        /// <summary>
        /// 人脸一体机
        /// </summary>
        public virtual DbSet<Mao> Maos { get; set; }
        /// <summary>
        /// 人脸一体机与楼栋关系
        /// </summary>
        public virtual DbSet<MaoBuilding> MaoBuildings { get; set; }
        /// <summary>
        /// 人脸一体机失败任务
        /// </summary>
        public virtual DbSet<MaoFailedJob> MaoFailedJobs { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public virtual DbSet<Project> Projects { get; set; }
        /// <summary>
        /// 人脸注册
        /// </summary>
        public virtual DbSet<Register> Registers { get; set; }
        /// <summary>
        /// 客户端系统用户
        /// </summary>
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        /// <summary>
        /// 小区用户
        /// </summary>
        public virtual DbSet<User> Users { get; set; }
        /// <summary>
        /// 小区用户与房屋关系
        /// </summary>
        public virtual DbSet<UserHouse> UserHouses { get; set; }
        /// <summary>
        /// 表名映射规则
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetTableName(Type type)
        {
            var pluralizationService = DbConfiguration.DependencyResolver.GetService<IPluralizationService>();

            //var result = pluralizationService.Pluralize(type.Name);//复数形式
            var result = type.Name;//非复数形式

            result = "f_" + Regex.Replace(result, ".[A-Z]", m => m.Value[0] + "_" + m.Value[1]);

            return result.ToLower();
        }

        ///// <summary>
        ///// 字段名映射规则
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //private string GetColumnName(string name)
        //{
        //    var result = Regex.Replace(name, ".[A-Z]", m => m.Value[0] + "_" + m.Value[1]);
        //    return result.ToLower();
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //dynamically load all configuration
            modelBuilder.Configurations.AddFromAssembly(typeof(FacePlatformDB).Assembly);
            //制定表名映射规则
            modelBuilder.Types().Configure(c => c.ToTable(GetTableName(c.ClrType)));
            ////制定字段名映射规则
            //modelBuilder.Properties().Configure(p =>
            //{
            //    p.HasColumnName(GetColumnName(p.ClrPropertyInfo.Name));
            //});

            /*看到上述有个Properties方法，但是令人厌恶的是此方法无参数，也就是无法获得私有的属性，所以在约定中进行注册尝试失败*/

            //throw new UnintentionalCodeFirstException();

            #region EntityFramework TPH
            #endregion

            #region 字段编码
            modelBuilder.Entity<ActionLog>()
                        .Property(e => e.remark)
                        .IsUnicode(false);

            modelBuilder.Entity<Building>()
                    .Property(e => e.building_code)
                    .IsUnicode(false);

            modelBuilder.Entity<Building>()
                    .Property(e => e.building_name)
                    .IsUnicode(false);

            modelBuilder.Entity<Building>()
                    .Property(e => e.project_code)
                    .IsUnicode(false);

            modelBuilder.Entity<Dictionary>()
                    .Property(e => e.enum_type)
                    .IsUnicode(false);

            modelBuilder.Entity<Dictionary>()
                    .Property(e => e.enum_name)
                    .IsUnicode(false);

            modelBuilder.Entity<House>()
                    .Property(e => e.house_code)
                    .IsUnicode(false);

            modelBuilder.Entity<House>()
                    .Property(e => e.house_name)
                    .IsUnicode(false);

            modelBuilder.Entity<House>()
                    .Property(e => e.unit)
                    .IsUnicode(false);

            modelBuilder.Entity<House>()
                    .Property(e => e.building_code)
                    .IsUnicode(false);

            modelBuilder.Entity<House>()
                    .Property(e => e.floor)
                    .IsUnicode(false);

            modelBuilder.Entity<House>()
                    .Property(e => e.roomnumber)
                    .IsUnicode(false);

            modelBuilder.Entity<Mao>()
                    .Property(e => e.mao_no)
                    .IsUnicode(false);

            modelBuilder.Entity<Mao>()
                    .Property(e => e.mao_name)
                    .IsUnicode(false);

            modelBuilder.Entity<Mao>()
                    .Property(e => e.ip)
                    .IsUnicode(false);

            modelBuilder.Entity<Mao>()
                    .Property(e => e.port)
                    .IsUnicode(false);

            modelBuilder.Entity<MaoBuilding>()
                    .Property(e => e.building_code)
                    .IsUnicode(false);

            modelBuilder.Entity<Project>()
                    .Property(e => e.project_code)
                    .IsUnicode(false);

            modelBuilder.Entity<Project>()
                    .Property(e => e.project_name)
                    .IsUnicode(false);

            modelBuilder.Entity<Register>()
                    .Property(e => e.user_uid)
                    .IsUnicode(false);

            modelBuilder.Entity<Register>()
                    .Property(e => e.face_id)
                    .IsUnicode(false);

            modelBuilder.Entity<Register>()
                    .Property(e => e.photo_path)
                    .IsUnicode(false);

            modelBuilder.Entity<Register>()
                    .Property(e => e.tc_path)
                    .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                    .Property(e => e.user_name)
                    .IsUnicode(false);

            modelBuilder.Entity<SystemUser>()
                    .Property(e => e.password)
                    .IsUnicode(false);

            modelBuilder.Entity<User>()
                    .Property(e => e.user_uid)
                    .IsUnicode(false);

            modelBuilder.Entity<User>()
                    .Property(e => e.name)
                    .IsUnicode(false);

            modelBuilder.Entity<User>()
                    .Property(e => e.id_num)
                    .IsUnicode(false);

            modelBuilder.Entity<User>()
                    .Property(e => e.id_pic)
                    .IsUnicode(false);

            modelBuilder.Entity<User>()
                    .Property(e => e.mobile)
                    .IsUnicode(false);

            modelBuilder.Entity<User>()
                    .Property(e => e.tel)
                    .IsUnicode(false);

            modelBuilder.Entity<User>()
                    .Property(e => e.people_id)
                    .IsUnicode(false);

            modelBuilder.Entity<User>()
                    .Property(e => e.check_note)
                    .IsUnicode(false);

            modelBuilder.Entity<User>()
                    .Property(e => e.job)
                    .IsUnicode(false);

            modelBuilder.Entity<User>()
                    .Property(e => e.job_number)
                    .IsUnicode(false);

            modelBuilder.Entity<UserHouse>()
                    .Property(e => e.house_code)
                    .IsUnicode(false);

            modelBuilder.Entity<UserHouse>()
                    .Property(e => e.user_uid)
                    .IsUnicode(false);

            modelBuilder.Entity<UserHouse>()
                    .Property(e => e.relation)
                    .IsUnicode(false);
            #endregion
        }
    }
}
