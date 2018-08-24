using HM.Common_;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace HM.FacePlatform.Server
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [WCF_ExceptionBehaviour(typeof(WCF_ExceptionHandler))]
    public partial class WeChatService : IService
    {
        private void WriteException(string project_code, string message, Exception exception)
        {
            LogHelper.Error(string.Format("[{0}] {1}", project_code, message), exception);
        }

        private void WriteAccessLog(string project_code, string message)
        {
            LogHelper.Info(string.Format("[{0}] {1} -- {2}", project_code, message, ClientIpAndPort()));
        }

        public string ClientIpAndPort()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties properties = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return endpoint.Address + ":" + endpoint.Port;
        }

        public string TestMethod()
        {
            return "call at: " + DateTime.Now.ToString();
        }
    }
}
