using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{
    public enum SignalType : byte
    {
        翼闸 = 0x01,
        玻璃门 = 0x02,
        仓内红外对射 = 0x03,
        周界 = 0x04,
        GPIO板 = 0x05,
        网络异常 = 0x06,
        人脸识别 = 0x07,
        语音板 = 0x08,
        TV = 0x09,
        立柱对讲 = 0x0A,
        仓内对讲 = 0x0B,
        客流计数器 = 0x0C
    }
    public class SignalTypeMap
    {
        public SignalTypeMap(SignalType signalType, byte signalValue, string signalValueComment, string signalValueCommentExt = "")
        {
            SignalType = (byte)signalType;
            SignalValue = signalValue;
            SignalValueComment = signalValueComment;
            SignalValueCommentExt = signalValueCommentExt;
        }

        public SignalTypeMap(SignalType signalType, byte signalValue, string signalValueComment, byte signalWeight)
        {
            SignalType = (byte)signalType;
            SignalValue = signalValue;
            SignalValueComment = signalValueComment;
            SignalWeight = signalWeight;
        }

        /// <summary>
        /// 异常类型
        /// </summary>
        public byte SignalType { get; set; }
        /// <summary>
        /// 异常值
        /// </summary>
        public byte SignalValue { get; set; }
        /// <summary>
        /// 异常值备注
        /// </summary>
        public string SignalValueComment { get; set; }
        /// <summary>
        /// 异常值备注扩展
        /// </summary>
        public string SignalValueCommentExt { get; set; }
        /// <summary>
        /// 权重
        /// </summary>
        public byte? SignalWeight { get; set; }
    }
    /// <summary>
    /// 信号映射数据
    /// </summary>
    public static class GetAbnormalSignalCMD_Map
    {
        public static List<SignalTypeMap> lstSignalTypeMap = new List<SignalTypeMap>()
        {
            new SignalTypeMap(SignalType.翼闸,0x01,"闸机【A门】无法正常关闭",100),
            new SignalTypeMap(SignalType.翼闸,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
            new SignalTypeMap(SignalType.玻璃门,0x01,"玻璃门【B门】无法正常关闭",100),
            new SignalTypeMap(SignalType.玻璃门,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
            new SignalTypeMap(SignalType.仓内红外对射,0x01,"舱内人员滞留",100),
            new SignalTypeMap(SignalType.仓内红外对射,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
            new SignalTypeMap(SignalType.周界,0x01,"闸机【A门】有人翻越",100),//X
            new SignalTypeMap(SignalType.周界,0x02,"玻璃门【B门】有人翻越",100),//X
            new SignalTypeMap(SignalType.周界,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),//X
            new SignalTypeMap(SignalType.GPIO板,0x01,"GPIO通讯故障丢包率过高",100),
            new SignalTypeMap(SignalType.GPIO板,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
            new SignalTypeMap(SignalType.网络异常,0x01,"访客系统登记电脑Ping不通",100),
            new SignalTypeMap(SignalType.网络异常,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
            new SignalTypeMap(SignalType.人脸识别,0x01,"人脸识别机Ping不通",100),
            new SignalTypeMap(SignalType.人脸识别,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
            new SignalTypeMap(SignalType.语音板,0x01,"语音板Ping不通",100),
            new SignalTypeMap(SignalType.语音板,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
            new SignalTypeMap(SignalType.TV,0x01,"广告机Ping不通",100),
            new SignalTypeMap(SignalType.TV,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
            new SignalTypeMap(SignalType.立柱对讲,0x01,"闸机外对讲Ping不通",100),
            new SignalTypeMap(SignalType.立柱对讲,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
            new SignalTypeMap(SignalType.仓内对讲,0x01,"舱内对讲Ping不通",100),
            new SignalTypeMap(SignalType.仓内对讲,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
            new SignalTypeMap(SignalType.客流计数器,0x01,"客流计Ping不通",100),
            new SignalTypeMap(SignalType.客流计数器,0x03,"恢复正常","仅针对异常恢复到正常发送一次"),
        };
    }
    /// <summary>
    /// 获取信号命令
    /// </summary>
    public partial class GetAbnormalSignalCMD
    {
        public GetAbnormalSignalCMD()
        {
            SignalTime = DateTime.Now;
        }
        public GetAbnormalSignalCMD(byte[] data, DateTime? signalTime = null)
        {
            if (data != null && data.Length != 3)
            {
                throw new Exception("数据异常");
            }
            else
            {
                CatCode = data[0];
                SignalType = data[1];
                SignalValue = data[2];
                SignalTime = signalTime ?? DateTime.Now;
            }
        }
        /// <summary>
        /// 黑猫编号
        /// </summary>
        public byte CatCode { get; set; }
        /// <summary>
        /// 异常信号类型
        /// </summary>
        public byte SignalType { get; set; }
        /// <summary>
        /// 异常信号数值
        /// </summary>
        public byte SignalValue { get; set; }
        /// <summary>
        /// 信号产生时间（指令中是没有此时间的）,初始化的为本机时间。可能存在时间误差问题。
        /// </summary>
        public DateTime SignalTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            List<byte> tmp = new List<byte>();
            tmp.Add(CatCode);
            tmp.Add(SignalType);
            tmp.Add(SignalValue);
            return tmp.ToArray();
        }

        /// <summary>
        /// 判断是否OK，从GetAbnormalSignalCMD_Map分析得出
        /// </summary>
        /// <returns></returns>
        public bool IsOK()
        {
            if (this.SignalType == (byte)Common.SignalType.网络异常)
            {
                return false;
            }
            else
            {
                return (this.SignalValue == 0x03);
            }
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        /// <returns></returns>
        public static byte[] ReturnData(bool result)
        {
            return new ResponseBase<byte>(
                CmdCode.GetAbnormalSignalCMD,
                result ? Constant.ok : Constant.bad
                ).ToBytes();
        }
    }
}
