using HM.DTO;
using HM.FacePlatform.DAL;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.FacePlatform.BLL
{
    public class MaoBuildingBLL : BaseBLL<MaoBuilding>
    {
        new MaoBuildingDAL dal = new MaoBuildingDAL();

        public bool AddOrRemove(MaoBuilding mao_building)
        {
            if (mao_building.id == 0)
            {
                var entity = dal.Add(mao_building);
                return entity != null;
            }

            else
            {
                return dal.Delete(mao_building) > 0;
            }
        }

        /// <summary>
        /// 软删除某人脸一体机上的指定楼栋
        /// </summary>
        /// <param name="maoId"></param>
        /// <param name="lstBuildingCode"></param>
        /// <returns></returns>
        public ActionResult<int> SoftDelete(int maoId, List<string> lstBuildingCode)
        {
            return new ActionResult<int>()
            {
                IsSuccess = true,
                Obj = dal.SoftDelete(maoId, lstBuildingCode)
            };
        }
    }
}
