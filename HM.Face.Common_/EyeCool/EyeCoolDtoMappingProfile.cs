using AutoMapper;
using HM.Enum_.FacePlatform;
using System;

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
                 .ConvertUsing(EyeCoolAndClientConverter.RegisterType_RCType);

            CreateMap<RCType, RegisterType>()
            .ConvertUsing(EyeCoolAndClientConverter.RCType_RegisterType);

            CreateMap<EyeCoolFaceState, HMFaceState>()
            .ConvertUsing(EyeCoolAndClientConverter.EyeCoolFaceState_HMFaceState);

            CreateMap<EyeCoolFaceObj, HMFaceObj>()
            .ForMember(dest => dest.RegisterType, opt => opt.MapFrom(src => src.face_type))
            .ForMember(dest => dest.FaceState, opt => opt.MapFrom(src => src.is_del))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.imageUrl))
            .ForMember(dest => dest.FaceId, opt => opt.MapFrom(src => src.face_id))
            .ForMember(dest => dest.ImageRegisterTime, opt => opt.MapFrom(src => src.imgRegTime));

            CreateMap<RegisterInput, PeopleCreateInput>()
                .ForMember(dest => dest.app_id, opt => opt.Ignore()) //忽略
                .ForMember(dest => dest.app_key, opt => opt.Ignore()) //忽略
                .ForMember(dest => dest.activeTime, opt => opt.MapFrom(src => src.ActiveTime))
                .ForMember(dest => dest.birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.cardNo, opt => opt.MapFrom(src => src.UserUid))
                .ForMember(dest => dest.cid, opt => opt.MapFrom(src => src.CertificateType))
                .ForMember(dest => dest.cNO, opt => opt.MapFrom(src => src.MaoNO))
                .ForMember(dest => dest.crowd_name, opt => opt.MapFrom(src => src.ProjectCode))
                .ForMember(dest => dest.fNo, opt => opt.MapFrom(src => src.PeopleId))
                .ForMember(dest => dest.people_id, opt => opt.MapFrom(src => src.ActiveTime))
                .ForMember(dest => dest.people_name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.rctype, opt => opt.ResolveUsing<RegisterType_RCType, RegisterType>(src => src.RegisterType))
                .ForMember(dest => dest.sex, opt => opt.ResolveUsing<SexType_Sex, SexType>(src => src.Sex))
                .ForMember(dest => dest.tip, opt => opt.ResolveUsing<UserType_Tip, UserType>(src => src.UserType));

            CreateMap<GetRegisterDataOutput, GetRegisterPageOutput>()
            .ForMember(dest => dest.MaxNumber, opt => opt.MapFrom(src => src.maxnumber))
            .ForMember(dest => dest.CertificateType, opt => opt.MapFrom(src => src.cid))
            .ForMember(dest => dest.UserUid, opt => opt.MapFrom(src => src.cardNo))
            .ForMember(dest => dest.RegisterType, opt => opt.MapFrom(src => src.rctype))
            .ForMember(dest => dest.CatCode, opt => opt.MapFrom(src => src.cNo))
            .ForMember(dest => dest.RoomNo, opt => opt.MapFrom(src => src.fNo))
            .ForMember(dest => dest.RegisterTime, opt => opt.MapFrom(src => src.regTime))
            .ForMember(dest => dest.ActiveTime, opt => opt.MapFrom(src => src.activeTime))
            .ForMember(dest => dest.CheckState, opt => opt.ResolveUsing<ReviewState_CheckType, ReviewState?>(src => src.state))
            .ForMember(dest => dest.CheckTime, opt => opt.MapFrom(src => src.checkTime))
            .ForMember(dest => dest.CheckMessage, opt => opt.MapFrom(src => src.checkMessage))
            .ForMember(dest => dest.HMFaceObj, opt => opt.MapFrom(src => src.face_obj))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.PeopleName, opt => opt.MapFrom(src => src.people_name))
            .ForMember(dest => dest.PeopleId, opt => opt.MapFrom(src => src.people_id))
            .ForMember(dest => dest.Sex, opt => opt.ResolveUsing<Sex_SexType, int>(src => src.sex))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.phone))
            .ForMember(dest => dest.UserType, opt => opt.ResolveUsing<Tag_UserType, string>(src => src.tag));

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
    /// 用户类型转换器
    /// </summary>
    public class Sex_SexType : IMemberValueResolver<object, object, int, SexType>
    {
        public SexType Resolve(object source, object destination, int sourceMember, SexType destinationMember, ResolutionContext context)
        {
            return EyeCoolAndClientConverter.Sex_SexType(sourceMember);
        }
    }

    /// <summary>
    /// 用户类型转换器
    /// </summary>
    public class SexType_Sex : IMemberValueResolver<object, object, SexType, int>
    {
        public int Resolve(object source, object destination, SexType sourceMember, int destinationMember, ResolutionContext context)
        {
            return EyeCoolAndClientConverter.SexType_Sex(sourceMember);
        }
    }

    public class RegisterType_RCType : IMemberValueResolver<object, object, RegisterType, RCType>
    {
        public RCType Resolve(object source, object destination, RegisterType sourceMember, RCType destinationMember, ResolutionContext context)
        {
            return EyeCoolAndClientConverter.RegisterType_RCType(sourceMember);
        }
    }

    /// <summary>
    /// 用户类型转换器
    /// </summary>
    public class Tag_UserType : IMemberValueResolver<object, object, string, UserType>
    {
        public UserType Resolve(object source, object destination, string sourceMember, UserType destinationMember, ResolutionContext context)
        {
            return EyeCoolAndClientConverter.Tag_UserType(sourceMember);
        }
    }

    /// <summary>
    /// 用户类型转换器
    /// </summary>
    public class UserType_Tip : IMemberValueResolver<object, object, UserType, string>
    {
        public string Resolve(object source, object destination, UserType sourceMember, string destinationMember, ResolutionContext context)
        {
            return EyeCoolAndClientConverter.UserType_Tip(sourceMember);
        }
    }

    /// <summary>
    /// 审核状态转换器
    /// </summary>
    public class ReviewState_CheckType : IMemberValueResolver<object, object, ReviewState?, CheckType?>
    {
        public CheckType? Resolve(object source, object destination, ReviewState? sourceMember, CheckType? destinationMember, ResolutionContext context)
        {
            return EyeCoolAndClientConverter.ReviewState_CheckType(sourceMember);
        }
    }


    /// <summary>
    /// 人脸枚举转换器
    /// </summary>
    public class EyeCoolAndClientConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static SexType Sex_SexType(int sex)
        {
            switch (sex)
            {
                case 0: return SexType.女;
                case 1: return SexType.男;
                default:
                    return SexType.未知;
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sexType"></param>
        /// <returns></returns>
        [System.Obsolete("未知的都会被默认成男性")]
        public static int SexType_Sex(SexType sexType)
        {
            //性别，1：男，0：女 默认1
            switch (sexType)
            {
                case SexType.未知:
                    return 1;
                case SexType.男:
                    return 1;
                case SexType.女:
                    return 0;
                default:
                    return 1;
            }
        }
        /// <summary>
        /// 客户端注册类型转EyeCool的注册类型
        /// </summary>
        /// <param name="faceSource"></param>
        /// <returns></returns>
        [Obsolete("两端状态不一致，可能会导致一定的问题")]
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
                case RegisterType.人脸一体机手动注册:
                    return RCType.手动注册;
                default:
                    return RCType.手动注册;
            }
        }
        /// <summary>
        /// 此转换仅限制于从人脸一体机拉取数据
        /// </summary>
        /// <param name="rcType"></param>
        /// <returns></returns>
        [Obsolete("两端状态不一致，可能会导致一定的问题")]
        public static RegisterType RCType_RegisterType(RCType rcType)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_type"></param>
        /// <returns></returns>
        [Obsolete("两端状态不一致，可能会导致一定的问题")]
        public static string UserType_Tip(UserType user_type)
        {
            switch (user_type)
            {
                case UserType.未知:
                    return "临时人员";
                case UserType.业主_拥有:
                    return "拥有";
                case UserType.业主_居住:
                    return "居住";
                case UserType.家庭成员:
                    return "居住";
                case UserType.访客:
                    return "临时人员";
                case UserType.工作人员:
                    return "物业管理";
                default:
                    break;
            }
            return "临时人员";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [Obsolete("两端状态不一致，可能会导致一定的问题")]
        public static UserType Tag_UserType(string tag)
        {
            switch (tag)
            {
                case "拥有":
                    return UserType.业主_拥有;
                case "居住":
                    return UserType.业主_居住;
                case "物业管理":
                    return UserType.工作人员;
                case "临时人员":
                    return UserType.访客;
                default:
                    break;
            }
            return UserType.未知;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reviewState"></param>
        /// <returns></returns>
        public static CheckType ReviewState_CheckType(ReviewState? reviewState)
        {
            if (reviewState.HasValue)
            {
                switch (reviewState)
                {
                    case ReviewState.待审核:
                        return CheckType.待审核;
                    case ReviewState.通过:
                        return CheckType.审核通过;
                    case ReviewState.不通过:
                        return CheckType.审核不通过;
                    default:
                        break;
                }
            }
            return CheckType.审核不通过;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkType"></param>
        /// <returns></returns>
        public static ReviewState CheckType_ReviewState(CheckType checkType)
        {
            switch (checkType)
            {
                case CheckType.审核不通过:
                    return ReviewState.不通过;
                case CheckType.审核通过:
                    return ReviewState.通过;
                case CheckType.待审核:
                    return ReviewState.待审核;
                default:
                    break;
            }
            return ReviewState.不通过;
        }
    }
}
