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
    public class EyeCoolAPI
    {
        string APP_ID { get; set; }
        string APP_KEY { get; set; }
        Uri ROOT_URL { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rootUrl"></param>
        public EyeCoolAPI(Uri rootUrl)
        {
            APP_ID = Constant.APP_ID;
            APP_KEY = Constant.APP_KEY;
            ROOT_URL = rootUrl;
        }
        public EyeCoolAPI(string ip, int port)
        {
            APP_ID = Constant.APP_ID;
            APP_KEY = Constant.APP_KEY;
            ROOT_URL = new Uri($"http://{ip}:{port}/");
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rootUrl"></param>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        public EyeCoolAPI(Uri rootUrl, string appId, string appKey)
        {
            this.APP_ID = appId;
            this.APP_KEY = appKey;
            this.ROOT_URL = rootUrl;
        }

        /// <summary>
        /// 填充id和key
        /// </summary>
        /// <param name="request"></param>
        private void FillIDAndKey(RequestBase request)
        {
            request.app_id = APP_ID;
            request.app_key = APP_KEY;
        }

        /// <summary>
        /// 用于采集人员(如业主)身份基础信息（注册）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public Task<PeopleCreateOutput> PeopleCreate(PeopleCreateInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_create_extend")
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
        [EyeCoolRequest]
        public Task<CheckingOutput> Checking(CheckingInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/checking_extend")
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
        [EyeCoolRequest]
        public Task<PeopleAddOutput> PeopleAdd(PeopleAddInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_add_extend")
               .PostJsonAsync(input).ReceiveJson<PeopleAddOutput>();
        }
        /// <summary>
        /// 增加组接口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public Task<CrowdCreateOutput> CrowdCreate(CrowdCreateInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/crowd_create_extend")
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
        [EyeCoolRequest]
        public Task<CrowdAddOutput> CrowdAdd(CrowdAddInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/crowd_add_extend")
               .PostJsonAsync(input).ReceiveJson<CrowdAddOutput>();
        }
        /// <summary>
        /// 获取已注册数据的
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public Task<List<GetRegisterDataOutput>> GetRegisterData(GetRegisterDataInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/get_register_data")
              .PostJsonAsync(input).ReceiveJson<List<GetRegisterDataOutput>>();//ReceiveString();
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="input"></param>
        [EyeCoolRequest]
        public Task<ReviewPeopleOutput> ReviewPeople(ReviewPeopleInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/review_people")
              .PostJsonAsync(input).ReceiveJson<ReviewPeopleOutput>();
        }
        /// <summary>
        /// 人员通行明细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public Task<List<CurrentDetailOutput>> CurrentDetail(CurrentDetailInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/current_detail")
            .PostJsonAsync(input).ReceiveJson<List<CurrentDetailOutput>>();
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public Task<PeopleDeleteOutput> PeopleDelete(PeopleDeleteInput input, bool softDelete = true)
        {
            FillIDAndKey(input);
            if (softDelete)
            {
                return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_delete_extend")
                    .PostJsonAsync(input).ReceiveJson<PeopleDeleteOutput>();
            }
            else
            {
                return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_delete")
                    .PostJsonAsync(input).ReceiveJson<PeopleDeleteOutput>();
            }
        }
        /// <summary>
        /// 删除人脸
        /// </summary>
        /// <param name="input"></param>
        /// <param name="softDelete"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public Task<PeopleRemoveOutput> PeopleRemove(PeopleRemoveInput input, bool softDelete = true)
        {
            FillIDAndKey(input);
            if (softDelete)
            {
                return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_remove_extend")
                    .PostJsonAsync(input).ReceiveJson<PeopleRemoveOutput>();
            }
            else
            {
                return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_remove")
                    .PostJsonAsync(input).ReceiveJson<PeopleRemoveOutput>();
            }
        }

        /// <summary>
        /// 更新人员
        /// </summary>
        /// <param name="inVO"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public Task<PeopleUpdateOutput> PeopleUpdate(PeopleUpdateInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_update_extend")
                .PostJsonAsync(input).ReceiveJson<PeopleUpdateOutput>();
        }
        /// <summary>
        /// 实现两张图片的比对校验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public Task<MatchCompareOutput> MatchCompare(MatchCompareInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/match_compare_extend")
                .PostJsonAsync(input).ReceiveJson<MatchCompareOutput>();
        }
        /// <summary>
        /// 人证合一认证
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [EyeCoolRequest]
        public Task<PersonCardSnapshotOutput> PersonCardSnapshot(PersonCardSnapshotInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/person_card_snapshot")
                .PostJsonAsync(input).ReceiveJson<PersonCardSnapshotOutput>();
        }
    }
}
