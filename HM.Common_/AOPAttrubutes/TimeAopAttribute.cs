using ArxOne.MrAdvice.Advice;
using System;
using System.Diagnostics;

namespace HM.Common_
{
    public class TimeAopAttribute : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
#if DEBUG
            Stopwatch Watch = new Stopwatch();
            Watch.Start();
#endif

            // do things you want here
            context.Proceed(); // this calls the original method
#if DEBUG
            Watch.Stop();
            // do other things here
            string str = string.Format("命名空间：{0}；方法：{1}；执行时间：{2}",
                context.Target.ToString(),
                context.TargetMethod.ToString(),
                Watch.ElapsedMilliseconds
                );
            LogHelper.Info(str);
#endif
        }
    }
}