using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Handlers.Logging;
using DotNetty.Handlers.Tls;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_
{
    public class BlackCat01
    {
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
        ServerBootstrap bootstrap { get; set; } = new ServerBootstrap();
        /// <summary>
        /// 
        /// </summary>
        IChannel boundChannel { get; set; }

        public BlackCat01(int port = 9009)
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
            .Handler(new LoggingHandler("SRV-LSTN")) //在主线程组上设置一个打印日志的处理器
            .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
            {
                IChannelPipeline pipeline = channel.Pipeline;
                pipeline.AddLast(new BlackCat01ServerHandler());
            }));

            // bootstrap绑定到指定端口的行为 就是服务端启动服务，同样的Serverbootstrap可以bind到多个端口
            boundChannel = bootstrap.BindAsync(port).Result;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~BlackCat01()
        {
            Task.WhenAll(
                boundChannel.CloseAsync(),
                bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class BlackCat01ServerHandler : ChannelHandlerAdapter
    {
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var buffer = message as IByteBuffer;
            if (buffer != null)
            {
                Console.WriteLine("Received from client: " + buffer.ToString(Encoding.UTF8));
                Common_.LogHelper.GetIlog(Common_.LogType.Recive).Info(buffer.ToString(Encoding.UTF8));
                //解析

            }
            context.WriteAsync(message);//写入输出流
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine("Exception: " + exception);
            Common_.LogHelper.GetIlog(Common_.LogType.SocketServer).Debug("BlackCat01ServerHandler.ExceptionCaught", exception);
            context.CloseAsync();
        }
    }
}
