using System;
using HM.FacePlatform.DAL;

using HM.FacePlatform.Model;

namespace HM.FacePlatform.BLL
{
    public class ProjectBLL : BaseBLL<Project>
    {
        new ProjectDAL dal = new ProjectDAL();
    }
}
