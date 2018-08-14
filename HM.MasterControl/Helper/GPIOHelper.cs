using HM.Common_;
using HM.Enum_;
using HM.Socket_.Common_;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace HM.MasterControl.Helper
{
    /// <summary>
    /// 串口数据位列表（5,6,7,8）
    /// </summary>
    public enum SerialPortDatabits : int
    {
        FiveBits = 5,
        SixBits = 6,
        SeventBits = 7,
        EightBits = 8
    }
    /// <summary>
    /// 串口波特率列表。
    /// 75,110,150,300,600,1200,2400,4800,9600,14400,19200,28800,38400,56000,57600,
    /// 115200,128000,230400,256000
    /// </summary>
    public enum SerialPortBaudRates : int
    {
        BaudRate_75 = 75,
        BaudRate_110 = 110,
        BaudRate_150 = 150,
        BaudRate_300 = 300,
        BaudRate_600 = 600,
        BaudRate_1200 = 1200,
        BaudRate_2400 = 2400,
        BaudRate_4800 = 4800,
        BaudRate_9600 = 9600,
        BaudRate_14400 = 14400,
        BaudRate_19200 = 19200,
        BaudRate_28800 = 28800,
        BaudRate_38400 = 38400,
        BaudRate_56000 = 56000,
        BaudRate_57600 = 57600,
        BaudRate_115200 = 115200,
        BaudRate_128000 = 128000,
        BaudRate_230400 = 230400,
        BaudRate_256000 = 256000
    }
    /// <summary>
    /// GPIO板帮助类
    /// </summary>
    public class GPIOHelper
    {
        #region 属性
        /// <summary>
        /// GPIO板连接的串行端口资源
        /// </summary>
        SerialPort _GPIOSerialPort { get; set; }
        #endregion
        #region 事件
        /// <summary>
        /// 状态变化事件
        /// </summary>
        public Action<In_Port_Info, GPIOLevelEnum> OnStatusChanged { get; set; }
        /// <summary>
        /// 消息事件
        /// </summary>
        public Action<string, string> OnMessage { get; set; }
        /// <summary>
        /// 成功事件
        /// </summary>
        public Action<UInt32?> OnSuccess { get; set; }
        /// <summary>
        /// 失败事件
        /// </summary>
        public Action<object> OnFail { get; set; }
        #endregion
        #region 初始化与数据接收
        /// <summary>
        /// 初始化IO板通讯
        /// </summary>
        /// <param name="com"></param>
        public void Init(string com)
        {
            if (SerialPort.GetPortNames()?.Any(it => it == com) ?? false)
            {
                GPIO_UART_Init(com);
                lock (_SetLock)
                {
                    _SetCmds.Enqueue("SETGPIO=0x00");
                }
            }
            else
            {
                OnMessage?.Invoke("COMERROR", "串口" + com + "未正确连接或者接触不良！");
            }
        }
        /// <summary>
        /// 初始化IO板通讯
        /// </summary>
        /// <param name="com"></param>
        void GPIO_UART_Init(string com)
        {
            _GPIOSerialPort = new SerialPort(com, (int)SerialPortBaudRates.BaudRate_57600, Parity.None, (int)SerialPortDatabits.EightBits, StopBits.One);
            if (_GPIOSerialPort.IsOpen) _GPIOSerialPort.Close();
            //_GPIOSerialPort.ReadTimeout = 50;
            //添加事件注册  
            _GPIOSerialPort.DataReceived += GPIO_DataReceived;
            _GPIOSerialPort.ReceivedBytesThreshold = 2;
            try
            {
                _GPIOSerialPort.Open();
            }
            catch (Exception ex)
            {
                OnMessage?.Invoke("ERROR", ex.Message);
            }
        }
        /// <summary>
        /// GPIO板数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GPIO_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string GPIOReadBuffer = "";
            try
            {
                GPIOReadBuffer = _GPIOSerialPort.ReadLine();  //读取缓冲数据
            }
            catch (Exception ex)
            {
                OnMessage?.Invoke("GPIOERROR", ex.Message);
            }
            _GPIOSerialPort.DiscardInBuffer();
            if (GPIOReadBuffer == "OK")  //控制命令返回成功
            {
                _ManualResetEvent.Set();
                OnSuccess?.Invoke(null);
            }
            else if (GPIOReadBuffer.StartsWith("GPIO=0x")) //查询状态命令返回成功
            {
                _ManualResetEvent.Set();
                if (GPIOReadBuffer.Length == "GPIO=0xF3C1FFFF".Length)
                {
                    GPIOReadBuffer = GPIOReadBuffer.Substring("GPIO=0x".Length, "F3C1FFFF".Length);
                    var value = (UInt32)Int32.Parse(GPIOReadBuffer, System.Globalization.NumberStyles.AllowHexSpecifier);
                    SetStatus(value);
                    OnSuccess?.Invoke(value);
                }
            }
            else
            {
                //
            }
        }
        #endregion
        #region IN端口状态
        /// <summary>
        /// IN端口状态
        /// </summary>
        public ConcurrentDictionary<GPIOInPinEnum, In_Port_Info> _DicInPortInfo { get; set; }
        /// <summary>
        /// 解析IN端口状态
        /// </summary>
        /// <param name="value"></param>
        private void SetStatus(uint value)
        {
            if (value != 0)
            {
                foreach (var item in Enum.GetValues(typeof(GPIOInPinEnum)))
                {
                    var gpioInEnum = (GPIOInPinEnum)item;
                    var inPortInfo = _DicInPortInfo.ContainsKey(gpioInEnum) ? _DicInPortInfo[gpioInEnum] : new In_Port_Info(gpioInEnum);
                    SetStatus(inPortInfo, (value & (1 << (byte)item)) > 0 ? GPIOLevelEnum.LEVEL_HIGH : GPIOLevelEnum.LEVEL_LOW);
                }
            }
        }
        /// <summary>
        /// 设置端口状态
        /// </summary>
        /// <param name="port">端口类</param>
        /// <param name="cur_status">状态值</param>
        public void SetStatus(In_Port_Info port, GPIOLevelEnum cur_status)
        {
            if (cur_status != port._cur_status) //当前状态与上次状态不相同，引发事件
            {
                port._last_status = port._cur_status;
                port._last_time = port._cur_time;
                port._cur_status = cur_status;
                port._cur_time = DateTime.Now;
                OnStatusChanged?.Invoke(port, cur_status);
            }
            else
            {
                port._cur_status = cur_status;
                port._cur_time = DateTime.Now;
            }
        }
        #endregion

        #region 线程支持
        ManualResetEvent _ManualResetEvent = new ManualResetEvent(false);
        Queue<string> _GetCmds = new Queue<string>();
        Queue<string> _SetCmds = new Queue<string>();
        readonly object _GetLock = new object();
        readonly object _SetLock = new object();
        readonly bool _ThreadFlag = true;
        public void Start()
        {
            new Thread(new ThreadStart(SendCmds))
            {
                IsBackground = false,
                Priority = ThreadPriority.AboveNormal //提高线程优先级
            }.Start();
        }
        private void SendCmds()
        {
            while (_ThreadFlag)
            {
                Thread.Sleep(1);
                _ManualResetEvent.Reset();
                #region 检查串口
                try
                {
                    if (_GPIOSerialPort.IsOpen == false)
                    {
                        _GPIOSerialPort.Open();
                    }
                }
                catch (Exception ex)
                {
                    OnMessage?.Invoke("WARM", ex.Message);
                    Thread.Sleep(1500);
                    continue;
                }
                #endregion
                string _set_cmd = "";
                lock (_SetLock)
                {
                    try
                    {
                        if (_SetCmds.Count > 0)
                            _set_cmd = _SetCmds.Dequeue();
                    }
                    catch { _set_cmd = ""; }
                }
                if (!string.IsNullOrWhiteSpace(_set_cmd))
                {
                    OnMessage?.Invoke("DEBUG", _set_cmd);
                    _GPIOSerialPort.WriteLine(_set_cmd);
                    if (_ManualResetEvent.WaitOne(60) == false)
                    {
                        OnMessage?.Invoke("GPIO板", _set_cmd + "执行失败，无数据返回！");
                    }
                    continue;
                }
                string _get_cmd = "";
                lock (_GetCmds)
                {
                    try
                    {
                        if (_GetCmds.Count > 0)
                            _get_cmd = _GetCmds.Dequeue();
                    }
                    catch { _get_cmd = ""; }
                }
                if (!string.IsNullOrWhiteSpace(_get_cmd))
                {
                    _GPIOSerialPort.WriteLine(_get_cmd);
                    if (_ManualResetEvent.WaitOne(60) == false)
                    {
                        OnFail?.Invoke("GPIO板" + _get_cmd + "执行失败，无数据返回！");
                        OnMessage?.Invoke("GPIO板", _get_cmd + "执行失败，无数据返回！");
                    }
                }
            }
        }
        /// <summary>
        /// 获取GPIO板状态
        /// </summary>
        /// <returns></returns>
        public bool GetGPIOStatus()
        {
            lock (_GetLock)
            {
                if (_GetCmds.Count < 10)
                {
                    lock (_GetCmds)
                    {
                        _GetCmds.Enqueue("GETGPIO");
                    }
                }
            }
            return true;
        }
        public ConcurrentDictionary<GPIOOutPinEnum, Out_Port_Info> _DicOutPortInfo { get; set; }
        private string SetCmd(GPIOOutPinEnum pin, GPIOLevelEnum level)
        {
            var outPortInfo = _DicOutPortInfo.ContainsKey(pin) ? _DicOutPortInfo[pin] : new Out_Port_Info(pin);
            outPortInfo._cur_status = level;
            outPortInfo._cur_time = DateTime.Now;
            int temp = 0 | (int)Math.Pow((int)pin, 2);
            return string.Format("SETGPIO=0x{0:x2}   ", temp) + "二进制:" + Convert.ToString(temp, 2);
        }
        /// <summary>
        /// 开A门
        /// </summary>
        public void OpenA()
        {
            lock (_SetLock)
            {
                _SetCmds.Enqueue(SetCmd(GPIOOutPinEnum.IOOUT_GPIO_MOTOR_A, GPIOLevelEnum.LEVEL_HIGH));
            }
        }
        /// <summary>
        /// 关A门
        /// </summary>
        public void CloseA()
        {
            lock (_SetLock)
            {
                _SetCmds.Enqueue(SetCmd(GPIOOutPinEnum.IOOUT_GPIO_MOTOR_A, GPIOLevelEnum.LEVEL_LOW));
            }
        }
        /// <summary>
        /// 开B门
        /// </summary>
        public void OpenB()
        {
            lock (_SetLock)
            {
                _SetCmds.Enqueue(SetCmd(GPIOOutPinEnum.IOOUT_GPIO_MOTOR_B, GPIOLevelEnum.LEVEL_HIGH));
            }
        }
        /// <summary>
        /// 关B门
        /// </summary>
        public void CloseB()
        {
            lock (_SetLock)
            {
                _SetCmds.Enqueue(SetCmd(GPIOOutPinEnum.IOOUT_GPIO_MOTOR_B, GPIOLevelEnum.LEVEL_LOW));
            }
        }
        /// <summary>
        /// 开舱内灯光
        /// </summary>
        public void OpenLamp()
        {
            lock (_SetLock)
            {
                _SetCmds.Enqueue(SetCmd(GPIOOutPinEnum.IOOUT_GPIO_LAMP_A, GPIOLevelEnum.LEVEL_HIGH));
            }
        }
        /// <summary>
        /// 关舱内灯光
        /// </summary>
        public void CloseLamp()
        {
            lock (_SetLock)
            {
                _SetCmds.Enqueue(SetCmd(GPIOOutPinEnum.IOOUT_GPIO_LAMP_A, GPIOLevelEnum.LEVEL_LOW));
            }
        }
        /// <summary>
        /// 开？
        /// </summary>
        public void OpenOut4()
        {
            lock (_SetLock)
            {
                _SetCmds.Enqueue(SetCmd(GPIOOutPinEnum.IOOUT_GPIO_4, GPIOLevelEnum.LEVEL_HIGH));
            }
        }
        /// <summary>
        /// 关？
        /// </summary>
        public void CloseOut4()
        {
            lock (_SetLock)
            {
                _SetCmds.Enqueue(SetCmd(GPIOOutPinEnum.IOOUT_GPIO_4, GPIOLevelEnum.LEVEL_LOW));
            }
        }
        #endregion
        ~GPIOHelper()
        {
            _GPIOSerialPort.Close();
        }
    }
}
