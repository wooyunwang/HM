using HM.FacePlatform.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HM.FacePlatform.DAL
{
    public class BuildingDAL : BaseDAL<Building>
    {

        //        public int RecordCount(object parameters = null)
        //        {
        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                return db.RecordCount<Building>(parameters);
        //            }
        //        }
        //        public Building[] GetListByMao(int mao_id)
        //        {
        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                string sql = @"
        //select b.*
        //from f_building b
        //inner join f_mao_building mb on b.building_code = mb.building_code and mb.mao_id=@mao_id
        //order by b.building_name;";
        //                using (FacePlatformDB db = new FacePlatformDB())
        //                {
        //                    var list = db.Query<Building>(sql, new { mao_id = mao_id });
        //                    return list.ToArray<Building>();
        //                }
        //            }
        //        }

        public List<Building> GetBuildingForMao(int mao_id)
        {
            //            string sql = @"
            //select b.building_code,b.building_name
            //	,case when mb.building_code is null then 0 else 1 end as mao_building_ref
            //	,case when mb.id is null then 0 else mb.id end as id
            //from f_building b
            //left join f_mao_building mb on b.building_code = mb.building_code and mb.mao_id=@mao_id
            //order by mao_building_ref desc, b.building_name;";
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = from maobuilding in db.MaoBuildings
                            join building in db.Buildings
                            on maobuilding.building_code equals building.building_code
                            where maobuilding.mao_id == mao_id
                            orderby building.building_name
                            select building;
#if DEBUG
                string sql = query.ToString();
#endif
                return query.ToList();
            }
        }

        //public int RemoveMaoUsing(MaoBuilding maoBuilding)
        //{
        //    using (FacePlatformDB db = new FacePlatformDB())
        //    {
        //        return db.del.DeleteList<mao_building>(
        //            "where mao_id=@mao_id and building_code=@building_code"
        //            , new { mao_id = mao_building.mao_id, building_code = mao_building.building_code });
        //    }
        //}
    }
}
