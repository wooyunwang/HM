using HM.FacePlatform.WeChat.DAL;
using HM.FacePlatform.WeChatModel;

namespace HM.FacePlatform.WeChat.BLL
{
    public class ProjectBLL : BaseBLL<c_project>
    {
        new ProjectDAL dal = new ProjectDAL();
    }
}
