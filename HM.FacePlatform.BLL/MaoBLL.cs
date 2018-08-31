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
        new MaoDAL dal = new MaoDAL();

        /// <summary>
        /// 选择一个可用的人脸一体机
        /// </summary>
        /// <returns></returns>
        public ActionResult<Tuple<bool, Mao, Face.Common_.Face>> SelectOneMao()
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
            var goodMaos = dic.Where(it => it.Value.Item1 == true);

            ActionResult<Tuple<bool, Mao, Face.Common_.Face>> result = new ActionResult<Tuple<bool, Mao, Face.Common_.Face>>();
            if (goodMaos.Any())
            {
                result.Obj = goodMaos.Select(it => it.Value).FirstOrDefault();
            }
            else
            {
                result.IsSuccess = false;
                result.Obj = null;
                result.Add("所有人脸一体机都不可用！请检查！");
            }
            return result;
        }
        /// <summary>
        /// 检查所有的人脸一体机的端口是否通畅
        /// </summary>
        /// <returns></returns>
        public ActionResult<Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>>> CheckMao()
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

        /// <summary>
        ///  检查楼栋下的人脸一体机的端口是否通畅
        /// </summary>
        /// <param name="lstBuilding"></param>
        /// <returns></returns>
        public ActionResult<Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>>> CheckMao(IEnumerable<MaoBuilding> lstMaoBuildingWithMao)
        {
            Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>> dic = new Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>>();
            Parallel.ForEach(lstMaoBuildingWithMao, maoBuilding =>
            {
                string ip = maoBuilding.Mao.GetIP();
                int port = maoBuilding.Mao.GetPort();
                bool isOk = NetWork_.VisualTelnet(ip, port);
                Face.Common_.Face face = FaceFactory.CreateFace(ip, port, FaceVender.EyeCool);
                dic.Add(maoBuilding.id, new Tuple<bool, Mao, Face.Common_.Face>(isOk, maoBuilding.Mao, face));
            });

            ActionResult<Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>>> ar = new ActionResult<Dictionary<int, Tuple<bool, Mao, Face.Common_.Face>>>
            {
                IsSuccess = dic.Any(it => it.Value.Item1 == false),
                Obj = dic
            };
            return ar;
        }
        /// <summary>
        /// 获得小区用户所在区域的人脸一体机
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<Mao> GetForFaceSection(string user_id)
        {
            return dal.GetForFaceSection(user_id);
        }
        /// <summary>
        /// 获得楼栋所映射的人脸一体机
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<Mao> GetForFaceSectionByHouse(string house_code)
        {
            return dal.GetForFaceSectionByHouse(house_code);
        }
    }
}
