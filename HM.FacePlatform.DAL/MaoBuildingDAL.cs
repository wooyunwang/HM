using HM.Enum_.FacePlatform;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace HM.FacePlatform.DAL
{
    public class MaoBuildingDAL : BaseDAL<MaoBuilding>
    {
        /// <summary>
        /// 软删除某人脸一体机上的指定楼栋
        /// </summary>
        /// <param name="maoId"></param>
        /// <param name="lstBuildingCode"></param>
        /// <returns></returns>
        public int SoftDelete(int maoId, List<string> lstBuildingCode)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.MaoBuildings.Where(it => it.mao_id == maoId && lstBuildingCode.Contains(it.building_code))
                     .Update(x => new MaoBuilding()
                     {
                         is_del = IsDelType.是,
                         change_time = DateTime.Now
                     });
            }
        }
    }
}
