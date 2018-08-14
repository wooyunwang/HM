using HM.Common_;
using HM.DTO;
using HM.FacePlatform.DAL;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HM.FacePlatform.BLL
{
    public class UserHouseBLL : BaseBLL<UserHouse>
    {
        new UserHouseDAL dal = new UserHouseDAL();
    }
}
