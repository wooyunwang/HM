using HM.FacePlatform.Model;
using System.Linq;

namespace HM.FacePlatform.DAL
{
    public class SystemUserDAL : BaseDAL<SystemUser>
    {
//        public view_system_user[] GetList()
//        {
//            string sql = @"
//select su.*,da.enum_name as is_admin_name
//from f_system_user su
//inner join f_dictionary da on da.enum_type='IsAdminType' and su.is_admin=da.enum_value
//where su.id>1
//order by su.user_name";//id=1为系统自动程序使用
//            using (FacePlatformDB db = new FacePlatformDB())
//            {
//                var list = db.Query<view_system_user>(sql);
//                view_system_user[] users = list.ToArray();
//                return users;
//            }
//        }
    }
}
