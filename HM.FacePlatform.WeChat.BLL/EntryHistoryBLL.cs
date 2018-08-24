using HM.FacePlatform.WeChat.DAL;
using HM.FacePlatform.WeChatModel;

namespace HM.FacePlatform.WeChat.BLL
{
    /// <summary>
    /// 进出历史业务逻辑对象
    /// </summary>
    public class EntryHistoryBLL : BaseBLL<w_entry_history>
    {
        new EntryHistoryDAL dal = new EntryHistoryDAL();
    }
}
