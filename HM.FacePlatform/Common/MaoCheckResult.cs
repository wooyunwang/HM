using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.FacePlatform
{
    public class MaoCheckResult
    {
        public MaoCheckResult()
        {
            GoodMaos = new List<Mao>();
            BadMaos = new List<Mao>();
        }
        /// <summary>
        /// Telnet正常的猫
        /// </summary>
        public List<Mao> GoodMaos { get; set; }
        /// <summary>
        /// Telnet不正常的猫
        /// </summary>
        public List<Mao> BadMaos { get; set; }
    }
}
