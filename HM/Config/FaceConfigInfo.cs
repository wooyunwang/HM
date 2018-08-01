using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM.Config
{
    /// <summary>
    /// 人脸配置
    /// </summary>
    [Serializable]
    public  class FaceConfigInfo
    {
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 延迟毫秒数
        /// </summary>
        public int DelayMillisecond { get; set; }
    }
}
