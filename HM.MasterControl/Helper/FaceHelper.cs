using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ABDoor.Face
{
    public delegate void onFaceDelegate(string m_info);

    //class FaceHelper
    //{
    //    #region 处理频繁数据
    //    public Dictionary<string, DateTime> resultList = new Dictionary<string, DateTime>();
    //    private static Object resultListLocker = new object();
    //    #endregion

    //    private AsyncTcpServer m_AsyncServer;
    //    private FaceConfigInfo m_info;
    //    /// <summary>
    //    /// 人脸识别通知开门事件
    //    /// </summary>
    //    private onFaceDelegate _onFace;

    //    public onFaceDelegate OnFace
    //    {
    //        get { return _onFace; }
    //        set { _onFace = value; }
    //    }
    //    private OnMessageDelegate _onMessage; //消息委托

    //    public OnMessageDelegate OnMessage
    //    {
    //        get { return _onMessage; }
    //        set { _onMessage = value; }
    //    }
    //    #region 单例
    //    private static readonly FaceHelper faceHelper = new FaceHelper();
    //    public static FaceHelper GetInstance()
    //    {
    //        return faceHelper;
    //    }
    //    #endregion


    //    public void Start()
    //    {
    //        try
    //        {
    //            m_AsyncServer = new AsyncTcpServer(m_info.Port);
    //            m_AsyncServer.Encoding = Encoding.UTF8;
    //            m_AsyncServer.ClientConnected += new EventHandler<TcpClientConnectedEventArgs>(server_ClientConnected);
    //            m_AsyncServer.ClientDisconnected += new EventHandler<TcpClientDisconnectedEventArgs>(server_ClientDisconnected);
    //            m_AsyncServer.PlaintextReceived += new EventHandler<TcpDatagramReceivedEventArgs<string>>(server_PlaintextReceived);
    //            m_AsyncServer.Start();

    //            if (OnMessage != null)
    //            {
    //                OnMessage("FACE", string.Format("接收人脸服务启动完成，端口：{0} ", m_AsyncServer.Port));
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            MessageBox.Show(m_info.Port.ToString() + "人脸结果接收端口被占用，请修改端口", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
 
    //            if (OnMessage != null)
    //            {
    //                OnMessage("FACE", string.Format("人脸结果接收出错，端口：{0} ERROR{1}", m_AsyncServer.Port,e.Message));
    //            }
    //        }


    //        //Console.WriteLine("TCP server has been started.");
    //        //Console.WriteLine("Type something to send to client...");
            
    //    }


    //    public FaceHelper()
    //    {
    //        m_info = new FaceConfigInfo();
    //        string _config_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FaceConfigInfo.config");
    //        if (File.Exists(_config_path))
    //        {
                
    //            try
    //            {
    //                m_info = (FaceConfigInfo)SerializationHelper.Load(m_info.GetType(), _config_path);
    //            }
    //            catch (Exception ex)
    //            {
    //                if (OnMessage != null)
    //                    OnMessage("SYSTEM", _config_path + "配置文件损坏" + ex.Message);
    //                m_info.Port = 18200;
    //                m_info.DelayMillisecond = 4000;
    //                SerializationHelper.Save(m_info, _config_path);
    //            }
    //        }
    //        else
    //        {
    //            m_info.Port = 18200;
    //            m_info.DelayMillisecond = 4000;
    //            SerializationHelper.Save(m_info, _config_path);
    //        }
           
    //    }

    //    void server_ClientConnected(object sender, TcpClientConnectedEventArgs e)
    //    {
    //        if (OnMessage != null)
    //        {
    //            OnMessage("FACE", string.Format("TCP client {0} has connected.", e.TcpClient.Client.RemoteEndPoint.ToString()));
    //        }
    //    }

    //    void server_ClientDisconnected(object sender, TcpClientDisconnectedEventArgs e)
    //    {
    //        if (OnMessage != null)
    //        {
    //            OnMessage("FACE", string.Format("TCP client {0} has disconnected.", e.TcpClient.Client.RemoteEndPoint.ToString()));
    //        }
    //    }

    //    #region 频繁数据处理
    //    void server_PlaintextReceived(object sender, TcpDatagramReceivedEventArgs<string> e)
    //    {
    //        try
    //        {
    //            if (!String.IsNullOrEmpty(e.Datagram))
    //            {
                    
    //                if (OnMessage != null)
    //                {
    //                    OnMessage("FACE",string.Format( "人脸服务 : {0} -->收到识别结果：{1} " ,e.TcpClient.Client.RemoteEndPoint.ToString(), e.Datagram));
    //                }

    //                lock (resultListLocker)
    //                {
    //                    //拆分字符串
    //                    String[] strlist = e.Datagram.Split('|');
    //                    if ((strlist != null) && (strlist.Length > 1))
    //                    {
    //                        string strUserID = strlist[1].Trim();
    //                        bool canSend = false;

    //                        if (resultList.ContainsKey(strUserID))
    //                        {
    //                            //在的情况，判断时间差
    //                            if (TimeDiff(DateTime.Now, resultList[strUserID]) > m_info.DelayMillisecond)
    //                            {
    //                                canSend = true;
    //                                resultList[strUserID] = DateTime.Now;
    //                            }
    //                            else
    //                            {
    //                                if (OnMessage != null)
    //                                {
    //                                    OnMessage("FACE", string.Format( "{0}验证结果太频繁,丢弃",strUserID) );
    //                                }
    //                            }
    //                        }
    //                        else
    //                        {
    //                            //不在的情况，直接添加并发送
    //                            canSend = true;
    //                        }
                            
    //                        if (canSend)
    //                        {
    //                            //添加
    //                            if (!resultList.ContainsKey(strUserID))
    //                            {
    //                                resultList.Add(strUserID, DateTime.Now);
    //                            }

    //                            if (resultList.Count > 20)//大于20条数据时把最早的那条数据删除
    //                            {
    //                                Dictionary<string, DateTime> dicAsc = resultList.OrderBy(o => o.Value).ToDictionary(o => o.Key, p => p.Value);
    //                                string[] dicAscKey = dicAsc.Keys.ToArray();
    //                                resultList.Remove(dicAscKey[0]);
    //                            }

    //                            //处理
    //                            if (OnFace != null)
    //                            {
    //                                OnFace(e.Datagram);
    //                                this.m_AsyncServer.SendToAll(e.Datagram);  //答复报文  2017.5.23
    //                            }

    //                            //if (OnMessage != null)
    //                            //{
    //                            //    OnMessage("FACE", string.Format("人脸服务 : {0} -->转发识别结果:{1}",e.TcpClient.Client.RemoteEndPoint.ToString(), e.Datagram));
    //                            //}
    //                        }

    //                    }

    //                } //lock
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            OnMessage("FACE", string.Format("人脸服务 : {0} -->识别结果转发出错:{1}", e.TcpClient.Client.RemoteEndPoint.ToString(), e.Datagram + ex.Message));
    //        }

            

    //        //if (OnFace != null)
    //        //    OnFace(e.Datagram);
    //        //if (OnMessage != null)
    //        //{
    //        //    OnMessage("FACE", string.Format(string.Format("Client : {0} --> ", e.TcpClient.Client.RemoteEndPoint.ToString())));
    //        //    OnMessage("FACE", string.Format("{0}", e.Datagram));
    //        //}

    //        ////m_AsyncServer.Send(e.TcpClient, "Server has received you text : " + e.Datagram);

    //    }
    //    #endregion

    //    public static long TimeDiff(DateTime NewTime, DateTime oldTime)
    //    {
    //        long ret = 0;
    //        //计算用时
    //        TimeSpan ts = NewTime - oldTime;
    //        ret = (long)Math.Truncate(ts.TotalMilliseconds);

    //        return ret;
    //    }


    //}



}
