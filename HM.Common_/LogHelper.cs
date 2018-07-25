using System;
using System.Collections;
using System.Collections.Generic;

namespace HM.Common_
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
        /// 接收日志
        /// </summary>
        Recive,
        /// <summary>
        /// 连接日志
        /// </summary>
        Connect,
        /// <summary>
        /// 任务日志
        /// </summary>
        Job
    }
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LogLevel
    {
        Error,
        Debug,
        Warning,
        Info
    }
    /// <summary>
    /// 日志记录服务
    /// </summary>
    public partial class LogHelper
    {
        private static Dictionary<string, log4net.ILog> _DicILog = new Dictionary<string, log4net.ILog>();

        public static log4net.ILog GetIlog(LogType? logType = null)
        {
            string key = (logType ?? LogType.Default).ToString();
            if (!_DicILog.ContainsKey(key))
            {
                _DicILog.Add(key, log4net.LogManager.GetLogger(key));
            }
            return _DicILog[key];
        }

        /// <summary>
        /// 输出错误级别日志
        /// </summary>
        /// <param name="message">输出的消息</param>
        public static void Error(string message)
        {
            GetIlog().Error(message);
        }
        /// <summary>
        /// 输出错误级别日志
        /// </summary>
        /// <param name="ex">异常</param>
        public static void Error(Exception ex)
        {
            GetIlog().Error(ex);
        }
        /// <summary>
        /// 输出错误级别日志
        /// </summary>
        /// <param name="message">输出的消息</param>
        /// <param name="ex">异常</param>
        public static void Error(string message, Exception ex)
        {
            GetIlog().Error(message, ex);
        }

        /// <summary>
        /// 输出警告级别日志
        /// </summary>
        /// <param name="message">输出的消息</param>
        public static void Warning(string message)
        {
            GetIlog().Warn(message);
        }

        /// <summary>
        /// 输出信息级别日志
        /// </summary>
        /// <param name="message">输出的消息</param>
        public static void Info(string message)
        {
            GetIlog().Info(message);
        }
        /// <summary>
        /// 输出调试级别日志
        /// </summary>
        /// <param name="message">输出的消息</param>
        public static void Debug(string message)
        {
            GetIlog().Debug(message);
        }
    }
}

