using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Face.Common_
{
    /// <summary>
    /// 人脸技术供应商
    /// </summary>
    public enum FaceVender
    {
        /// <summary>
        /// 眼神科技
        /// </summary>
        EyeCool = 0,
        /// <summary>
        /// 万睿：睿瞳
        /// </summary>
        VanRui = 1
    }
    /// <summary>
    /// 简单工厂类，用sealed修饰，
    /// </summary>
    public class FaceFactory
    {
        /// <summary>
        /// 使用静态方法，根据传入的参数来指定要实例化哪一种产品
        /// </summary>
        /// <param name="faceType"></param>
        /// <returns></returns>
        public static Face CreateFace(string ip, int port, FaceVender faceVender)
        {
            Face face = null;
            switch (faceVender)
            {
                case FaceVender.EyeCool:
                    face = new EyeCoolFace(ip, port);
                    break;
                case FaceVender.VanRui:
                    face = new VanRuiFace(ip, port);
                    break;
                default:
                    break;
            }

            return face;
        }
    }
}
