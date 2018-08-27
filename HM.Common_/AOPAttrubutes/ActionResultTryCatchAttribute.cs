using ArxOne.MrAdvice.Advice;
using HM.Common_;
using HM.DTO;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace HM.Common_
{
    /// <summary>
    /// 使用此特性，要求所有的返回参数都是或者继承
    /// HM.Common_.DTO.ActionResult
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ActionResultTryCatchAttribute : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            try
            {
                context.Proceed();

#if DEBUG
                Type type = ((MethodInfo)context.TargetMethod).ReturnParameter.ParameterType;
                if (type == typeof(ActionResult) || type.BaseType == typeof(ActionResult))
                {
                    var strArguments = Json_.GetString(context.Arguments, new List<string>() { "file", "imageBase64" });

                    if (context.ReturnValue is ActionResult)
                    {
                        var returnValue = context.ReturnValue as ActionResult;
                        if (!returnValue.IsSuccess)
                        {
                            LogHelper.Debug($@"
命名空间：{context.Target.ToString()}
方法：{ context.TargetMethod.ToString() }
参数：{ strArguments }
异常：{ returnValue.ToAlertString() }
");
                        }
                    }
                }
#endif
            }
            catch (Exception ex)
            {
                Type type = ((MethodInfo)context.TargetMethod).ReturnParameter.ParameterType;
                if (type == typeof(ActionResult) || type.BaseType == typeof(ActionResult))
                {
                    var strArguments = Json_.GetString(context.Arguments, new List<string>() { "file", "imageBase64" });

                    string strMsg = Exception_.GetInnerException(ex).Message;

                    LogHelper.Error($@"
命名空间：{context.Target.ToString()}
方法：{ context.TargetMethod.ToString() }
参数：{ strArguments }
异常：{ strMsg }
");
                    if (context.ReturnValue is ActionResult)
                    {
                        var returnValue = Activator.CreateInstance(type);
                        var actionResult = returnValue as ActionResult;
                        actionResult.Add(strMsg);
                        context.ReturnValue = actionResult;
                    }
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}