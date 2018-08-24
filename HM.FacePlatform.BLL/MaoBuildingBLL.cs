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
    }
}
