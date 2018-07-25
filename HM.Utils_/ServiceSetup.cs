using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Configuration.Install;
using Microsoft.Win32;
namespace HM.Utils_
{
    /// <summary>
    /// 服务控制类
    /// </summary>
    public class ServiceSetup : ServiceController
    {
        public ServiceSetup(string p_Name)
            : base(p_Name)
        {
        }
        public string FilePath
        {
            get
            {
                RegistryKey localMachineRegistry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                    Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);

                RegistryKey _Key = localMachineRegistry.OpenSubKey(@"SYSTEM\ControlSet001\Services\" + base.ServiceName);
                if (_Key != null)
                {
                    object _ObjPath = _Key.GetValue("ImagePath");
                    if (_ObjPath != null) return _ObjPath.ToString().Trim('"');
                }
                return "";
            }
        }
        public string Description
        {
            get
            {
                RegistryKey _Key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Services\" + base.ServiceName);
                if (_Key != null)
                {
                    object _ObjPath = _Key.GetValue("Description");
                    if (_ObjPath != null) return _ObjPath.ToString().Trim('"');
                }
                return "";
            }
        }
        /// <summary>
        /// 卸载服务
        /// </summary>
        /// <param name="p_Path">指定服务文件路径</param>           
        /// <returns>卸载信息 正确卸载返回""</returns>
        public static string UnInsertService(string p_Path)
        {
            if (!File.Exists(p_Path)) return "文件不存在！";
            FileInfo _InsertFile = new FileInfo(p_Path);
            IDictionary _SavedState = new Hashtable();
            try
            {
                AssemblyInstaller _AssemblyInstaller = new AssemblyInstaller(p_Path, new string[] { "/LogFile=" + _InsertFile.DirectoryName + "//" + _InsertFile.Name.Substring(0, _InsertFile.Name.Length - _InsertFile.Extension.Length) + ".log" });
                _AssemblyInstaller.UseNewContext = true;
                _AssemblyInstaller.Uninstall(_SavedState);
                _AssemblyInstaller.Commit(_SavedState);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 安装服务
        /// </summary>
        /// <param name="p_Path">指定服务文件路径</param>
        /// <param name="p_ServiceName">返回安装完成后的服务名</param>
        /// <returns>安装信息 正确安装返回""</returns>
        public static string InsertService(string p_Path, ref string p_ServiceName)
        {
            if (!File.Exists(p_Path)) return "文件不存在！";
            p_ServiceName = "";
            FileInfo _InsertFile = new FileInfo(p_Path);
            IDictionary _SavedState = new Hashtable();
            try
            {
                AssemblyInstaller _AssemblyInstaller = new AssemblyInstaller(p_Path, new string[] { "/LogFile=" + _InsertFile.DirectoryName + "//" + _InsertFile.Name.Substring(0, _InsertFile.Name.Length - _InsertFile.Extension.Length) + ".log" });
                _AssemblyInstaller.UseNewContext = true;
                _AssemblyInstaller.Install(_SavedState);
                _AssemblyInstaller.Commit(_SavedState);
                Type[] _TypeList = _AssemblyInstaller.Assembly.GetTypes();
                for (int i = 0; i != _TypeList.Length; i++)
                {
                    if (_TypeList[i].BaseType.FullName == "System.Configuration.Install.Installer")
                    {
                        object _InsertObject = System.Activator.CreateInstance(_TypeList[i]);
                        FieldInfo[] _FieldList = _TypeList[i].GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                        for (int z = 0; z != _FieldList.Length; z++)
                        {
                            if (_FieldList[z].FieldType.FullName == "System.ServiceProcess.ServiceInstaller")
                            {
                                object _ServiceInsert = _FieldList[z].GetValue(_InsertObject);
                                if (_ServiceInsert != null)
                                {
                                    p_ServiceName = ((ServiceInstaller)_ServiceInsert).ServiceName;
                                    return "";
                                }
                            }
                        }
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 获取服务指定列表（设备启动除外）
        /// </summary>
        /// <returns></returns>
        public static IList<ServiceSetup> GetServicesInfo()
        {
            IList<ServiceSetup> _List = new List<ServiceSetup>();
            ServiceController[] _ServiceList = ServiceController.GetServices();
            for (int i = 0; i != _ServiceList.Length; i++)
            {
                _List.Add(new ServiceSetup(_ServiceList[i].ServiceName));
            }
            return _List;
        }
        /// <summary>
        /// 获取设备驱动服务
        /// </summary>
        /// <returns></returns>
        public static IList<ServiceSetup> GetDevicesInfo()
        {
            IList<ServiceSetup> _List = new List<ServiceSetup>();
            ServiceController[] _ServiceList = ServiceController.GetDevices();
            for (int i = 0; i != _ServiceList.Length; i++)
            {
                _List.Add(new ServiceSetup(_ServiceList[i].ServiceName));
            }
            return _List;
        }
    }
}
