using HM.FacePlatform.WeChat.DAL;
using HM.FacePlatform.WeChatModel;

namespace HM.FacePlatform.WeChat.BLL
{
    /// <summary>
    /// CRM数据业务逻辑对象
    /// </summary>
    public class CrmDataBLL : BaseBLL<c_crm_data>
    {
        new CrmDataDAL dal = new CrmDataDAL();
    }
}
