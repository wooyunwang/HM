using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace HM.Utils_
{
    public class Version_
    {
        public static Version GetVersion()
        {
            return Assembly.GetEntryAssembly().GetName().Version;
        }

        public static FileVersionInfo GetFileVersionInfo()
        {
            //typeof(Program).GetTypeInfo().Assembly;
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            return FileVersionInfo.GetVersionInfo(assembly.Location);
        }
    }
}
