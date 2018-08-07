using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Handlers.Logging;
using DotNetty.Handlers.Tls;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using HM.Socket_.Common_;

namespace HM.Socket_
{
    public class BlackCat01CloudServer : IDisposable
    {
        /// <summary>
        /// 
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
        /// </summary>
        IChannel boundChannel { get; set; }

        public BlackCat01CloudServer(int port = 6666)
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
                    .Option(ChannelOption.SoBacklog, 2048) //保持连接数
                    .Option(ChannelOption.TcpNodelay, true)//有数据立即发送
                    .Handler(new LoggingHandler("VankeService")) //在主线程组上设置一个打印日志的处理器
                    .ChildOption(ChannelOption.SoKeepalive, true)//保持连接
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

    public class BlackCat01CloudChannelMap
    {
        private static ConcurrentDictionary<String, ISocketChannel> map = new ConcurrentDictionary<String, ISocketChannel>();
        public static void Add(String clientId, ISocketChannel socketChannel)
        {
            map.TryAdd(clientId, socketChannel);
        }
        public static ISocketChannel Get(String clientId)
        {
            ISocketChannel channel = null;
            map.TryGetValue(clientId, out channel);
            return channel;
        }
        public static void Remove(ISocketChannel socketChannel)
        {
            String clientId = string.Empty;
            foreach (var item in map)
            {
                if (item.Value == socketChannel)
                {
                    clientId = item.Key;
                    break;
                }
            }
            if (!string.IsNullOrWhiteSpace(clientId))
            {
                map.TryRemove(clientId, out socketChannel);
            }
        }
    }
}
