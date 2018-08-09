using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Handlers.Logging;
using DotNetty.Handlers.Tls;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using HM.Common_;
using HM.Enum_;
using HM.Socket_.Common_;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_
{
    /// <summary>
    /// 黑猫一号通讯封装类
    /// </summary>
    public class BlackCat01 : IDisposable
    {
        /// <summary>
        /// 处理事件
        /// </summary>
        public Func<RequestBase<byte[]>, ResponseBase<bool>> _RealHandler { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public Action<string> _OnMessage { get; set; }
        /// <summary>
        /// 主工作线程组，设置为1个线程
        /// </summary>
        MultithreadEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);

        /// <summary>
        /// 工作线程组，默认为内核数*2的线程数
        /// </summary>
        MultithreadEventLoopGroup workerGroup = new MultithreadEventLoopGroup();

        /// <summary>
        /// 声明一个服务端Bootstrap，每个Netty服务端程序，都由ServerBootstrap控制
        /// </summary>
        ServerBootstrap bootstrap = new ServerBootstrap();
        /// <summary>
        /// 
        /// 
        /// </summary>
        IChannel boundChannel { get; set; }

        public BlackCat01(int port = 7300)
        {
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            Task.Run(() =>
            {
                try
                {
                    X509Certificate2 tlsCertificate = null;
                    if (ServerSettings.IsSsl) //如果使用加密通道
                    {
                        tlsCertificate = new X509Certificate2(Path.Combine(Environment.CurrentDirectory, "dotnetty.com.pfx"), "password");
                    }
                    bootstrap
                    .Group(bossGroup, workerGroup) // 设置主和工作线程组
                    .Channel<TcpServerSocketChannel>() // 设置通道模式为TcpSocket
                    .Option(ChannelOption.SoBacklog, 100) // 设置网络IO参数等，这里可以设置很多参数，当然你对网络调优和参数设置非常了解的话，你可以设置，或者就用默认参数吧
                    .Handler(new LoggingHandler("VankeService")) //在主线程组上设置一个打印日志的处理器
                    .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline;
                        pipeline.AddLast("BlackCat01Decoder", new BlackCat01Decoder(1024, 4, 5, 0, 0, true));
                        var blackCat01ServerHandler = new BlackCat01ServerHandler();
                        blackCat01ServerHandler._RealHandler = _RealHandler;
                        pipeline.AddLast(blackCat01ServerHandler);
                    }));

                    // bootstrap绑定到指定端口的行为 就是服务端启动服务，同样的Serverbootstrap可以bind到多个端口
                    boundChannel = bootstrap.BindAsync(port).Result;

                    _OnMessage?.Invoke($"启动Socket服务【{ className }】【端口：{ port }】成功");
                }
                catch (Exception ex)
                {
                    _OnMessage?.Invoke($"启动Socket服务【{ className }】【端口：{ port }】失败，原因：{ Environment.NewLine } { ex.Message }");
                }
            });
        }
        public void Dispose()
        {
            Task.WhenAll(
                boundChannel.CloseAsync(),
                bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
        }
    }
    /// <summary>
    /// 黑猫一号专属编码器
    /// </summary>
    public class BlackCat01Encoder : MessageToByteEncoder<RequestBase<byte[]>>
    {
        protected override void Encode(IChannelHandlerContext context, RequestBase<byte[]> message, IByteBuffer output)
        {
            output.WriteBytes(message.ToBytes());
        }
    }
    /// <summary>
    /// 黑猫一号专属解码器
    /// </summary>
    public class BlackCat01Decoder : LengthFieldBasedFrameDecoder
    {
        /// <summary>
        /// RequestBase类中定义了Symbol、Command、PackNum，这都放在消息头部
        /// Symbol占4个字节 
        /// Command占1个字节
        /// PackNum占4个字节
        /// 所以头部总长度是9个字节
        /// </summary>
        readonly int HEADER_SIZE = 9;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxFrameLength">网络字节序，默认为大端字节序</param>
        /// <param name="lengthFieldOffset">消息中长度字段偏移的字节数</param>
        /// <param name="lengthFieldLength">数据帧的最大长度</param>
        /// <param name="lengthAdjustment">该字段加长度字段等于数据帧的长度</param>
        /// <param name="initialBytesToStrip">从数据帧中跳过的字节数</param>
        /// <param name="failFast">如果为true，则表示读取到长度域，TA的值的超过maxFrameLength，就抛出一个 TooLongFrameException</param>
        public BlackCat01Decoder(
            int maxFrameLength,
            int lengthFieldOffset,
            int lengthFieldLength,
            int lengthAdjustment,
            int initialBytesToStrip,
            bool failFast) : base(
                maxFrameLength,
                lengthFieldOffset,
                lengthFieldLength,
                lengthAdjustment,
                initialBytesToStrip,
                failFast)
        {

        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        protected override object Decode(IChannelHandlerContext context, IByteBuffer input)
        {
            if (input == null)
            {
                //没有输入
                return null;
            }
            if (input.ReadableBytes < HEADER_SIZE)
            {
                //长度不正确
                return null;
            }
            byte[] symbol = new byte[4];
            input.ReadBytes(symbol, 0, symbol.Length);

            if (Utils.PrintByte(symbol) != Utils.PrintByte(Constant.VKHM))
            {
                //非黑猫一号指定指令
                return null;
            }
            byte command = input.ReadByte();
            CmdCode cmdCode = default(CmdCode);
            if (!Enum.TryParse(command.ToString(), out cmdCode))
            {
                return null;
            }
            else
            {
                byte[] packNum = new byte[4];
                input.ReadBytes(packNum, 0, packNum.Length);
                int length = Utils.ByteToInt(packNum);
                if (input.ReadableBytes < length)
                {
                    //长度不对
                    return null;
                }
                else
                {
                    byte[] data = new byte[length - 1];
                    input.ReadBytes(data, 0, data.Length - 1);
                    var postamble = input.ReadByte();
                    if (postamble != Constant.postamble[0])
                    {
                        //结束符不对
                        return null;
                    }
                    else
                    {
                        return new RequestBase<byte[]>(symbol, cmdCode, data, packNum);
                    }
                }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class BlackCat01ServerHandler : ChannelHandlerAdapter
    {
        public Func<RequestBase<byte[]>, ResponseBase<bool>> _RealHandler { get; set; }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            //channel失效，从Map中移除
            BlackCat01CloudChannelMap.Remove((ISocketChannel)context.Channel);
            base.ChannelInactive(context);
        }
        /// <summary>
        /// 连接事件
        /// </summary>
        /// <param name="context"></param>
        public override void ChannelActive(IChannelHandlerContext context)
        {
            base.ChannelActive(context);
            var remoteAddress = (System.Net.IPEndPoint)context.Channel.RemoteAddress;

            if (BlackCat01CloudChannelMap.Get(remoteAddress.Address.ToString()) == null)
            {
                //说明未登录，或者连接断了，服务器向客户端发起登录请求，让客户端重新登录
                context.Channel.WriteAndFlushAsync("");
            }
        }
        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var requestBase = message as RequestBase<byte[]>;
            if (requestBase != null)
            {
#if DEBUG
                Console.WriteLine(Utils_.Json_.GetString(requestBase));
#endif
                LogHelper.GetIlog(LogType.Default).Info(Utils_.Json_.GetString(requestBase));

                if (_RealHandler != null)
                {
                    var result = _RealHandler(requestBase);
                    context.WriteAsync(result.ToBytes());
                }
                else
                {
                    context.WriteAsync(new ResponseBase<bool>((requestBase.CmdCode + 1), false));
                }
            }
            else
            {
                context.WriteAsync("");//写入输出流
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            base.ChannelReadComplete(context);
            //context.Flush();
        }
        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
#if DEBUG
            Console.WriteLine("Exception: " + exception.Message);
#endif
            LogHelper.GetIlog().Debug("BlackCat01ServerHandler.ExceptionCaught", exception);
            context.CloseAsync();
        }
    }
}
