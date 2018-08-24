using HM.Common_;
using HM.DTO;
using HM.FacePlatform.WeChat.DAL;
using HM.FacePlatform.WeChatModel;
using System;
using System.Collections.Generic;

namespace HM.FacePlatform.WeChat.BLL
{
    public class User_C_BLL : BaseBLL<c_user>
    {
        new User_C_DAL dal = new User_C_DAL();
    }
}
