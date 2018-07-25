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
    public class DemoServer
    {
        public static async Task RunServerAsync()
        {

            //设置输出日志到Console
            //ExampleHelper.SetConsoleLogger();

            // 主工作线程组，设置为1个线程
            var bossGroup = new MultithreadEventLoopGroup(1);
            // 工作线程组，默认为内核数*2的线程数
            var workerGroup = new MultithreadEventLoopGroup();
            X509Certificate2 tlsCertificate = null;
            if (ServerSettings.IsSsl) //如果使用加密通道
            {
                tlsCertificate = new X509Certificate2(Path.Combine(Environment.CurrentDirectory, "dotnetty.com.pfx"), "password");
            }
            try
            {
                //声明一个服务端Bootstrap，每个Netty服务端程序，都由ServerBootstrap控制，
                //通过链式的方式组装需要的参数

                var bootstrap = new ServerBootstrap();
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
                IChannel boundChannel = await bootstrap.BindAsync(ServerSettings.Port);

                Console.ReadLine();
                //关闭服务
                await boundChannel.CloseAsync();
            }
            finally
            {
                //释放工作组线程
                await Task.WhenAll(
                    bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                    workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
            }
        }
    }
    public class ServerSettings
    {
        public static bool IsSsl { get; set; } = false;
        public static int Port { get; set; } = 9003;
    }

    public class EchoServerHandler : ChannelHandlerAdapter //管道处理基类，较常用
    {
        /// <summary>
        /// 重写基类的方法，当消息到达时触发，这里收到消息后，在控制台输出收到的内容，并原样返回了客户端
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {

            var buffer = message as IByteBuffer;
            if (buffer != null)
            {
                Console.WriteLine("Received from client: " + buffer.ToString(Encoding.UTF8));
            }
            context.WriteAsync(message);//写入输出流
        }

        /// <summary>
        /// 输出到客户端，也可以在上面的方法中直接调用WriteAndFlushAsync方法直接输出
        /// </summary>
        /// <param name="context"></param>
        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        /// <summary>
        /// 捕获 异常，并输出到控制台后断开链接，提示：客户端意外断开链接，也会触发
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine("Exception: " + exception);
            context.CloseAsync();
        }
    }
}
