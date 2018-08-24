using System;
using Quartz;

namespace HM.FacePlatform.Server
{
    public class ClearScreenJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.Clear();
        }
    }
}
