using HM.FacePlatform.WeChat.DAL;
using HM.FacePlatform.WeChatModel;
using System;
using System.Collections.Generic;
using HM.Utils_;
using HM.DTO;

namespace HM.FacePlatform.WeChat.BLL
{
    public class RegisterBLL : BaseBLL<w_register>
    {
        new RegisterDAL dal = new RegisterDAL();

        public List<w_register> Get(string project_code, int pageIndex, int pageSize, DateTime from, DateTime? to)
        {
            var where = Predicate_.True<w_register>();

            where = where.And(it => it.lastupdate_time >= from);
            if (to.HasValue)
            {
                where = where.And(it => it.lastupdate_time < to);
            }

            //必须按照最后修改时间顺序排序
            return Get(pageIndex, pageSize, where, true, it => it.lastupdate_time);


        }
    }
}
