using HM.FacePlatform.DAL;
using HM.FacePlatform.Model;
using System;

namespace HM.FacePlatform.BLL
{
    public class MaoFailedJobBLL : BaseBLL<MaoFailedJob>
    {
        new MaoFailedJobDAL dal = new MaoFailedJobDAL();

        //public int? Add(MaoFailedJob job)
        //{
        //    try
        //    {
        //        return _maoFailedJobDAL.Add(job);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("MaoFailedJobBLL.Add: " + ex.Message);
        //    }
        //    return 0;
        //}

        //public int? Update(MaoFailedJob job)
        //{
        //    try
        //    {
        //        return _maoFailedJobDAL.Update(job);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("MaoFailedJobBLL.Update: " + ex.Message);
        //    }
        //    return 0;
        //}

        //public void AddOrUpdate(MaoFailedJob job)
        //{
        //    try
        //    {
        //        _maoFailedJobDAL.AddOrUpdate(job);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("MaoFailedJobBLL.AddOrUpdate: " + ex.Message);
        //    }
        //}

        //public MaoFailedJob[] GetList()
        //{
        //    try
        //    {
        //        return _maoFailedJobDAL.GetList(new { is_del = 0 });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("MaoFailedJobBLL.GetList: " + ex.Message);
        //    }

        //    return new MaoFailedJob[] { };
        //}
    }
}
