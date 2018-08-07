namespace HM.Face.Common_.EyeCool
{
    public class CurrentDetailInput : RequestBase
    {
        public CurrentDetailInput()
        {
            pageSize = 50;
            pageNumber = 1;
        }
        /// <summary>
        /// 组名，黑猫一号以项目编号作为组名
        /// </summary>
        public string crowdname { set; get; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string updateTime { set; get; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public string endtime { set; get; }
        /// <summary>
        /// 每页展示数量，为空则默认为50
        /// </summary>
        public int pageSize { set; get; }
        /// <summary>
        /// 当前页，为空则默认为第1页
        /// </summary>
        public int pageNumber { set; get; }
    }
}
