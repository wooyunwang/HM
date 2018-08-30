using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HM.Utils_
{
    public class NetWork_
    {
        /// <summary>
        /// 检查远程端口是否可连接
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool VisualTelnet(string ip, int port)
        {
            int millisecondsTimeout = 200;//等待时间
            TcpClient client = new TcpClient();
            try
            {
                var ar = client.BeginConnect(ip, port, null, null);
                ar.AsyncWaitHandle.WaitOne(millisecondsTimeout);
                return client.Connected;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                client.Close();
            }
        }
    }
}
