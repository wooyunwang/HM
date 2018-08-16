using HM.Common_;
using HM.DTO;
using HM.DTO.FaceForm;
using HM.FacePlatform.DAL;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HM.FacePlatform.BLL
{
    public class BuildingBLL : BaseBLL<Building>
    {
        new BuildingDAL dal = new BuildingDAL();

        public List<Building> GetBuildingForMao(int mao_id)
        {
            return dal.GetBuildingForMao(mao_id);
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
        [ActionResultTryCatch]
        public ActionResult<PagerData<BuildingForMapDto>> GetBuildingForMap(int pageIndex, int pageSize, string project_code, int mao_id, string build_name, bool? hasMap)
        {
            return new ActionResult<PagerData<BuildingForMapDto>>()
            {
                IsSuccess = true,
                Obj = dal.GetBuildingForMap(pageIndex, pageSize, project_code, mao_id, build_name, hasMap)
            };
        }
        //public Building[] GetList(string project_code)
        //{
        //    try
        //    {
        //        return dal.GetList("where project_code =@project_code order by building_name", new { project_code = project_code });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("BuildingBLL.GetList: " + ex.Message);
        //    }
        //    return new Building[] { };
        //}

        //public Building[] GetList(string whereConditions, object parameters = null)
        //{
        //    try
        //    {
        //        return dal.GetList(whereConditions, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("BuildingBLL.GetList: " + ex.Message);
        //    }
        //    return new Building[] { };
        //}

        //public Task<Building[]> GetListAsync(string project_code)
        //{
        //    try
        //    {
        //        return dal.GetListAsync("where project_code =@project_code order by building_name", new { project_code = project_code });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("BuildingBLL.GetListAsync: " + ex.Message);
        //    }
        //    return Task.Run(() => { return new Building[] { }; });
        //}

        //public bool IsExist(string type, string value)
        //{
        //    try
        //    {
        //        object parameters = null;
        //        if (type == "code")
        //        {
        //            parameters = new { building_code = value };
        //        }
        //        else if (type == "name")
        //        {
        //            parameters = new { building_name = value };
        //        }

        //        return dal.RecordCount(parameters) > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("BuildingBLL.IsExist: " + ex.Message);
        //    }

        //    return true;
        //}



        //public Building[] GetListByMao(int mao_id)
        //{
        //    try
        //    {
        //        return dal.GetListByMao(mao_id);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("BuildingBLL.GetListByMao: " + ex.Message);
        //    }
        //    return new Building[] { };
        //}


    }
}
