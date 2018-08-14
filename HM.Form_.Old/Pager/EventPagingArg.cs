using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HM.Form_.Old.Pager
{
    public class EventPagingArg
    {
        public delegate int GetNMaxEventHander();

        public delegate DataTable DataSourceEventHandler(int pageIndex, int pageSize);
    }
}
