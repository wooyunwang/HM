using HM.DTO;
using HM.DTO.FacePlatform;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Z.EntityFramework.Plus;

namespace HM.FacePlatform.DAL
{
    public class MaoDAL : BaseDAL<Mao>
    {
        /// <summary>
        /// 获得小区用户所在区域的人脸一体机
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<Mao> GetForFaceSection(string user_id)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = from mb in db.MaoBuildings
                            join q in db.UserHouses
                            on mb.building_code equals q.House.building_code
                            where mb.is_del != IsDelType.是
                            && q.is_del != IsDelType.是
                            && q.user_uid == user_id
                            select mb.Mao;

#if DEBUG
                string sql = query.ToString();
#endif

                return query.ToList();

            }
        }
    }
}
