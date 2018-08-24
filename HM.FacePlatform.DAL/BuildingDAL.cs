using HM.DTO;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data.Entity;
using HM.DTO.FacePlatform;

namespace HM.FacePlatform.DAL
{
    public class BuildingDAL : BaseDAL<Building>
    {
        public List<Building> GetBuildingForMao(int mao_id)
        {
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="project_code">项目编号</param>
        /// <param name="mao_id">猫id</param>
        /// <param name="build_name">楼栋名称</param>
        /// <param name="hasMap">是否已映射</param>
        /// <returns></returns>
        public PagerData<BuildingForMapDto> GetBuildingForMap(int pageIndex, int pageSize, string project_code, int mao_id, string build_name, bool? hasMap)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Set<Building>().AsNoTracking().Where(it => it.project_code == project_code);

                if (!string.IsNullOrWhiteSpace(build_name))
                {
                    query = query.Where(it => it.building_name.Contains(build_name));
                }
                if (hasMap.HasValue)
                {
                    if (hasMap.Value)
                    {
                        query = query.Where(it => it.MaoBuildings.Any(mb => mb.mao_id == mao_id));
                    }
                    else {
                        query = query.Where(it => !it.MaoBuildings.Any(mb => mb.mao_id == mao_id));
                    }
                }
#if DEBUG
                string sql = query.ToString();
#endif

                PagerData<BuildingForMapDto> pagerData = new PagerData<BuildingForMapDto>();
                pagerData.total = query.Count();
                if (pagerData.total % pageSize == 0)
                {
                    pagerData.pages = pagerData.total / pageSize;
                }
                else
                {
                    pagerData.pages = pagerData.total / pageSize + 1;
                }
                var query2 = query.Select(it => new BuildingForMapDto()
                {
                    id = it.id,
                    building_code = it.building_code,
                    building_name = it.building_name,
                    project_code = it.project_code,
                    has_map = it.MaoBuildings.Any(mb => mb.mao_id == mao_id)
                });
                query2 = query2.OrderBy(it => it.building_name);
                query2 = query2.Skip(pageSize * pageIndex).Take(pageSize);
#if DEBUG
                string sqlPage = query2.ToString();
#endif
                pagerData.rows = query2.ToList();

                return pagerData;
            }
        }

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
