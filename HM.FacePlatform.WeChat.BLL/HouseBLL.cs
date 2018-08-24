using HM.FacePlatform.WeChat.DAL;
using HM.FacePlatform.WeChatModel;

namespace HM.FacePlatform.WeChat.BLL
{
    public class HouseBLL : BaseBLL<c_house>
    {
        new HouseDAL dal = new HouseDAL();
    }
}
