using System;
using Quartz;

namespace HM.FacePlatform.Client
{
    public class ClearScreenJob:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.Clear();
        }
    }
}
