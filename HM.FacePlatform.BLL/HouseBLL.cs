
using HM.FacePlatform.Model;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HM.FacePlatform.DAL;
using HM.Common_;
using System.Collections.Generic;
using HM.DTO;
using HM.DTO.FacePlatform;

namespace HM.FacePlatform.BLL
{
    public class HouseBLL : BaseBLL<House>
    {
        new HouseDAL dal = new HouseDAL();

        /// <summary>
        /// 通过房号获取房屋用户关系信息（包括User对象、House对象）
        /// </summary>
        /// <param name="house_code"></param>
        /// <returns></returns>
        public ActionResult<System.Collections.Generic.List<UserHouse>> GetUserHouseWithUserAndHouse(string house_code)
        {
            return new ActionResult<System.Collections.Generic.List<UserHouse>>()
            {
                IsSuccess = true,
                Obj = dal.GetUserHouseWithUserAndHouse((string)house_code)
            };
        }


        /// <summary>
        /// 获取房屋信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="buildingCode"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ActionResult<PagerData<HouseForRegisterDto>> GetPageHouseForRegisterDto(int pageIndex, int pageSize, string buildingCode, string userName)
        {
            return new ActionResult<PagerData<HouseForRegisterDto>>()
            {
                IsSuccess = true,
                Obj = dal.GetPageHouseForRegisterDto((int)pageIndex, (int)pageSize, (string)buildingCode, (string)userName)
            };
        }



        //public view_user_house[] GetUserList(DateTime from, DateTime to)
        //{
        //    try
        //    {
        //        return dal.GetUserList(from, to);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("HouseBLL.GetUserList: " + ex.Message);
        //    }

        //    return new view_user_house[] { };
        //}

        ////public Task<view_user_house[]> GetUserListAsync(string house_code)


        //public view_user_house[] GetStatistics(int pageNumber, int rowsPerPage, string building_code, bool includeTotalCount)
        //{
        //    try
        //    {
        //        //Regex regex = new Regex("\\,+");
        //        view_user_house[] user_houses = dal.GetStatistics(pageNumber, rowsPerPage, building_code, includeTotalCount);
        //        //foreach(view_user_house user_house in user_houses)
        //        //{
        //        //    user_house.name = regex.Replace(user_house.name.Trim(','), ",");
        //        //}
        //        return user_houses;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("HouseBLL.GetStatistics: " + ex.Message);
        //    }

        //    return new view_user_house[] { };
        //}

        //public view_user_house GetHouseStatistics(string house_code)
        //{
        //    try
        //    {
        //        view_user_house[] user_houses = dal.GetHouseStatistics(house_code);
        //        if (user_houses.Length > 0) return user_houses[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("HouseBLL.GetHouseStatistics: " + ex.Message);
        //    }

        //    return null;
        //}

        //public UserHouse GetUserHouse(string user_uid, string house_code)
        //{
        //    try
        //    {
        //        return dal.GetUserHouse(user_uid, house_code);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("HouseBLL.GetUserHouse: " + ex.Message);
        //    }
        //    return null;
        //}

        //public int? AddUserHouse(UserHouse _user_house)
        //{
        //    try
        //    {
        //        return dal.AddUserHouse(_user_house);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("HouseBLL.AddUserHouse: " + ex.Message);
        //    }
        //    return 0;
        //}

        //public int UpdateUserHouse(UserHouse _user_house)
        //{
        //    try
        //    {
        //        return dal.UpdateUserHouse(_user_house);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("HouseBLL.UpdateUserHouse: " + ex.Message);
        //    }
        //    return 0;
        //}
    }
}
