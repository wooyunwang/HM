using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common
{
    /// <summary>
    /// 请求基类
    /// +------------+-------------+------------+------------+ 
    /// |协议开始标志|   数据长度  |    数据    |   结束符   |
    /// +------------+-------------+------------+------------+
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RequestBase<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="commandCode"></param>
        /// <param name="data"></param>
        /// <param name="packNum">
        /// 用于接收的时候传入使用,packNum无需再根据data重新计算
        /// </param>
        public RequestBase(CmdCode commandCode, T data, byte[] packNum = null)
        {
            RequestBase_Inner(Constant.VKHM, commandCode, data, packNum);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="commandCode"></param>
        /// <param name="data"></param>
        /// <param name="packNum">
        /// 用于接收的时候传入使用,packNum无需再根据data重新计算
        /// </param>
        public RequestBase(byte[] symbol, CmdCode commandCode, T data, byte[] packNum = null)
        {
            RequestBase_Inner(symbol, commandCode, data, packNum);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="commandCode"></param>
        /// <param name="data"></param>
        /// <param name="packNum"></param>
        private void RequestBase_Inner(byte[] symbol, CmdCode commandCode, T data, byte[] packNum = null)
        {
            Key = commandCode.ToString();
            CmdCode = commandCode;
            Symbol = symbol;
            Command = new byte[] { (byte)commandCode };
            Data = data;
            //转换
            DataBytes = Utils.ToBytes(Data);
            //计算长度
            PackNum = packNum ?? Utils.IntToByteArray(DataBytes.Length + Constant.postamble.Length);
            Postamble = Constant.postamble;
        }
        #region 属性
        /// <summary>
        /// 符号; 象征; 标志; 记号;【4字节】
        /// 
        /// </summary>
        public byte[] Symbol { get; protected set; }
        /// <summary>
        /// CmdCode
        /// </summary>
        public CmdCode CmdCode { get; protected set; }
        /// <summary>
        /// 键 = CmdCode.ToString()
        /// </summary>
        public string Key { get; protected set; }
        /// <summary>
        /// 响应命令【1字节】
        /// </summary>
        public byte[] Command { get; protected set; }
        /// <summary>
        /// 包数据长度【4字节】
        /// </summary>
        public byte[] PackNum { get; protected set; }
        /// <summary>
        /// 传输数据【不定长字节】
        /// </summary>
        public T Data { get; protected set; }
        /// <summary>
        /// 由Data转化而来（只在构造的时候处理）
        /// </summary>
        public byte[] DataBytes { get; private set; }
        /// <summary>
        /// 后同步信号【1字节】
        /// </summary>
        public byte[] Postamble { get; protected set; }
        #endregion
        /// <summary>
        /// 将对象以Byte[]输出
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            byte[] allData = new byte[Symbol.Length + Command.Length + PackNum.Length + DataBytes.Length + Postamble.Length];
            int dstOffset = 0;
            Buffer.BlockCopy(Symbol, 0, allData, dstOffset, Symbol.Length);
            dstOffset += Symbol.Length;
            Buffer.BlockCopy(Command, 0, allData, dstOffset, Command.Length);
            dstOffset += Command.Length;
            Buffer.BlockCopy(PackNum, 0, allData, dstOffset, PackNum.Length);
            dstOffset += PackNum.Length;
            Buffer.BlockCopy(DataBytes, 0, allData, dstOffset, DataBytes.Length);
            dstOffset += DataBytes.Length;
            Buffer.BlockCopy(Postamble, 0, allData, dstOffset, Postamble.Length);
            return allData;
        }

    }
}
