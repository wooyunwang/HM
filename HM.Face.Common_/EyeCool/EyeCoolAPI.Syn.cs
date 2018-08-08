using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Flurl.Http;
using Flurl;
using System.Threading.Tasks;

namespace HM.Face.Common_.EyeCool
{
    public partial class EyeCoolAPI
    {
        /// <summary>
        /// 用于采集人员(如业主)身份基础信息（注册）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public PeopleCreateOutput PeopleCreate(PeopleCreateInput input)
        {
            return PeopleCreateAsync(input).Result;
        }
        /// <summary>
        /// 图片检测
        /// <!--
        /// 检测图片(Image)中的人脸(Face)的位置和相应的人脸属性，包括多人脸检测; 
        /// 目前人脸属性包括性别(gender), 年龄(age)和姿势(pose);
        /// 检测有效后会由系统生成唯一的face_id;
        /// 若face_id没有被加入任何people之中，则在48小时之后过期被自动清除。
        /// -->
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public CheckingOutput Checking(CheckingInput input)
        {
            return CheckingAsync(input).Result;
        }
        /// <summary>
        /// 图片添加到人
        /// <!--
        /// 将一个或一组Face加入到一个People中。
        /// 注意， 同一个Face只能被加入到一个People中。
        /// ]]>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public PeopleAddOutput PeopleAdd(PeopleAddInput input)
        {
            return PeopleAddAsync(input).Result;
        }
        /// <summary>
        /// 增加组接口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public CrowdCreateOutput CrowdCreate(CrowdCreateInput input)
        {
            return CrowdCreateAsync(input).Result;
        }

        /// <summary>
        /// 人增加到组接口
        /// <!--
        /// 将一个或一组People加入到一个Crowd中
        /// ]]>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public CrowdAddOutput CrowdAdd(CrowdAddInput input)
        {
            return CrowdAddAsync(input).Result;
        }
        /// <summary>
        /// 获取已注册数据的
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public List<GetRegisterDataOutput> GetRegisterData(GetRegisterDataInput input)
        {
            return GetRegisterDataAsync(input).Result;
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="input"></param>
        [EyeCoolRequest]
        public ReviewPeopleOutput ReviewPeople(ReviewPeopleInput input)
        {
            return ReviewPeopleAsync(input).Result;
        }
        /// <summary>
        /// 人员通行明细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public List<CurrentDetailOutput> CurrentDetail(CurrentDetailInput input)
        {
            return CurrentDetailAsync(input).Result;
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public PeopleDeleteOutput PeopleDelete(PeopleDeleteInput input, bool softDelete = true)
        {
            return PeopleDeleteAsync(input, softDelete).Result;
        }
        /// <summary>
        /// 删除人脸
        /// </summary>
        /// <param name="input"></param>
        /// <param name="softDelete"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public PeopleRemoveOutput PeopleRemove(PeopleRemoveInput input, bool softDelete = true)
        {
            return PeopleRemoveAsync(input, softDelete).Result;
        }

        /// <summary>
        /// 更新人员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public PeopleUpdateOutput PeopleUpdate(PeopleUpdateInput input)
        {
            return PeopleUpdateAsync(input).Result;
        }
        /// <summary>
        /// 实现两张图片的比对校验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public MatchCompareOutput MatchCompare(MatchCompareInput input)
        {
            return MatchCompareAsync(input).Result;
        }
        /// <summary>
        /// 人证合一认证
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public PersonCardSnapshotOutput PersonCardSnapshot(PersonCardSnapshotInput input)
        {
            return PersonCardSnapshotAsync(input).Result;
        }
    }
}
