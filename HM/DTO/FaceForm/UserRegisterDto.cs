using HM.Enum_.FacePlatform;

namespace HM.DTO.FacePlatform
{
    public class UserRegisterDto : UserHouseDto
    {
        /// <summary>
        /// 是否注册的标识字段是user.register_state，该字段仅用来表示某用户所有已注册的图片均被删除的情况
        /// </summary>
        //public bool is_registed { get; set; }
        public string photo_path { get; set; }
        public string face_id { get; set; }
        public string check_state_name { get; set; }
        public RegisterType register_type { get; set; }
        public string register_type_name
        {
            get
            {
                return Utils_.EnumHelper.GetName(register_type);
            }
        }
        public string check_by_name { get; set; }
    }
}
