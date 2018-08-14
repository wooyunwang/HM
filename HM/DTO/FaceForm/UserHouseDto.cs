
namespace HM.DTO.FacePlatform
{
    public class UserHouseDto : UserDto
    {
        public int user_type { get; set; }
        public string relation { get; set; }
        public string user_type_name { get; set; }
        public string data_from_name { get; set; }
        public string sex_name { get; set; }
        public int user_house_id { get; set; }
        public string house_code { get; set; }
        public string house_name { get; set; }

        public string family_count { get; set; }
        public string guest_count { get; set; }

        public int _total { get; set; }
    }
}
