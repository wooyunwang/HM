using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HM.Utils_
{
    /// <summary>
    /// 本机服务类
    /// </summary>
    public class Local_
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uriNetPath"></param>
        /// <param name="port"></param>
        /// <param name="uriAuto"></param>
        /// <returns></returns>
        public static bool CheckNetPath(Uri uriNetPath, int port, ref Uri uriAuto)
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名  
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                if (IpEntry != null && IpEntry.AddressList != null)
                {
                    var address = IpEntry.AddressList.FirstOrDefault(it => it.AddressFamily == AddressFamily.InterNetwork && it.ToString() == uriNetPath.Host);
                    if (address != null)
                    {
                        uriAuto = new Uri("http://" + address.ToString() + ":" + port);
                        return true;
                    }
                    else
                    {
                        uriAuto = new Uri("http://" + GetLocalIP() + ":" + port);
                        return false;
                    }
                }
                else
                {
                    uriAuto = null;
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名  
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                if (IpEntry != null && IpEntry.AddressList != null)
                {
                    for (int i = 0; i < IpEntry.AddressList.Length; i++)
                    {
                        //从IP地址列表中筛选出IPv4类型的IP地址  
                        //AddressFamily.InterNetwork表示此IP为IPv4,  
                        //AddressFamily.InterNetworkV6表示此地址为IPv6类型  
                        if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                        {
                            return IpEntry.AddressList[i].ToString();
                        }
                    }
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        ///// <summary>  
        ///// 获取当前使用的IP  
        ///// </summary>  
        ///// <returns></returns>  
        //public static string GetLocalIP()
        //{
        //    string result = RunApp("route", "print", true);
        //    Match m = Regex.Match(result, @"0.0.0.0\s+0.0.0.0\s+(\d+.\d+.\d+.\d+)\s+(\d+.\d+.\d+.\d+)");
        //    if (m.Success)
        //    {
        //        return m.Groups[2].Value;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            System.Net.Sockets.TcpClient c = new System.Net.Sockets.TcpClient();
        //            c.Connect("www.baidu.com", 80);
        //            string ip = ((System.Net.IPEndPoint)c.Client.LocalEndPoint).Address.ToString();
        //            c.Close();
        //            return ip;
        //        }
        //        catch (Exception)
        //        {
        //            return null;
        //        }
        //    }
        //}

        /// <summary>  
        /// 获取本机主DNS  
        /// </summary>  
        /// <returns></returns>  
        public static string GetPrimaryDNS()
        {
            string result = RunApp("nslookup", "", true);
            Match m = Regex.Match(result, @"\d+\.\d+\.\d+\.\d+");
            if (m.Success)
            {
                return m.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>  
        /// 运行一个控制台程序并返回其输出参数。  
        /// </summary>  
        /// <param name="filename">程序名</param>  
        /// <param name="arguments">输入参数</param>  
        /// <returns></returns>  
        public static string RunApp(string filename, string arguments, bool recordLog)
        {
            try
            {
                if (recordLog)
                {
                    Trace.WriteLine(filename + " " + arguments);
                }
                Process proc = new Process();
                proc.StartInfo.FileName = filename;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();

                using (System.IO.StreamReader sr = new System.IO.StreamReader(proc.StandardOutput.BaseStream, Encoding.Default))
                {
                    //string txt = sr.ReadToEnd();  
                    //sr.Close();  
                    //if (recordLog)  
                    //{  
                    //    Trace.WriteLine(txt);  
                    //}  
                    //if (!proc.HasExited)  
                    //{  
                    //    proc.Kill();  
                    //}  
                    //上面标记的是原文，下面是我自己调试错误后自行修改的  
                    Thread.Sleep(100);           //貌似调用系统的nslookup还未返回数据或者数据未编码完成，程序就已经跳过直接执行  
                    //txt = sr.ReadToEnd()了，导致返回的数据为空，故睡眠令硬件反应  
                    if (!proc.HasExited)         //在无参数调用nslookup后，可以继续输入命令继续操作，如果进程未停止就直接执行  
                    {                            //txt = sr.ReadToEnd()程序就在等待输入，而且又无法输入，直接掐住无法继续运行  
                        proc.Kill();
                    }
                    string txt = sr.ReadToEnd();
                    sr.Close();
                    if (recordLog)
                        Trace.WriteLine(txt);
                    return txt;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return ex.Message;
            }
        }
    }
}
