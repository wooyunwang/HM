using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace HM.FacePlatform.Server
{
    /// <summary> 
    /// WCF服务端异常处理器 
    /// </summary> 
    public class WCF_ExceptionHandler : IErrorHandler
    {
        #region IErrorHandler Members

        /// <summary> 
        /// HandleError 
        /// </summary> 
        /// <param name="ex">ex</param> 
        /// <returns>true</returns> 
        public bool HandleError(Exception ex)
        {
            return true;
        }

        /// <summary> 
        /// ProvideFault 
        /// </summary> 
        /// <param name="ex">ex</param> 
        /// <param name="version">version</param> 
        /// <param name="msg">msg</param> 
        public void ProvideFault(Exception ex, MessageVersion version, ref Message msg)
        {
            // 
            //在这里处理服务端的消息，将消息写入服务端的日志 
            // 
            var newException = new FaultException($@"
接口: { ex.TargetSite.Name }，
错误：{ Utils_.Exception_.GetInnerException(ex) }
");
            MessageFault msgFault = newException.CreateMessageFault();
            msg = Message.CreateMessage(version, msgFault, newException.Action);
        }

        #endregion
    }
}
