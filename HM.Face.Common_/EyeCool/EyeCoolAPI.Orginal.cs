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

    public partial class EyeCoolAPI//Orginal为测试类
    {
#if DEBUG
        /// <summary>
        /// 用于采集人员(如业主)身份基础信息（注册）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic PeopleCreate_Debug(PeopleCreateInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_create_extend").PostJsonAsync(input).ReceiveJson<dynamic>().Result;
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
        public dynamic Checking_Debug(CheckingInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/checking_extend")
                 .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
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
        public dynamic PeopleAdd_Debug(PeopleAddInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_add_extend")
               .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
        }
        /// <summary>
        /// 增加组接口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic CrowdCreate_Debug(CrowdCreateInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/crowd_create_extend")
               .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
        }

        /// <summary>
        /// 人增加到组接口
        /// <!--
        /// 将一个或一组People加入到一个Crowd中
        /// ]]>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic CrowdAdd_Debug(CrowdAddInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/crowd_add_extend")
               .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
        }
        /// <summary>
        /// 获取已注册数据的
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic GetRegisterData_Debug(GetRegisterDataInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/get_register_data")
              .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="input"></param>
        public dynamic ReviewPeople_Debug(ReviewPeopleInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/review_people")
              .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
        }
        /// <summary>
        /// 人员通行明细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic CurrentDetail_Debug(CurrentDetailInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/current_detail")
            .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic PeopleDelete_Debug(PeopleDeleteInput input, bool softDelete = true)
        {
            FillIDAndKey(input);
            if (softDelete)
            {
                return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_delete_extend")
                    .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
            }
            else
            {
                return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_delete")
                    .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
            }
        }
        /// <summary>
        /// 删除人脸
        /// </summary>
        /// <param name="input"></param>
        /// <param name="softDelete"></param>
        /// <returns></returns>
        public dynamic PeopleRemove_Debug(PeopleRemoveInput input, bool softDelete = true)
        {
            FillIDAndKey(input);
            if (softDelete)
            {
                return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_remove_extend")
                    .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
            }
            else
            {
                return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_remove")
                    .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
            }
        }

        /// <summary>
        /// 更新人员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic PeopleUpdate_Debug(PeopleUpdateInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/people_update_extend")
                .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
        }
        /// <summary>
        /// 实现两张图片的比对校验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic MatchCompare_Debug(MatchCompareInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/match_compare_extend")
                .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
        }
        /// <summary>
        /// 人证合一认证
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic PersonCardSnapshot_Debug(PersonCardSnapshotInput input)
        {
            FillIDAndKey(input);
            return ROOT_URL.AbsoluteUri.AppendPathSegment("/faceInterface/biovregister/person_card_snapshot")
                .PostJsonAsync(input).ReceiveJson<dynamic>().Result;
        }
#endif
    }
}
