using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Face.Common_.EyeCool
{
    /// <summary>
    /// 返回码
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        _0000,
        /// <summary>
        /// 失败，会提示具体错误原因
        /// </summary>
        _0001,
        /// <summary>
        /// 请求参数错误，会提示对应的参数字段
        /// </summary>
        _1001,
        /// <summary>
        /// API接口内部错误
        /// </summary>
        _5000,
        /// <summary>
        /// 数据库发生错误
        /// </summary>
        _5001,
        /// <summary>
        /// 数据库未查询出相应匹配数据
        /// </summary>
        _5002,
        /// <summary>
        /// 照片未检测出人脸, 无法提取人脸特征！
        /// </summary>
        _1067,
        /// <summary>
        /// 照片中出现的人脸数量不符合数量!
        /// </summary>
        _1068,
        /// <summary>
        /// 照片人脸特征值提取失败!
        /// </summary>
        _1069,
        /// <summary>
        /// 人员与照片绑定失败，照片已绑定其他人员
        /// </summary>
        _1070
    }
}
