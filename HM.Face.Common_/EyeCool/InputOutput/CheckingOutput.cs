using System.Collections.Generic;

namespace HM.Face.Common_.EyeCool
{
    /// <summary>
    /// 检测
    /// </summary>
    public class CheckingOutput : ResponseBase
    {
        /// <summary>
        /// 被检测出的人脸，当前版本支持单张人脸信息返回
        /// </summary>
        public List<Face_> face { get; set; } = new List<Face_>();
        /// <summary>
        /// 检测图片的高度
        /// <!--
        /// 接口文档类型错误
        /// -->
        /// </summary>
        public string img_height { get; set; }
        /// <summary>
        /// EyeKey系统中的图片标识符，用于标识用户请求中的图片
        /// </summary>
        public string img_id { get; set; }
        /// <summary>
        /// 检测图片的宽度
        /// <!--
        /// 接口文档类型错误
        /// -->
        /// </summary>
        public string img_width { get; set; }
    }
    /// <summary>
    /// 人脸
    /// </summary>
    public class Face_
    {
        /// <summary>
        /// 脸部属性信息
        /// </summary>
        public Attribute_ attribute { get; set; }
        /// <summary>
        /// 特征ID
        /// <![CDATA[
        /// 此face_id为CheckingInput传入的face_id
        /// ]]>
        /// </summary>
        public string face_id { get; set; }
        /// <summary>
        /// 人脸标记关键点的属性
        /// </summary>
        public Position_ position { get; set; }
    }
    /// <summary>
    /// 特征
    /// </summary>
    public class Attribute_
    {
        /// <summary>
        /// 年龄，表示估计的年龄
        /// </summary>
        public string age { get; set; }
        /// <summary>
        /// 性别，值为Male/Female
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 检出人脸左眼的睁开程度(0~100之间的整数)
        /// <!--
        /// 接口文档类型错误
        /// -->
        /// </summary>
        public string lefteye_opendegree { get; set; }
        /// <summary>
        /// 检出人脸的嘴巴张开程度(0~100之间的整数)
        /// <!--
        /// 接口文档类型错误
        /// -->
        /// </summary>
        public string mouth_opendegree { get; set; }
        /// <summary>
        /// 脸部姿态分析结果，歪头tilting，抬低头raise，摇头turn。每个值为[-90,90]近似角度值；平面内左右歪头：正左、负右；扭头：正左、负右；低抬头：正抬、负低;
        /// </summary>
        public Pose_ pose { get; set; }
        /// <summary>
        /// 检出人脸右眼的睁开程度(0~100之间的整数)
        /// <!--
        /// 接口文档类型错误
        /// -->
        /// </summary>
        public string righteye_opendegree { get; set; }
    }
    /// <summary>
    /// 人脸标记关键点的属性
    /// </summary>
    public class Position_
    {
        /// <summary>
        /// 检出的人脸框的中心点坐标, x & y 坐标分别表示在图片中的宽度和高度
        /// </summary>
        public Center_ center { get; set; }
        /// <summary>
        /// 相应人脸的左眼坐标，x & y 坐标分别表示在图片中的宽度和高度
        /// </summary>
        public EyeLeft_ eye_left { get; set; }
        /// <summary>
        /// 相应人脸的右眼坐标，x & y 坐标分别表示在图片中的宽度和高度
        /// </summary>
        public EyeRight_ eye_right { get; set; }
        /// <summary>
        /// 实数，表示检出的脸的高度
        /// <!--
        /// 接口文档类型错误
        /// -->
        /// </summary>
        public string height { get; set; }
        /// <summary>
        /// 实数，表示检出的脸的宽度
        /// <!--
        /// 接口文档类型错误
        /// -->
        /// </summary>
        public string width { get; set; }
    }
    /// <summary>
    /// 人脸框的中心点坐标
    /// </summary>
    public class Center_
    {
        /// <summary>
        ///  在图片中的宽度
        /// </summary>
        public string x { get; set; }
        /// <summary>
        ///  在图片中的高度
        /// </summary>
        public string y { get; set; }
    }
    /// <summary>
    /// 人脸的左眼坐标
    /// </summary>
    public class EyeLeft_
    {
        /// <summary>
        /// 在图片中的宽度
        /// </summary>
        public string x { get; set; }
        /// <summary>
        /// 在图片中的高度
        /// </summary>
        public string y { get; set; }
    }
    /// <summary>
    /// 人脸的右眼坐标
    /// </summary>
    public class EyeRight_
    {
        /// <summary>
        /// 在图片中的宽度
        /// </summary>
        public string x { get; set; }
        /// <summary>
        /// 在图片中的高度
        /// </summary>
        public string y { get; set; }
    }
    /// <summary>
    /// 脸部姿态分析结果，歪头tilting，抬低头raise，摇头turn。每个值为[-90,90]近似角度值；
    /// 平面内左右歪头：正左、负右；扭头：正左、负右；低抬头：正抬、负低;
    /// </summary>
    public class Pose_
    {
        /// <summary>
        /// 歪头
        /// </summary>
        public string tilting { get; set; }
        /// <summary>
        /// 抬低头
        /// </summary>
        public string raise { get; set; }
        /// <summary>
        /// 摇头
        /// </summary>
        public string turn { get; set; }
    }
}