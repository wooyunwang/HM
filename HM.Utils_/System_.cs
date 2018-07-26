using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
namespace HM.Utils_
{
    public class System_
    {
        /// <summary>
        /// 获取本地ip地址，多个ip
        /// </summary>
        public static String[] GetLocalIpAddress()
        {
            string hostName = Dns.GetHostName();                    //获取主机名称
            IPAddress[] addresses = Dns.GetHostAddresses(hostName); //解析主机IP地址
            string[] IP = new string[addresses.Length];             //转换为字符串形式
            for (int i = 0; i < addresses.Length; i++) IP[i] = addresses[i].ToString();
            return IP;
        }
        //从网站"http://1111.ip138.com/ic.asp"，获取本机外网ip地址信息串
        //"<html>\r\n<head>\r\n<meta http-equiv=\"content-type\" content=\"text/html; charset=gb2312\">\r\n<title> 
        //您的IP地址 </title>\r\n</head>\r\n<body style=\"margin:0px\"><center>您的IP是：[218.104.71.178] 来自：安徽省合肥市 联通</center></body></html>"
        /// <summary>
        /// 获取外网ip地址
        /// </summary>
        public static string[] GetExtenalIpAddress()
        {
            string[] IP = new string[] { "未获取到外网ip", "" };
            string address = "http://1111.ip138.com/ic.asp";
            string str = GetWebStr(address);
            try
            {
                //提取外网ip数据 [218.104.71.178]
                int i1 = str.IndexOf("[") + 1, i2 = str.IndexOf("]");
                IP[0] = str.Substring(i1, i2 - i1);
                //提取网址说明信息 "来自：安徽省合肥市 联通"
                i1 = i2 + 2; i2 = str.IndexOf("<", i1);
                IP[1] = str.Substring(i1, i2 - i1);
            }
            catch (Exception) { }
            return IP;
        }
        /// <summary>
        /// 获取网址address的返回的文本串数据
        /// </summary>
        public static string GetWebStr(string address)
        {
            string str = "";
            try
            {
                //从网址中获取本机ip数据
                System.Net.WebClient client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.Default;
                str = client.DownloadString(address);
                client.Dispose();
            }
            catch (Exception) { }
            return str;
        }
        /// <summary>
        /// 获取本机的MAC;
        /// </summary>
        public static string GetLocalMac()
        {
            string mac = null;
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac = mo["MacAddress"].ToString();
            }
            return (mac);
        }
        //只能获取同网段的远程主机MAC地址. 因为在标准网络协议下，ARP包是不能跨网段传输的，故想通过ARP协议是无法查询跨网段设备MAC地址的。
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);
        /// <summary>
        /// 获取ip对应的MAC地址
        /// </summary>
        public static string GetMacAddress(string ip)
        {
            Int32 ldest = inet_addr(ip);            //目的ip 
            Int32 lhost = inet_addr("127.0.0.1");   //本地ip 
            try
            {
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);  //使用系统API接口发送ARP请求，解析ip对应的Mac地址
                return Convert.ToString(macinfo, 16);
            }
            catch (Exception err)
            {
                Console.WriteLine("Error:{0}", err.Message);
            }
            return "获取Mac地址失败";
        }
        /// <summary>
        /// 获取主板序列号
        /// </summary>
        /// <returns></returns>
        public static string GetBIOSSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_BIOS");
                string sBIOSSerialNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    sBIOSSerialNumber = mo["SerialNumber"].ToString().Trim();
                }
                return sBIOSSerialNumber;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        /// <returns></returns>
        public static string GetCPUSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Processor");
                string sCPUSerialNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    sCPUSerialNumber = mo["ProcessorId"].ToString().Trim();
                }
                return sCPUSerialNumber;
            }
            catch
            {
                return "";
            }
        }
        //获取硬盘序列号
        public static string GetHardDiskSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                string sHardDiskSerialNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    sHardDiskSerialNumber = mo["SerialNumber"].ToString().Trim();
                    break;
                }
                return sHardDiskSerialNumber;
            }
            catch
            {
                return "";
            }
        }
        //获取网卡地址
        public static string GetNetCardMACAddress()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE ((MACAddress Is Not NULL) AND (Manufacturer <> 'Microsoft'))");
                string NetCardMACAddress = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    NetCardMACAddress = mo["MACAddress"].ToString().Trim();
                }
                return NetCardMACAddress;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获得CPU编号
        /// </summary>
        public static string GetCPUID()
        {
            string cpuid = "";
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuid = mo.Properties["ProcessorId"].Value.ToString();
            }
            return cpuid;
        }
        /// <summary>
        /// 获取硬盘序列号
        /// </summary>
        public static string GetDiskSerialNumber()
        {
            //这种模式在插入一个U盘后可能会有不同的结果，如插入我的手机时
            String HDid = "";
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                HDid = (string)mo.Properties["Model"].Value;//SerialNumber
                break;//这名话解决有多个物理盘时产生的问题，只取第一个物理硬盘
            }
            return HDid;
            /*ManagementClass mc = new ManagementClass("Win32_PhysicalMedia");
            ManagementObjectCollection moc = mc.GetInstances();
            string str = "";
            foreach (ManagementObject mo in moc)
            {
                str = mo.Properties["SerialNumber"].Value.ToString();
                break;
            }
            return str;*/
        }
        /// <summary>
        /// 获取网卡硬件地址
        /// </summary>
        public static string GetMacAddress()
        {
            string mac = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    mac = mo["MacAddress"].ToString();
                    break;
                }
            }
            return mac;
        }
        /// <summary>
        /// 获取IP地址
        /// </summary>
        public static string GetIPAddress()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    //st=mo["IpAddress"].ToString(); 
                    System.Array ar;
                    ar = (System.Array)(mo.Properties["IpAddress"].Value);
                    st = ar.GetValue(0).ToString();
                    break;
                }
            }
            return st;
        }
        /// <summary>
        /// 操作系统的登录用户名
        /// </summary>
        public static string GetUserName()
        {
            return Environment.UserName;
        }
        /// <summary>
        /// 获取计算机名
        /// </summary>
        public static string GetComputerName()
        {
            return Environment.MachineName;
        }
        /// <summary>
        /// 操作系统类型
        /// </summary>
        public static string GetSystemType()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["SystemType"].ToString();
            }
            return st;
        }
        /// <summary>
        /// 物理内存
        /// </summary>
        public static string GetPhysicalMemory()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["TotalPhysicalMemory"].ToString();
            }
            return st;
        }
        #region 可用内存
        ///  
        /// 获取可用内存 
        ///  
        public static long MemoryAvailable
        {
            get
            {
                long availablebytes = 0;
                //ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_PerfRawData_PerfOS_Memory"); 
                //foreach (ManagementObject mo in mos.Get()) 
                //{ 
                //    availablebytes = long.Parse(mo["Availablebytes"].ToString()); 
                //} 
                ManagementClass mos = new ManagementClass("Win32_OperatingSystem");
                foreach (ManagementObject mo in mos.GetInstances())
                {
                    if (mo["FreePhysicalMemory"] != null)
                    {
                        availablebytes = 1024 * long.Parse(mo["FreePhysicalMemory"].ToString());
                    }
                }
                return availablebytes;
            }
        }
        #endregion
        #region 物理内存
        ///  
        /// 获取物理内存 
        ///  
        public static long PhysicalMemory
        {
            get
            {
                long m_PhysicalMemory = 0;
                //获得物理内存 
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if (mo["TotalPhysicalMemory"] != null)
                    {
                        m_PhysicalMemory = long.Parse(mo["TotalPhysicalMemory"].ToString());
                    }
                }
                return m_PhysicalMemory;
            }
        }
        #endregion
        /// <summary>
        /// 显卡PNPDeviceID
        /// </summary>
        public static string GetVideoPNPID()
        {
            string st = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_VideoController");
            foreach (ManagementObject mo in mos.Get())
            {
                st = mo["PNPDeviceID"].ToString();
            }
            return st;
        }
        /// <summary>
        /// 声卡PNPDeviceID
        /// </summary>
        public static string GetSoundPNPID()
        {
            string st = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_SoundDevice");
            foreach (ManagementObject mo in mos.Get())
            {
                st = mo["PNPDeviceID"].ToString();
            }
            return st;
        }
        /// <summary>
        /// CPU版本信息
        /// </summary>
        public static string GetCPUVersion()
        {
            string st = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_Processor");
            foreach (ManagementObject mo in mos.Get())
            {
                st = mo["Version"].ToString();
            }
            return st;
        }
        /// <summary>
        /// CPU名称信息
        /// </summary>
        public static string GetCPUName()
        {
            string st = "";
            ManagementObjectSearcher driveID = new ManagementObjectSearcher("Select * from Win32_Processor");
            foreach (ManagementObject mo in driveID.Get())
            {
                st = mo["Name"].ToString();
            }
            return st;
        }
        /// <summary>
        /// CPU制造厂商
        /// </summary>
        public static string GetCPUManufacturer()
        {
            string st = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_Processor");
            foreach (ManagementObject mo in mos.Get())
            {
                st = mo["Manufacturer"].ToString();
            }
            return st;
        }
        /// <summary>
        /// 主板制造厂商
        /// </summary>
        public static string GetBoardManufacturer()
        {
            SelectQuery query = new SelectQuery("Select * from Win32_BaseBoard");
            ManagementObjectSearcher mos = new ManagementObjectSearcher(query);
            ManagementObjectCollection.ManagementObjectEnumerator data = mos.Get().GetEnumerator();
            data.MoveNext();
            ManagementBaseObject board = data.Current;
            return board.GetPropertyValue("Manufacturer").ToString();
        }
        /// <summary>
        /// 主板编号
        /// </summary>
        public static string GetBoardID()
        {
            string st = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_BaseBoard");
            foreach (ManagementObject mo in mos.Get())
            {
                st = mo["SerialNumber"].ToString();
            }
            return st;
        }
        /// <summary>
        /// 主板型号
        /// </summary>
        public static string GetBoardType()
        {
            string st = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_BaseBoard");
            foreach (ManagementObject mo in mos.Get())
            {
                st = mo["Product"].ToString();
            }
            return st;
        }
        internal enum WmiType
        {
            Win32_Processor,
            Win32_PerfFormattedData_PerfOS_Memory,
            Win32_PhysicalMemory,
            Win32_NetworkAdapterConfiguration,
            Win32_LogicalDisk
        }
        /// <summary>
        /// 如果硬盘空闲空间小于1.5G报警
        /// </summary>
        /// <returns></returns>
        public static string HardDiskAlarm()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            StringBuilder sr = new StringBuilder();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    var val1 = (double)drive.TotalSize / 1024 / 1024;
                    var val2 = (double)drive.TotalFreeSpace / 1024 / 1024;
                    if (val2 < 1500)
                        sr.Append("磁盘空间不足：" + drive.Name + " 剩余空间：" + val2 + " MB");
                }
            }
            return sr.ToString();
        }
        public static string ProcessAlarm(List<String> processs)
        {
            StringBuilder sr = new StringBuilder();
            bool isexist = false;
            foreach (String process in processs)
            {
                isexist = false;
                Process[] pcs = Process.GetProcesses();
                foreach (Process instance in pcs)
                {
                    if (process == instance.ProcessName)
                    {
                        isexist = true;
                        continue;
                    }
                }
                if (isexist == false)
                    sr.Append("进程报警：" + process + " 不存在");
            }
            return sr.ToString();
        }
        public static string HardDiskInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            StringBuilder sr = new StringBuilder();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    var TotalSize = (double)drive.TotalSize / 1024 / 1024;
                    var TotalFreeSpace = (double)drive.TotalFreeSpace / 1024 / 1024;
                    sr.AppendFormat("{0}({1})/共{2}MB",
                        drive.Name,
                        drive.DriveFormat,
                        (long)TotalSize
                     );
                }
            }
            return sr.ToString();
        }
        /// <summary>
        /// 获取操作系统信息
        /// </summary>
        /// <returns></returns>
        public static dynamic OSInfo()
        {
            return new
            {
                机器名 = Environment.MachineName,
                操作系统 = Environment.OSVersion,
                系统文件夹 = Environment.SystemDirectory,
                语言 = CultureInfo.InstalledUICulture.EnglishName,
                DOTNET = Environment.Version,
                当前目录 = Environment.CurrentDirectory,
                当前用户 = Environment.UserName
            };
        }
        public static void UsingProcess(string pname)
        {
            using (var pro = Process.GetProcessesByName(pname)[0])
            {
                //间隔时间（毫秒）
                int interval = 1000;
                //上次记录的CPU时间
                var prevCpuTime = TimeSpan.Zero;
                while (true)
                {
                    //当前时间
                    var curTime = pro.TotalProcessorTime;
                    //间隔时间内的CPU运行时间除以逻辑CPU数量
                    var value = (curTime - prevCpuTime).TotalMilliseconds / interval / Environment.ProcessorCount * 100;
                    prevCpuTime = curTime;
                    //输出
                    Console.WriteLine(value);
                    Thread.Sleep(interval);
                }
            }
        }
        #region 获得进程列表
        /////  
        ///// 获得进程列表 
        /////  
        //public static List GetProcessInfo()
        //{
        //    List pInfo = new List();
        //    Process[] processes = Process.GetProcesses();
        //    foreach (Process instance in processes)
        //    {
        //        try
        //        {
        //            pInfo.Add(new ProcessInfo(instance.Id,
        //                instance.ProcessName,
        //                instance.TotalProcessorTime.TotalMilliseconds,
        //                instance.WorkingSet64,
        //                instance.MainModule.FileName));
        //        }
        //        catch { }
        //    }
        //    return pInfo;
        //}
        /////  
        ///// 获得特定进程信息 
        /////  
        ///// 进程名称 
        //public static List<ProcessInfo> GetProcessInfo(string ProcessName)
        //{
        //    List<ProcessInfo> pInfo = new List<ProcessInfo>();
        //    Process[] processes = Process.GetProcessesByName(ProcessName);
        //    foreach (Process instance in processes)
        //    {
        //        try
        //        {
        //            pInfo.Add(new ProcessInfo(instance.Id,
        //                instance.ProcessName,
        //                instance.TotalProcessorTime.TotalMilliseconds,
        //                instance.WorkingSet64,
        //                instance.MainModule.FileName));
        //        }
        //        catch { }
        //    }
        //    return pInfo;
        //}
        #endregion
        #region 结束指定进程
        public static void EndProcess(int pid)
        {
            try
            {
                Process process = Process.GetProcessById(pid);
                process.Kill();
            }
            catch { }
        }
        #endregion
        //static Dictionary<string, ManagementObjectCollection> WmiDict = new Dictionary<string, ManagementObjectCollection>();
        //static MachineNumber()
        //{
        //    var names = Enum.GetNames(typeof(WmiType));
        //    foreach (string name in names)
        //    {
        //        WmiDict.Add(name, new ManagementObjectSearcher("SELECT * FROM " + name).Get());
        //    }
        //}
        ///// <summary>
        ///// 获取网卡信息
        ///// </summary>
        ///// <returns></returns>
        //public static string NetworkInfo()
        //{
        //    StringBuilder sr = new StringBuilder();
        //    string host = Dns.GetHostName();
        //    IPHostEntry ipEntry = Dns.GetHostByName(host);
        //    sr.Append("IPv4:" + ipEntry.AddressList[0] + "/");
        //    sr.Append("IPv6:");
        //    ipEntry = Dns.GetHostEntry(host);
        //    sr.Append("IPv6:" + ipEntry.AddressList[0] + ";");
        //    sr.Append("MAC:");
        //    var query = WmiDict[WmiType.Win32_NetworkAdapterConfiguration.ToString()];
        //    foreach (var obj in query)
        //    {
        //        if (obj["IPEnabled"].ToString() == "True")
        //            sr.Append(obj["MacAddress"] + ";");
        //    }
        //    return sr.ToString();
        //}
        ///// <summary>
        ///// 获取内存信息
        ///// </summary>
        ///// <returns></returns>
        //public static string MemoryInfo()
        //{
        //    StringBuilder sr = new StringBuilder();
        //    long capacity = 0;
        //    var query = WmiDict[WmiType.Win32_PhysicalMemory.ToString()];
        //    int index = 1;
        //    foreach (var obj in query)
        //    {
        //        sr.Append("内存" + index + "频率:" + obj["ConfiguredClockSpeed"] + ";");
        //        capacity += Convert.ToInt64(obj["Capacity"]);
        //        index++;
        //    }
        //    sr.Append("总物理内存:");
        //    sr.Append(capacity / 1024 / 1024 + "MB;");
        //    query = WmiDict[WmiType.Win32_PerfFormattedData_PerfOS_Memory.ToString()];
        //    sr.Append("总可用内存:");
        //    long available = 0;
        //    foreach (var obj in query)
        //    {
        //        available += Convert.ToInt64(obj.Properties["AvailableMBytes"].Value);
        //    }
        //    sr.Append(available + "MB;");
        //    sr.AppendFormat("{0:F2}%可用; ", (double)available / (capacity / 1024 / 1024) * 100);
        //    return sr.ToString();
        //}
    }
}
