using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Face.Common_
{
    public interface IFace
    {
        //   //获取驱动名称
        //   String GetVendorID();
        //   String GetVendorName();

        //   /// <summary>
        //   /// 检查图片
        //   /// </summary>
        //   /// <param name="picFileName"></param>
        //   /// <returns></returns>
        //HM.Utils_.   ActionResult CheckPic(string imageBase64, string registerType, string faceId);

        //   /// <summary>
        //   /// 图片内容比较
        //   /// </summary>
        //   /// <param name="img64"></param>
        //   /// <param name="pic64"></param>
        //   /// <returns></returns>
        //   bool ComparePicAndImg(string img64, string pic64, string rctype);

        //   /// <summary>
        //   /// 图片与faceID比较
        //   /// </summary>
        //   /// <param name="picFileName"></param>
        //   /// <param name="faceIDVar"></param>
        //   /// <returns></returns>
        //   ActionResult ComparePicAndfaceID(string imageBase64, string faceId, string registerType);

        //   /// <summary>
        //   /// 照片比对
        //   /// </summary>
        //   /// <param name="face_id1"></param>
        //   /// <param name="face_id2"></param>
        //   /// <returns></returns>
        //   ActionResult MatchCompare(string toCompareFaceId, string faceId);

        //   /// <summary>
        //   /// 注册
        //   /// </summary>
        //   /// <param name="registerVO"></param>
        //   /// <returns></returns>
        //   ActionResult<people_add_extend_vo> Register(ApiRegisterVO registerVO);

        //   /// <summary>
        //   /// 获取已注册的数据
        //   /// </summary>
        //   /// <param name="inVO"></param>
        //   /// <param name="ret"></param>
        //   /// <param name="retMessage"></param>
        //   /// <returns></returns>
        //   List<ApiGetRegisterOutVOBak> GetRegisterBak(ApiGetRegisterInVO getRegisterInVO);

        //   /// <summary>
        //   /// 审核
        //   /// </summary>
        //   /// <param name="checkVO"></param>
        //   /// <param name="ret"></param>
        //   /// <param name="retMessage"></param>
        //   ActionResult Check(ApiCheckVO checkVO);

        //   /// <summary>
        //   /// 获取人脸通行明细
        //   /// </summary>
        //   /// <param name="inVO"></param>
        //   /// <returns></returns>
        //   List<ApiGetFacePassOutVO> GetFacePass(CurrentDetailInput inVO);

        //   /// <summary>
        //   /// 人脸删除操作
        //   /// </summary>
        //   /// <param name="guid_value">userID或卡号</param>
        //   /// <param name="face_uid"></param>
        //   /// <param name="ErrCode"></param>
        //   /// <param name="ErrMsg"></param>
        //   /// <returns></returns>
        //   ActionResult FaceDel(string peopleId, string faceId);

        //   /// <summary>
        //   /// 设置人脸有效期
        //   /// </summary>
        //   /// <param name="people_id"></param>
        //   /// <param name="endTime"></param>
        //   /// <returns></returns>
        //   ActionResult UpdateEndTime(string peopleId, DateTime endTime);

        //   ///// <summary>
        //   ///// 查询最相似的人脸
        //   ///// </summary>
        //   ///// <param name="people_id"></param>
        //   ///// <param name="endTime"></param>
        //   ///// <returns></returns>
        //   //ApiMatchIdentifyOutVO MatchIdentify(ApiMatchIdentifyInVO inVO);

        //   /// <summary>
        //   /// 获取根目录
        //   /// </summary>
        //   /// <returns></returns>
        //   string GetFaceRootPath();
        //   /// <summary>
        //   /// 人证合一认证接口
        //   /// </summary>
        //   /// <param name="file"></param>
        //   /// <returns></returns>
        //   ActionResult PersonCardSnapshot(string file);
    }
}
