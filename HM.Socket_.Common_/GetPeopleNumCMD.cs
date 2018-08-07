using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common_
{
    public class GetPeopleNumCMD
    {
        public GetPeopleNumCMD()
        {
        }

        public GetPeopleNumCMD(byte[] data)
        {
            if (data != null && data.Length != 32)
            {
                throw new Exception("数据异常");
            }
            else
            {
                CatCode = data[0];
                int offset = 1;
                TotalInCount = Utils.ByteToInt(data, 3, ref offset);
                IcPunchCount = Utils.ByteToInt(data, 3, ref offset);
                FaceCheckCount = Utils.ByteToInt(data, 3, ref offset);
                PhoneOpenCount = Utils.ByteToInt(data, 3, ref offset);
                IdentityCardCheckCount = Utils.ByteToInt(data, 3, ref offset);
                RemoteTalkCount = Utils.ByteToInt(data, 3, ref offset);
                DayInCount = Utils.ByteToInt(data, 3, ref offset);
                HourInCount = Utils.ByteToInt(data, 2, ref offset);
                TotalOutCount = Utils.ByteToInt(data, 3, ref offset);
                DayOutCount = Utils.ByteToInt(data, 3, ref offset);
                HourOutCount = Utils.ByteToInt(data, 2, ref offset);
            }
        }
        /// <summary>
        /// 黑猫编号
        /// </summary>
        public byte CatCode { get; set; }
        /// <summary>
        /// 进：通行总人数（3个字节）
        /// </summary>
        public int? TotalInCount { get; set; }
        /// <summary>
        /// 刷IC卡人数：（3个字节）
        /// </summary>
        public int? IcPunchCount { get; set; }
        /// <summary>
        /// 人脸识别人数：（3个字节）
        /// </summary>
        public int? FaceCheckCount { get; set; }
        /// <summary>
        /// 手机开门人数：（3个字节）
        /// </summary>
        public int? PhoneOpenCount { get; set; }
        /// <summary>
        /// 刷身份证人数：（3个字节）
        /// </summary>
        public int? IdentityCardCheckCount { get; set; }
        /// <summary>
        /// 远程对讲人数 ：（3个字节）
        /// </summary>
        public int? RemoteTalkCount { get; set; }
        /// <summary>
        /// 每天通行人数（3个字节）
        /// </summary>
        public int? DayInCount { get; set; }
        /// <summary>
        /// 每小时通行人数（2个字节）
        /// </summary>
        public int? HourInCount { get; set; }
        /// <summary>
        /// 出：通行总人数（3个字节）
        /// </summary>
        public int? TotalOutCount { get; set; }
        /// <summary>
        /// 每天通行人数（3个字节）
        /// </summary>
        public int? DayOutCount { get; set; }
        /// <summary>
        /// 每小时通行人数（2个字节）
        /// </summary>
        public int? HourOutCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            List<byte> tmp = new List<byte>();
            tmp.Add(CatCode);
            tmp.AddRange(Utils.IntTo3ByteArray(TotalInCount ?? 0));
            tmp.AddRange(Utils.IntTo3ByteArray(IcPunchCount ?? 0));
            tmp.AddRange(Utils.IntTo3ByteArray(FaceCheckCount ?? 0));
            tmp.AddRange(Utils.IntTo3ByteArray(PhoneOpenCount ?? 0));
            tmp.AddRange(Utils.IntTo3ByteArray(IdentityCardCheckCount ?? 0));
            tmp.AddRange(Utils.IntTo3ByteArray(RemoteTalkCount ?? 0));
            tmp.AddRange(Utils.IntTo3ByteArray(DayInCount ?? 0));
            tmp.AddRange(Utils.IntTo3ByteArray(HourInCount ?? 0));
            tmp.AddRange(Utils.IntTo3ByteArray(TotalOutCount ?? 0));
            tmp.AddRange(Utils.IntTo3ByteArray(DayOutCount ?? 0));
            tmp.AddRange(Utils.IntTo3ByteArray(HourOutCount ?? 0));
            return tmp.ToArray();
        }
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <returns></returns>
        public static byte[] ReturnData(bool result)
        {
            return new ResponseBase<byte>(
                CmdCode.GetPeopleNumCMD,
                result ? Constant.ok : Constant.bad
                ).ToBytes();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="peopleNum"></param>
        /// <returns></returns>
        public bool Equals(GetPeopleNumCMD peopleNum)
        {
            if (peopleNum == null)
            {
                return false;
            }

            if (Encoding.Default.GetString(this.ToBytes()) ==
               Encoding.Default.GetString(peopleNum.ToBytes()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
