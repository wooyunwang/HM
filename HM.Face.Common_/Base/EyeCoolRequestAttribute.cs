using ArxOne.MrAdvice.Advice;
using HM.Common_;
using HM.Face.Common_.EyeCool;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace HM.Face.Common_
{
    /// <summary>
    /// 使用此特性，要求所有的返回参数都是或者继承
    /// HM.Face.Common_.EyeCool.ResponseCode
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class EyeCoolRequestAttribute : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            try
            {
                context.Proceed();

                //string faceLogType = Config_.GetString("FaceLogType");
                //if (!string.IsNullOrWhiteSpace(faceLogType))
                //{
                Type type = ((MethodInfo)context.TargetMethod).ReturnParameter.ParameterType;
                if (type == typeof(ResponseBase) || type.BaseType == typeof(ResponseBase))
                {
                    var strArguments = Json_.GetString(context.Arguments, new List<string>() { "file", "imageBase64" });

                    if (context.ReturnValue is ResponseBase)
                    {
                        var returnValue = context.ReturnValue as ResponseBase;

                        LogHelper.Debug($@"
命名空间：{context.Target.ToString()}
方法：{ context.TargetMethod.ToString() }
参数：{ strArguments }
返回码：{ returnValue.res_code_enum }
返回消息：{ returnValue.res_msg }
");
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                Type type = ((MethodInfo)context.TargetMethod).ReturnParameter.ParameterType;
                if (type == typeof(ResponseBase) || type.BaseType == typeof(ResponseBase))
                {
                    var strArguments = Json_.GetString(context.Arguments, new List<string>() { "file" });

                    string strMsg = Exception_.GetInnerException(ex).Message;

                    LogHelper.Error($@"
命名空间：{ context.Target.ToString() }
方法：{ context.TargetMethod.ToString() }
参数：{ strArguments }
异常：{ strMsg }
");
                    var returnValue = Activator.CreateInstance(type);
                    var responseBase = returnValue as ResponseBase;
                    responseBase.res_code = ResponseCode._0001.ToString().TrimStart('_');
                    responseBase.res_msg = strMsg;
                    context.ReturnValue = returnValue;
                }
                else
                {
                    throw ex;
                }
            }
        }
    }

}