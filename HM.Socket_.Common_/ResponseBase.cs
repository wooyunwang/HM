using System;

namespace HM.Socket_.Common_
{
    /// <summary>
    /// 响应基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseBase<T>
    {
        public ResponseBase(CmdCode responseCode, T data)
        {
            Symbol = Constant.VKHM;
            ResponsCmd = BitConverter.GetBytes((byte)responseCode);
        }
        /// <summary>
        /// 符号; 象征; 标志; 记号;
        /// </summary>
        private byte[] Symbol { get; set; }
        /// <summary>
        /// 响应命令
        /// </summary>
        private byte[] ResponsCmd { get; set; }
        /// <summary>
        /// 返回编码
        /// </summary>
        public T ReturnCode { get; set; }

        /// <summary>
        /// 将对象以Byte[]输出
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            //若是byte[]数组，则直接赋值
            byte[] dataBytes = Utils.ToBytes(ReturnCode);
            byte[] allData = new byte[Symbol.Length + ResponsCmd.Length + dataBytes.Length];
            int count = 0;
            Buffer.BlockCopy(Symbol, 0, allData, count, Symbol.Length);
            count += Symbol.Length;
            Buffer.BlockCopy(ResponsCmd, 0, allData, count, ResponsCmd.Length);
            count += ResponsCmd.Length;
            Buffer.BlockCopy(dataBytes, 0, allData, count, dataBytes.Length);
            return allData;
        }
    }
}
