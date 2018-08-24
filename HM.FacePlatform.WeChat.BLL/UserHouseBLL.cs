using HM.Common_;
using HM.DTO;
using HM.FacePlatform.WeChat.DAL;
using HM.FacePlatform.WeChatModel;

namespace HM.FacePlatform.WeChat.BLL
{
    public class UserHouseBLL : BaseBLL<c_user_house>
    {
        new UserHouseDAL dal = new UserHouseDAL();
    }
}
