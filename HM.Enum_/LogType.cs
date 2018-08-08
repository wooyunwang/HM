﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Enum_
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default,
        /// <summary>
        /// Socket客户端
        /// </summary>
        SocketClient,
        /// <summary>
        /// Socket服务端
        /// </summary>
        SocketServer,
        /// <summary>
        /// 连接日志
        /// </summary>
        Connect,
        /// <summary>
        /// 任务日志
        /// </summary>
        Job,
        /// <summary>
        /// 输入输出日志
        /// </summary>
        InputOutput,
        /// <summary>
        /// 时间日志
        /// </summary>
        Stopwatch
    }
}
