using AutoMapper;

namespace HM.Face.Common_.EyeCool
{
    /// <summary>
    /// 眼神DTO与万科DTO的映射配置
    /// </summary>
    public class EyeCoolDtoMappingProfile : Profile
    {
        public EyeCoolDtoMappingProfile()
        {
            CreateMap<RegisterType, RCType>()
                 .ConvertUsing(FaceEnumConverter.RegisterType_RCType);

            CreateMap<RCType, RegisterType>()
            .ConvertUsing(FaceEnumConverter.RCType_RegisterType_Pull);

            CreateMap<EyeCoolFaceState, HMFaceState>()
            .ConvertUsing(FaceEnumConverter.EyeCoolFaceState_HMFaceState);

            CreateMap<EyeCoolFaceObj, HMFaceObj>()
            .ForMember(dest => dest.RegisterType, opt => opt.MapFrom(src => src.face_type))
            .ForMember(dest => dest.FaceState, opt => opt.MapFrom(src => src.is_del))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.imageUrl))
            .ForMember(dest => dest.FaceId, opt => opt.MapFrom(src => src.face_id))
            .ForMember(dest => dest.ImageRegisterTime, opt => opt.MapFrom(src => src.imgRegTime));

            CreateMap<GetRegisterDataOutput, GetRegisterPageOutput>()
            .ForMember(dest => dest.MaxNumber, opt => opt.MapFrom(src => src.maxnumber))
            .ForMember(dest => dest.CertificateType, opt => opt.MapFrom(src => src.cid))
            .ForMember(dest => dest.CardNo, opt => opt.MapFrom(src => src.cardNo))
            .ForMember(dest => dest.RegisterType, opt => opt.MapFrom(src => src.rctype))
            .ForMember(dest => dest.CatCode, opt => opt.MapFrom(src => src.cNo))
            .ForMember(dest => dest.RoomNo, opt => opt.MapFrom(src => src.fNo))
            .ForMember(dest => dest.RegisterTime, opt => opt.MapFrom(src => src.regTime))
            .ForMember(dest => dest.ActiveTime, opt => opt.MapFrom(src => src.activeTime))
            .ForMember(dest => dest.CheckState, opt => opt.MapFrom(src => src.state))
            .ForMember(dest => dest.CheckTime, opt => opt.MapFrom(src => src.checkTime))
            .ForMember(dest => dest.CheckMessage, opt => opt.MapFrom(src => src.checkMessage))
            .ForMember(dest => dest.HMFaceObj, opt => opt.MapFrom(src => src.face_obj))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.PeopleName, opt => opt.MapFrom(src => src.people_name))
            .ForMember(dest => dest.PeopleId, opt => opt.MapFrom(src => src.people_id))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.sex))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.phone))
            .ForMember(dest => dest.tag, opt => opt.MapFrom(src => src.tag));

            CreateMap<CurrentDetailFaceObj, FacePassDataFaceObj>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.cat_image))
            .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.createtime))
            .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.score))
            .ForMember(dest => dest.FaceRowId, opt => opt.MapFrom(src => src.face_id));

            CreateMap<CurrentDetailOutput, GetFacePassDataOutput>()
            .ForMember(dest => dest.CatCode, opt => opt.MapFrom(src => src.cNo))
            .ForMember(dest => dest.Passtime, opt => opt.MapFrom(src => src.passtime))
            .ForMember(dest => dest.FaceId, opt => opt.MapFrom(src => src.face_id))
            .ForMember(dest => dest.CardNo, opt => opt.MapFrom(src => src.cardNo))
            .ForMember(dest => dest.CertificateType, opt => opt.MapFrom(src => src.cid))
            .ForMember(dest => dest.FaceObj, opt => opt.MapFrom(src => src.face_obj));
        }
    }

    /// <summary>
    /// 人脸枚举转换器
    /// </summary>
    public class FaceEnumConverter
    {
        /// <summary>
        /// 客户端注册类型转EyeCool的注册类型
        /// </summary>
        /// <param name="faceSource"></param>
        /// <returns></returns>
        public static RCType RegisterType_RCType(RegisterType registerType)
        {
            switch (registerType)
            {
                case RegisterType.未知:
                    return RCType.手动注册;
                case RegisterType.微信注册:
                    return RCType.微信注册;
                case RegisterType.手动注册:
                    return RCType.手动注册;
                case RegisterType.刷卡注册:
                    return RCType.手动注册;
                case RegisterType.人脸一体机自动注册:
                    return RCType.自动注册;
                default:
                    break;
            }
            return RCType.手动注册;
        }
        /// <summary>
        /// 此转换仅限制于从人脸一体机拉取数据
        /// </summary>
        /// <param name="rcType"></param>
        /// <returns></returns>
        public static RegisterType RCType_RegisterType_Pull(RCType rcType)
        {
            switch (rcType)
            {
                case RCType.自动注册:
                    return RegisterType.人脸一体机自动注册;
                case RCType.微信注册:
                    return RegisterType.微信注册;
                case RCType.手动注册:
                    return RegisterType.人脸一体机手动注册;
                default:
                    break;
            }
            return RegisterType.人脸一体机手动注册;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="faceState"></param>
        /// <returns></returns>
        public static HMFaceState EyeCoolFaceState_HMFaceState(EyeCoolFaceState faceState)
        {
            switch (faceState)
            {
                case EyeCoolFaceState.正常使用:
                    return HMFaceState.正常使用;
                case EyeCoolFaceState.删除的数据:
                    return HMFaceState.删除的数据;
                case EyeCoolFaceState.待审核或禁用数据:
                    return HMFaceState.待审核或禁用数据;
                default:
                    break;
            }
            return default(HMFaceState);
        }
    }
}
