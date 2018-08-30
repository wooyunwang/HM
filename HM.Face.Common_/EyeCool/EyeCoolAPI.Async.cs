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
        /// 获取人脸一体机上时间
        /// </summary>
        /// <param name="timeSpan">超时时间</param>
        /// <returns></returns>
        public async Task<ClockInfo> GetClockInfoAsync(TimeSpan? timeSpan = null)
        {
            RequestBase input = new RequestBase();
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/get_clock_info")
                .WithTimeout(timeSpan ?? new TimeSpan(0, 0, 0, 0, 500))
                .PostJsonAsync(input).ReceiveJson<ClockInfo>();
        }
        /// <summary>
        /// 获取版本信息
        /// </summary>
        /// <param name="timeSpan">超时时间</param>
        /// <returns></returns>
        public async Task<FaceVersion> GetFaceVersionAsync(TimeSpan? timeSpan = null)
        {
            RequestBase input = new RequestBase();
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/get_jar_info")
                .WithTimeout(timeSpan ?? new TimeSpan(0, 0, 0, 0, 500))
                .PostJsonAsync(input).ReceiveJson<FaceVersion>();
        }
        /// <summary>
        /// 用于采集人员(如业主)身份基础信息（注册）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PeopleCreateOutput> PeopleCreateAsync(PeopleCreateInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_create_extend")
                  .PostJsonAsync(input).ReceiveJson<PeopleCreateOutput>();
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
        public async Task<CheckingOutput> CheckingAsync(CheckingInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/checking_extend")
                 .PostJsonAsync(input).ReceiveJson<CheckingOutput>();
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
        public async Task<PeopleAddOutput> PeopleAddAsync(PeopleAddInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_add_extend")
               .PostJsonAsync(input).ReceiveJson<PeopleAddOutput>();
        }
        /// <summary>
        /// 增加组接口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CrowdCreateOutput> CrowdCreateAsync(CrowdCreateInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/crowd_create_extend")
               .PostJsonAsync(input).ReceiveJson<CrowdCreateOutput>();
        }

        /// <summary>
        /// 人增加到组接口
        /// <!--
        /// 将一个或一组People加入到一个Crowd中
        /// ]]>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CrowdAddOutput> CrowdAddAsync(CrowdAddInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/crowd_add_extend")
               .PostJsonAsync(input).ReceiveJson<CrowdAddOutput>();
        }
        /// <summary>
        /// 获取已注册数据的
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<GetRegisterDataOutput>> GetRegisterDataAsync(GetRegisterDataInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/get_register_data")
              .PostJsonAsync(input).ReceiveJson<List<GetRegisterDataOutput>>();//ReceiveString();
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="input"></param>
        public async Task<ReviewPeopleOutput> ReviewPeopleAsync(ReviewPeopleInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/review_people")
              .PostJsonAsync(input).ReceiveJson<ReviewPeopleOutput>();
        }
        /// <summary>
        /// 人员通行明细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<CurrentDetailOutput>> CurrentDetailAsync(CurrentDetailInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/current_detail")
            .PostJsonAsync(input).ReceiveJson<List<CurrentDetailOutput>>();
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PeopleDeleteOutput> PeopleDeleteAsync(PeopleDeleteInput input, bool softDelete = true)
        {
            FillIDAndKey(input);
            if (softDelete)
            {
                return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_delete_extend")
                    .PostJsonAsync(input).ReceiveJson<PeopleDeleteOutput>();
            }
            else
            {
                return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_delete")
                    .PostJsonAsync(input).ReceiveJson<PeopleDeleteOutput>();
            }
        }
        /// <summary>
        /// 删除人脸
        /// </summary>
        /// <param name="input"></param>
        /// <param name="softDelete"></param>
        /// <returns></returns>
        public async Task<PeopleRemoveOutput> PeopleRemoveAsync(PeopleRemoveInput input, bool softDelete = true)
        {
            FillIDAndKey(input);
            if (softDelete)
            {
                return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_remove_extend")
                    .PostJsonAsync(input).ReceiveJson<PeopleRemoveOutput>();
            }
            else
            {
                return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_remove")
                    .PostJsonAsync(input).ReceiveJson<PeopleRemoveOutput>();
            }
        }

        /// <summary>
        /// 更新人员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PeopleUpdateOutput> PeopleUpdateAsync(PeopleUpdateInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_update_extend")
                .PostJsonAsync(input).ReceiveJson<PeopleUpdateOutput>();
        }
        /// <summary>
        /// 实现两张图片的比对校验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<MatchCompareOutput> MatchCompareAsync(MatchCompareInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/match_compare_extend")
                .PostJsonAsync(input).ReceiveJson<MatchCompareOutput>();
        }
        /// <summary>
        /// 人证合一认证
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PersonCardSnapshotOutput> PersonCardSnapshotAsync(PersonCardSnapshotInput input)
        {
            FillIDAndKey(input);
            return await ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/person_card_snapshot")
                .PostJsonAsync(input).ReceiveJson<PersonCardSnapshotOutput>();
        }
    }
}
