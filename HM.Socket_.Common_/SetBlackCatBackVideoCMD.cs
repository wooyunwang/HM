using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Socket_.Common_
{
    /// <summary>
    /// 操作标识【使用的是Name，不是Value】
    /// </summary>
    public enum EditFlag
    {
        //删除标识杨波那边没有做，而是要求每次都需要把播放列表传过去
        Delete = 0,
        Add = 1
    }
    public class SetBlackCatBackVideoCMD
    {
        /// <summary>
        /// 黑猫编号
        /// </summary>
        public int BlackCatId { get; set; }
        /// <summary>
        /// 视频路径
        /// 例如：path=\\10.1.250.149\\file-pdwy\scan\A.jpg  说明： 多视频用分号隔开 例如  A;B
        /// </summary>
        public string VideoPath { get; set; }
        /// <summary>
        /// 操作标识
        /// </summary>
        public string EditFlag { get; set; }
        /// <summary>
        /// 设置视频路径
        /// </summary>
        /// <param name="lstVideoPath"></param>
        public void SetVideoPath(IEnumerable<string> lstVideoPath)
        {
            VideoPath = string.Join(";", lstVideoPath);
        }
        /// <summary>
        /// 设置操作标识
        /// </summary>
        /// <param name="lstEditFlag"></param>
        public void SetEditFlag(IEnumerable<EditFlag> lstEditFlag)
        {
            EditFlag = string.Join(";", lstEditFlag);
        }
    }
}
