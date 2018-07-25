using ArxOne.MrAdvice.Advice;
using System;

namespace HM.Common_
{
    public class TryCatchAttrubute : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            try
            {
                context.Proceed();
            }
            catch (Exception exp)
            {
                LogHelper.Error(string.Format("命名空间：{0}；方法：{1}；",
                 context.Target.ToString(),
                 context.TargetMethod.ToString()
                 ), exp);
            }
        }
    }
}