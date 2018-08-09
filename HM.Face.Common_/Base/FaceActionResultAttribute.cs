using ArxOne.MrAdvice.Advice;
using HM.Common_;
using HM.Common_.DTO;
using HM.Utils_;
using System;

namespace HM.Face.Common_
{
    public class FaceActionResultAttribute : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            try
            {
                context.Proceed();
                if (context.ReturnValue is ActionResult)
                {
                    var rv = context.ReturnValue as ActionResult;
                    if (!rv.IsSuccess)
                    {
                        LogHelper.Error($@"
命名空间：{context.Target.ToString()}
方法：{context.TargetMethod.ToString()}
参数：{Json_.GetString(context.Arguments)}
错误：{rv.ToAlertString()}
");
                    }
                }
            }
            catch (Exception exp)
            {
                LogHelper.Error($@"
命名空间：{context.Target.ToString()}
方法：{context.TargetMethod.ToString()}
参数：{Json_.GetString(context.Arguments)}
", exp);
            }
        }
    }
}