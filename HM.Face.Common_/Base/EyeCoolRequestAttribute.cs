using ArxOne.MrAdvice.Advice;
using HM.Common_;
using HM.Utils_;
using System;

namespace HM.Face.Common_
{
    public class EyeCoolRequestAttribute : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            try
            {
                context.Proceed();
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