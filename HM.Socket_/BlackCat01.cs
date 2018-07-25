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

        public BlackCat01()
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
            { //工作线程连接器 是设置了一个管道，服务端主线程所有接收到的信息都会通过这个管道一层层往下传输
              //同时所有出栈的消息 也要这个管道的所有处理器进行一步步处理
                IChannelPipeline pipeline = channel.Pipeline;
                if (tlsCertificate != null) //Tls的加解密
                {
                    pipeline.AddLast("tls", TlsHandler.Server(tlsCertificate));
                }
                //日志拦截器
                pipeline.AddLast(new LoggingHandler("SRV-CONN"));
                //出栈消息，通过这个handler 在消息顶部加上消息的长度
                pipeline.AddLast("framing-enc", new LengthFieldPrepender(2));
                //入栈消息通过该Handler,解析消息的包长信息，并将正确的消息体发送给下一个处理Handler，该类比较常用，后面单独说明
                pipeline.AddLast("framing-dec", new LengthFieldBasedFrameDecoder(ushort.MaxValue, 0, 2, 0, 2));
                //业务handler ，这里是实际处理Echo业务的Handler
                pipeline.AddLast("echo", new EchoServerHandler());
            }));

            // bootstrap绑定到指定端口的行为 就是服务端启动服务，同样的Serverbootstrap可以bind到多个端口
            boundChannel = bootstrap.BindAsync(ServerSettings.Port).Result;
        }
    }
}
