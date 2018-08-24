using System;
using System.ServiceModel;

namespace HM.FacePlatform.Server
{
    [ServiceContract(Namespace = "https://www.vankeservice.com", Name = "WeChatService")]
    public interface IService
    {
        /// <summary>
        /// 通过项目编号获取楼栋
        /// </summary>
        /// <param name="project_code"></param>
        /// <returns></returns>
        [OperationContract]
        string GetBuildingListByProject(string project_code);
        /// <summary>
        /// 通过楼栋编号，获取房屋列表
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="building_code"></param>
        /// <returns></returns>
        [OperationContract]
        string GetHouseListByBuilding(string project_code, string building_code);
        /// <summary>
        /// 分页获取项目用户信息
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <returns></returns>
        [OperationContract]
        string GetPagedUserListByProject(string project_code, int pageNumber, int rowsPerPage);
        /// <summary>
        /// 分页获取项目所需更新的用户信息
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        [OperationContract]
        string GetUpdatedUserListByProject(string project_code, DateTime from, DateTime to, int? top = null);

        /// <summary>
        /// 分页获取某项目上所需更新的人脸信息
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [OperationContract]
        string GetPagedUpdatedRegisterListByProject(string project_code, int pageIndex, int pageSize, DateTime from, DateTime to);
        /// <summary>
        /// 获取人脸图片
        /// </summary>
        /// <param name="photo_path"></param>
        /// <returns></returns>
        [OperationContract]
        string GetRegisterPhoto(string project_code, string photo_path);
        /// <summary>
        /// 获取项目上某一用户
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="user_uid"></param>
        /// <returns></returns>
        [OperationContract]
        string GetUser(string project_code, string user_uid);
        /// <summary>
        /// 设置某项目的楼栋信息
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="serializedBuilding"></param>
        /// <returns></returns>
        [OperationContract]
        string PutBuilding(string project_code, string serializedBuilding);
        /// <summary>
        /// 设置房屋
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="serializedHouse"></param>
        /// <returns></returns>
        [OperationContract]
        string PutHouse(string project_code, string serializedHouse);
        /// <summary>
        /// 设置小区用户
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="serializedUser"></param>
        /// <returns></returns>
        [OperationContract]
        string PutUser(string project_code, string serializedUser);
        /// <summary>
        /// 色织注册人脸
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="serializedRegister"></param>
        /// <returns></returns>
        [OperationContract]
        string PutRegister(string project_code, string serializedRegister);
        /// <summary>
        /// 设置人脸进出历史
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="serializedEntryHistory"></param>
        /// <returns></returns>
        [OperationContract]
        string PutEntryHistory(string project_code, string serializedEntryHistory);
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string TestMethod();
    }
}
