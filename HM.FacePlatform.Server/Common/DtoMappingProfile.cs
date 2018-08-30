using AutoMapper;
using HM.DTO.FacePlatform;
using HM.FacePlatform.WeChatModel;

namespace HM.FacePlatform.Server
{
    /// <summary>
    /// 云平台数据库与DTO的映射配置
    /// </summary>
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            //CreateMap<BuildingDto, c_building>();
            //.ForMember(dest => dest.building_code, opt => opt.MapFrom(src => src.building_code))
            //.ForMember(dest => dest.building_name, opt => opt.MapFrom(src => src.building_name))
            //.ForMember(dest => dest.project_code, opt => opt.MapFrom(src => src.project_code))
            //.ForMember(dest => dest.data_from, opt => opt.MapFrom(src => src.data_from));
            //CreateMap<c_building, BuildingDto>();

            CreateMap<HouseDto, c_house>();
            //.ForMember(dest => dest.house_code, opt => opt.MapFrom(src => src.house_code))
            //.ForMember(dest => dest.house_name, opt => opt.MapFrom(src => src.house_name))
            //.ForMember(dest => dest.unit, opt => opt.MapFrom(src => src.unit))
            //.ForMember(dest => dest.floor, opt => opt.MapFrom(src => src.floor))
            //.ForMember(dest => dest.roomnumber, opt => opt.MapFrom(src => src.roomnumber))
            //.ForMember(dest => dest.building_code, opt => opt.MapFrom(src => src.building_code))
            //.ForMember(dest => dest.data_from, opt => opt.MapFrom(src => src.data_from));
            CreateMap<c_house, HouseDto>();

            CreateMap<UserDto, w_user>();
            //.ForMember(dest => dest.user_uid, opt => opt.MapFrom(src => src.user_uid))
            //.ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
            //.ForMember(dest => dest.birthday, opt => opt.MapFrom(src => src.birthday))
            //.ForMember(dest => dest.sex, opt => opt.MapFrom(src => src.sex))
            //.ForMember(dest => dest.id_type, opt => opt.MapFrom(src => src.id_type))
            //.ForMember(dest => dest.id_num, opt => opt.MapFrom(src => src.id_num))
            //.ForMember(dest => dest.mobile, opt => opt.MapFrom(src => src.mobile))
            //.ForMember(dest => dest.tel, opt => opt.MapFrom(src => src.tel))
            //.ForMember(dest => dest.lastupdate_time, opt => opt.MapFrom(src => src.lastupdate_time))
            //.ForMember(dest => dest.user_houses, opt => opt.MapFrom(src => src.user_houses));
            CreateMap<w_user, UserDto>();
            //.ForMember(dest => dest.user_uid, opt => opt.MapFrom(src => src.user_uid))
            //.ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
            //.ForMember(dest => dest.birthday, opt => opt.MapFrom(src => src.birthday))
            //.ForMember(dest => dest.sex, opt => opt.MapFrom(src => src.sex))
            //.ForMember(dest => dest.id_type, opt => opt.MapFrom(src => src.id_type))
            //.ForMember(dest => dest.id_num, opt => opt.MapFrom(src => src.id_num))
            //.ForMember(dest => dest.mobile, opt => opt.MapFrom(src => src.mobile))
            //.ForMember(dest => dest.tel, opt => opt.MapFrom(src => src.tel))
            //.ForMember(dest => dest.lastupdate_time, opt => opt.MapFrom(src => src.lastupdate_time))
            //.ForMember(dest => dest.user_houses, opt => opt.MapFrom(src => src.user_houses));

            CreateMap<UserDto, c_user>();
            //.ForMember(dest => dest.user_uid, opt => opt.MapFrom(src => src.user_uid))
            //.ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
            //.ForMember(dest => dest.birthday, opt => opt.MapFrom(src => src.birthday))
            //.ForMember(dest => dest.sex, opt => opt.MapFrom(src => src.sex))
            //.ForMember(dest => dest.id_type, opt => opt.MapFrom(src => src.id_type))
            //.ForMember(dest => dest.id_num, opt => opt.MapFrom(src => src.id_num))
            //.ForMember(dest => dest.mobile, opt => opt.MapFrom(src => src.mobile))
            //.ForMember(dest => dest.tel, opt => opt.MapFrom(src => src.tel))
            //.ForMember(dest => dest.lastupdate_time, opt => opt.MapFrom(src => src.lastupdate_time))
            //.ForMember(dest => dest.user_houses, opt => opt.MapFrom(src => src.user_houses));
            CreateMap<c_user, UserDto>();
            //.ForMember(dest => dest.user_uid, opt => opt.MapFrom(src => src.user_uid))
            //.ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
            //.ForMember(dest => dest.birthday, opt => opt.MapFrom(src => src.birthday))
            //.ForMember(dest => dest.sex, opt => opt.MapFrom(src => src.sex))
            //.ForMember(dest => dest.id_type, opt => opt.MapFrom(src => src.id_type))
            //.ForMember(dest => dest.id_num, opt => opt.MapFrom(src => src.id_num))
            //.ForMember(dest => dest.mobile, opt => opt.MapFrom(src => src.mobile))
            //.ForMember(dest => dest.tel, opt => opt.MapFrom(src => src.tel))
            //.ForMember(dest => dest.lastupdate_time, opt => opt.MapFrom(src => src.lastupdate_time))
            //.ForMember(dest => dest.user_houses, opt => opt.MapFrom(src => src.user_houses));

            CreateMap<UserHouseDto, c_user_house>();
            //.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            //.ForMember(dest => dest.house_code, opt => opt.MapFrom(src => src.house_code))
            //.ForMember(dest => dest.user_uid, opt => opt.MapFrom(src => src.user_uid))
            //.ForMember(dest => dest.relation, opt => opt.MapFrom(src => src.relation))
            //.ForMember(dest => dest.is_del, opt => opt.MapFrom(src => src.is_del))
            //.ForMember(dest => dest.lastupdate_time, opt => opt.MapFrom(src => src.lastupdate_time))
            //.ForMember(dest => dest.project_code, opt => opt.MapFrom(src => src.project_code));
            CreateMap<c_user_house, UserHouseDto>();
            //.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            //.ForMember(dest => dest.house_code, opt => opt.MapFrom(src => src.house_code))
            //.ForMember(dest => dest.user_uid, opt => opt.MapFrom(src => src.user_uid))
            //.ForMember(dest => dest.relation, opt => opt.MapFrom(src => src.relation))
            //.ForMember(dest => dest.is_del, opt => opt.MapFrom(src => src.is_del))
            //.ForMember(dest => dest.lastupdate_time, opt => opt.MapFrom(src => src.lastupdate_time))
            //.ForMember(dest => dest.project_code, opt => opt.MapFrom(src => src.project_code));

            CreateMap<EntryHistoryDto, w_entry_history>();
            //.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            //.ForMember(dest => dest.snapshot_id, opt => opt.MapFrom(src => src.snapshot_id))
            //.ForMember(dest => dest.photo_path, opt => opt.MapFrom(src => src.photo_path))
            //.ForMember(dest => dest.score, opt => opt.MapFrom(src => src.score))
            //.ForMember(dest => dest.face_uid, opt => opt.MapFrom(src => src.face_uid))
            //.ForMember(dest => dest.mao_no, opt => opt.MapFrom(src => src.mao_no))
            //.ForMember(dest => dest.create_date, opt => opt.MapFrom(src => src.create_date))
            //.ForMember(dest => dest.project_code, opt => opt.MapFrom(src => src.project_code));
            CreateMap<w_entry_history, EntryHistoryDto>();
            //.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            //.ForMember(dest => dest.snapshot_id, opt => opt.MapFrom(src => src.snapshot_id))
            //.ForMember(dest => dest.photo_path, opt => opt.MapFrom(src => src.photo_path))
            //.ForMember(dest => dest.score, opt => opt.MapFrom(src => src.score))
            //.ForMember(dest => dest.face_uid, opt => opt.MapFrom(src => src.face_uid))
            //.ForMember(dest => dest.mao_no, opt => opt.MapFrom(src => src.mao_no))
            //.ForMember(dest => dest.create_date, opt => opt.MapFrom(src => src.create_date))
            //.ForMember(dest => dest.project_code, opt => opt.MapFrom(src => src.project_code));

            CreateMap<RegisterDto, w_register>();
            //.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            //.ForMember(dest => dest.guid_value, opt => opt.MapFrom(src => src.guid_value))
            //.ForMember(dest => dest.guid_type, opt => opt.MapFrom(src => src.guid_type))
            //.ForMember(dest => dest.face_uid, opt => opt.MapFrom(src => src.face_uid))
            //.ForMember(dest => dest.photo_path, opt => opt.MapFrom(src => src.photo_path))
            //.ForMember(dest => dest.register_type, opt => opt.MapFrom(src => src.register_type))
            //.ForMember(dest => dest.reg_time, opt => opt.MapFrom(src => src.reg_time))
            //.ForMember(dest => dest.end_time, opt => opt.MapFrom(src => src.end_time))
            //.ForMember(dest => dest.register_state, opt => opt.MapFrom(src => src.register_state))
            //.ForMember(dest => dest.check_time, opt => opt.MapFrom(src => src.check_time))
            //.ForMember(dest => dest.check_note, opt => opt.MapFrom(src => src.check_note))
            //.ForMember(dest => dest.create_time, opt => opt.MapFrom(src => src.create_time))
            //.ForMember(dest => dest.people_id, opt => opt.MapFrom(src => src.people_id))
            //.ForMember(dest => dest.project_code, opt => opt.MapFrom(src => src.project_code))
            //.ForMember(dest => dest.lastupdate_time, opt => opt.MapFrom(src => src.lastupdate_time));
            CreateMap<w_register, RegisterDto>();
            //.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            //.ForMember(dest => dest.guid_value, opt => opt.MapFrom(src => src.guid_value))
            //.ForMember(dest => dest.guid_type, opt => opt.MapFrom(src => src.guid_type))
            //.ForMember(dest => dest.face_uid, opt => opt.MapFrom(src => src.face_uid))
            //.ForMember(dest => dest.photo_path, opt => opt.MapFrom(src => src.photo_path))
            //.ForMember(dest => dest.register_type, opt => opt.MapFrom(src => src.register_type))
            //.ForMember(dest => dest.reg_time, opt => opt.MapFrom(src => src.reg_time))
            //.ForMember(dest => dest.end_time, opt => opt.MapFrom(src => src.end_time))
            //.ForMember(dest => dest.register_state, opt => opt.MapFrom(src => src.register_state))
            //.ForMember(dest => dest.check_time, opt => opt.MapFrom(src => src.check_time))
            //.ForMember(dest => dest.check_note, opt => opt.MapFrom(src => src.check_note))
            //.ForMember(dest => dest.create_time, opt => opt.MapFrom(src => src.create_time))
            //.ForMember(dest => dest.people_id, opt => opt.MapFrom(src => src.people_id))
            //.ForMember(dest => dest.project_code, opt => opt.MapFrom(src => src.project_code))
            //.ForMember(dest => dest.lastupdate_time, opt => opt.MapFrom(src => src.lastupdate_time));

            CreateMap<RegisterOutputDto, w_register>();
            CreateMap<w_register, RegisterOutputDto>();

            CreateMap<RegisterInputDto, w_register>();
            CreateMap<w_register, RegisterInputDto>();
        }
    }
}
