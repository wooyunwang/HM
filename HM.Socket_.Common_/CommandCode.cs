using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{

    /// <summary>
    /// 命令编码+响应编码
    /// <![CDATA[
    /// 十六进制：
    /// 文档表示：02H
    /// C#表示：0x02
    /// ]]>
    /// </summary>
    public enum CmdCode : byte
    {
        /// <summary>
        /// 开关门命令
        /// </summary>
        OpenCloseDoorCMD = 0x02,
        /// <summary>
        /// 开关门命令
        /// 【响应】
        /// </summary>
        OpenCloseDoorCMD_ = 0x03,
        /// <summary>
        /// 禁止（夜间）模式、高峰模式时间段、周期设置命令
        /// </summary>
        SetTimeCMD = 0x04,
        /// <summary>
        /// 禁止（夜间）模式、高峰模式时间段、周期设置命令
        /// 【响应】
        /// </summary>
        SetTimeCMD_ = 0x05,
        /// <summary>
        /// 正常设置日期命令
        /// </summary>
        SetDateNormalCMD = 0x06,
        /// <summary>
        /// 正常设置日期命令
        /// 【响应】
        /// </summary>
        SetDateNormalCMD_ = 0x07,
        /// <summary>
        /// 设置模式：禁止（夜间）、高峰、正常（假期）、自动
        /// </summary>
        SetRunModeCMD = 0xF1,
        /// <summary>
        /// 设置模式：禁止（夜间）、高峰、正常（假期）、自动
        /// 【响应】
        /// </summary>
        SetRunModeCMD_ = 0xF2,
        /// <summary>
        /// 禁止（封锁）模式、消防模式命令
        /// </summary>
        SetHighLevelCMD = 0xF3,
        /// <summary>
        /// 禁止（封锁）模式、消防模式命令
        /// 【响应】
        /// </summary>
        SetHighLevelCMD_ = 0xF4,
        /// <summary>
        /// 设置通告命令
        /// </summary>
        SetNoticeCMD = 0x08,
        /// <summary>
        /// 设置通告命令
        /// 【响应】
        /// </summary>
        SetNoticeCMD_ = 0x09,
        ///// <summary>
        ///// 设置黑猫笑脸命令
        ///// 【请求与响应一致】
        ///// </summary>
        //SetBlackCatCMD = 0x01,
        /// <summary>
        /// 显示通行数据命令
        /// </summary>
        GetPeopleNumCMD = 0x0A,
        /// <summary>
        /// 显示通行数据命令
        /// 【响应】
        /// </summary>
        GetPeopleNumCMD_ = 0x0B,
        /// <summary>
        /// 设置通行方向命令
        /// </summary>
        SetDirectionCMD = 0x0C,
        /// <summary>
        /// 设置通行方向命令
        /// 【响应】
        /// </summary>
        SetDirectionCMD_ = 0x0D,
        /// <summary>
        /// 获取异常信号命令
        /// </summary>
        GetAbnormalSignalCMD = 0x0E,
        /// <summary>
        /// 获取异常信号命令
        /// 【响应】
        /// </summary>
        GetAbnormalSignalCMD_ = 0x0F,
        /// <summary>
        /// 同步黑猫当前运行模式
        /// </summary>
        SynchronizeModeCMD = 0xF5,
        /// <summary>
        /// 同步黑猫当前运行模式
        /// 【响应】
        /// </summary>
        SynchronizeModeCMD_ = 0xF6,
        /// <summary>
        /// 设置黑猫背景图片
        /// </summary>
        SetBlackCatBackGroundCMD = 0xF7,
        /// <summary>
        /// 设置黑猫背景图片
        /// 【响应】
        /// </summary>
        SetBlackCatBackGroundCMD_ = 0xF8,
        /// <summary>
        /// 设置黑猫视频轮播
        /// </summary>
        SetBlackCatBackVideoCMD = 0xF9,
        /// <summary>
        /// 设置黑猫视频轮播
        /// 【响应】
        /// </summary>
        SetBlackCatBackVideoCMD_ = 0xFA,
        #region 新增部分，文档缺失
        /// <summary>
        /// 自定义告警
        /// </summary>
        GetUserDefineAbnormalSignalCMD = 0x10,
        /// <summary>
        /// 自定义告警
        /// 【响应】
        /// </summary>
        GetUserDefineAbnormalSignalCMD_ = 0x11,
        /// <summary>
        /// 配置信息
        /// </summary>
        GetConfigInfoCMD = 0x12,
        /// <summary>
        /// 配置信息
        /// 【响应】
        /// </summary>
        GetConfigInfoCMD_ = 0x13,
        /// <summary>
        /// 人脸通行明细
        /// </summary>
        GetFaceEntranceDetailCMD = 0xE1,
        /// <summary>
        /// 人脸通行明细
        /// 【响应】
        /// </summary>
        GetFaceEntranceDetailCMD_ = 0xE2,
        /// <summary>
        /// IC卡通行明细
        /// </summary>
        GetICCardEntranceDetailCMD = 0xE3,
        /// <summary>
        /// IC卡通行明细
        /// 【响应】
        /// </summary>
        GetICCardEntranceDetailCMD_ = 0xE4,
        #endregion

       
    }
}
