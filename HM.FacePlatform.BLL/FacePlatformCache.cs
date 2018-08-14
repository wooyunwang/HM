using HM.FacePlatform.BLL;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.FacePlatform.BLL
{
    public partial class FacePlatformCache
    {
        /// <summary>
        /// 过期时间
        /// </summary>
        static TimeSpan _TimeOut = new TimeSpan(0, 30, 0);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IList<T> GetALL<T>() where T : class, new()
        {
            return Cache_.GetCacheItem<IList<T>>(typeof(T).Name,
             delegate ()
             {
                 BaseBLL<T> bll = new BaseBLL<T>();
                 return bll.Get();
             },
             _TimeOut);
        }
    }
}
