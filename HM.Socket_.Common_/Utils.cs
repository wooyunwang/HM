using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HM.Socket_.Common_
{
    public static class Utils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int ByteToInt(byte[] b)
        {
            int mask = 0xff;
            int temp = 0;
            int n = 0;
            for (int i = 0; i < b.Length; i++)
            {
                n <<= 8;
                temp = b[i] & mask;
                n |= temp;
            }
            return n;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int ByteToInt(byte[] b, int count, ref int offset)
        {
            int mask = 0xff;
            int temp = 0;
            int n = 0;
            for (int i = offset; i < offset + count; i++)
            {
                n <<= 8;
                temp = b[i] & mask;
                n |= temp;
            }
            //修改offset为下一次截取准备
            offset += count;
            return n;
        }

        /// <summary>
        /// 将字节答应成字符串
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string PrintByte(Byte[] cmd)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < cmd.Length; i++)
            {
                str.Append(cmd[i].ToString("X2"));
            }
            return str.ToString();
        }

        /// <summary>
        /// 将对象以Byte[]输出
        /// </summary>
        /// <returns></returns>
        public static byte[] ToBytes<T>(T data)
        {
            if (data is bool)
            {
                if (Convert.ToBoolean(data))
                {
                    return new byte[] { Constant.ok };
                }
                else
                {
                    return new byte[] { Constant.bad };
                }
            }
            if (data is byte)
            {
                return new byte[] { Convert.ToByte(data) };
            }
            else if (data is byte[])
            {
                return data as byte[];
            }
            else
            {
                //序列化
                string tmp = JsonConvert.SerializeObject(data);
                return Encoding.UTF8.GetBytes(tmp);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static byte[] IntToByteArray(int n)
        {
            byte[] b = new byte[4];
            b[3] = (byte)(n & 0xff);
            b[2] = (byte)(n >> 8 & 0xff);
            b[1] = (byte)(n >> 16 & 0xff);
            b[0] = (byte)(n >> 24 & 0xff);
            return b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static byte[] IntTo3ByteArray(int n)
        {
            byte[] b = new byte[3];
            b[2] = (byte)(n & 0xff);
            b[1] = (byte)(n >> 8 & 0xff);
            b[0] = (byte)(n >> 16 & 0xff);
            return b;
        }
        /// <summary>
        /// 扩展string的Contains
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static bool Contains(this string source, string value, StringComparison comparisonType)
        {
            return (source.IndexOf(value, comparisonType) >= 0);
        }
        /// <summary>
        /// 获取第一个IP值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetIP(string str)
        {
            Regex r = new Regex(@"((25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))");
            MatchCollection mCollection = r.Matches(str ?? "");
            return mCollection.Count > 0 ? mCollection[0].Value : string.Empty;
        }
        /// <summary>
        /// 提取中文括号中的内容
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetPingKey(string str)
        {
            str = str.Replace("(", "（").Replace(")", "）");
            Regex r = new Regex(@"（.*?）");
            MatchCollection mCollection = r.Matches(str ?? "");
            return mCollection.Count > 0 ? mCollection[0].Value.Replace("（", "").Replace("）", "") : string.Empty;
        }

        /// <summary>
        /// 与PrintByte相逆
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        /// <summary>
        /// 检查远程端口是否可连接
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool VisualTelnet(string ip, int port)
        {
            try
            {
                IPEndPoint point = new IPEndPoint(IPAddress.Parse(ip), port);
                using (Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    sock.Connect(point);
                    sock.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
