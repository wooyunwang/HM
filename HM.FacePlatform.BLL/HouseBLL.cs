
using HM.FacePlatform.Model;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HM.FacePlatform.DAL;
using HM.Common_;
using System.Collections.Generic;
using HM.DTO;

namespace HM.FacePlatform.BLL
{
    public class HouseBLL : BaseBLL<House>
    {
        new HouseDAL dal = new HouseDAL();

        /// <summary>
        /// 获取房屋信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ActionResult<PagerData<House>> GetHousePageByBuildingCode(int pageIndex, int pageSize, string userName)
        {
            return new ActionResult<PagerData<House>>()
            {
                IsSuccess = true,
                Obj = dal.GetHousePageByBuildingCode(pageIndex, pageSize, userName)
            };
        }

        public List<User> GetUserByHouseCode(string house_code)
        {
            return dal.GetUserByHouseCode(house_code);
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
