using HM.FacePlatform.WeChat.DAL;
using HM.FacePlatform.WeChatModel;

namespace HM.FacePlatform.WeChat.BLL
{
    /// <summary>
    /// 楼栋业务逻辑对象
    /// </summary>
    public class BuildingBLL : BaseBLL<c_building>
    {
        new BuildingDAL dal = new BuildingDAL();
    }
}
