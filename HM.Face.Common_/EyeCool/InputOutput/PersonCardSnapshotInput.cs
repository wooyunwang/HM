namespace HM.Face.Common_.EyeCool
{
    public class PersonCardSnapshotInput : RequestBase
    {
        public PersonCardSnapshotInput(string filePath)
        {
            file = Utils_.Image_.ImageToBase64(filePath);
        }
        /// <summary>
        /// 通过base64编码方式，原始图片大小不能大于3M；
        /// </summary>
        public string file { get; }
    }
}