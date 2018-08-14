using HM.FacePlatform.DAL;
using HM.FacePlatform.Model;
using System;
using HM.Face.Common_;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using HM.DTO;
using HM.Utils_;
using HM.Common_;

namespace HM.FacePlatform.BLL
{
    public class MaoBLL : BaseBLL<Mao>
    {
        MaoDAL _maoDAL;
        public MaoBLL()
        {
            _maoDAL = new MaoDAL();
        }
        /// <summary>
        /// 检查所有的人脸一体机的端口是否通畅
        /// </summary>
        /// <returns></returns>
        public ActionResult<Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>>> CheckAllMao()
        {
            Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>> dic = new Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>>();
            var lstMao = FacePlatformCache.GetALL<Mao>();
            Parallel.ForEach(lstMao, mao =>
            {
                string ip = mao.GetIP();
                int port = mao.GetPort();
                bool isOk = NetWork_.VisualTelnet(ip, port);
                Face.Common_.Face face = FaceFactory.CreateFace(ip, port, FaceVender.EyeCool);
                dic.Add(mao.id, new Tuple<bool, Mao, Face.Common_.Face>(isOk, mao, face));
            });

            ActionResult<Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>>> ar = new ActionResult<Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>>>
            {
                IsSuccess = dic.Any(it => it.Value.Item1 == false),
                Obj = dic
            };
            return ar;
        }

        public bool IsExistUsingBuilding(int id)
        {
            try
            {
                return _maoDAL.Any(it => it.id == id);
            }
            catch (Exception ex)
            {
                LogHelper.Error("MaoBLL.IsExistUsingBuilding: " + ex.Message);
            }
            return true;
        }
    }
}
