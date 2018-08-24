using AutoMapper;
using HM.DTO.FacePlatform;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.Model;
using System;

namespace HM.FacePlatform.Client
{
    /// <summary>
    /// 项目数据库与DTO的映射配置
    /// </summary>
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Building, BuildingDto>();
            //.ForMember(dest => dest.data_from, opt => opt.ResolveUsing<BuildingDataFromResolver>());
            CreateMap<BuildingDto, Building>();

            CreateMap<House, HouseDto>();
            //.ForMember(dest => dest.data_from, opt => opt.MapFrom(src => src.data_from));
            CreateMap<HouseDto, House>();
            //.ForMember(dest => dest.data_from, opt => opt.MapFrom(src => src.data_from));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.sex, opt => opt.ResolveUsing<SexTypeToNullableBool, SexType>(src => src.sex))
                .ForMember(dest => dest.id_type, opt => opt.ResolveUsing<IdTypeToNullableShort, IdType>(src => src.id_type))
                .ForMember(dest => dest.lastupdate_time, opt => opt.MapFrom(src => src.change_time));
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.sex, opt => opt.ResolveUsing<NullableBoolToSexType, bool?>(src => src.sex))
                .ForMember(dest => dest.id_type, opt => opt.ResolveUsing<NullableShortToIdType, short?>(src => src.id_type))
                .ForMember(dest => dest.change_time, opt => opt.ResolveUsing<FillNullableDateTime, DateTime?>(src => src.lastupdate_time));

            CreateMap<UserHouseDto, UserHouse>();
            CreateMap<UserHouse, UserHouseDto>();

            CreateMap<RegisterType, short>()
                         .ConvertUsing(ClientAndServerConverter.RegisterTypeToShort);
            CreateMap<short?, RegisterType>()
                        .ConvertUsing(ClientAndServerConverter.NullableShortToRegisterType);

            CreateMap<CheckType, short?>()
                    .ConvertUsing(ClientAndServerConverter.CheckTypeToNullableShort);

            CreateMap<short?, CheckType>()
                    .ConvertUsing(ClientAndServerConverter.NullableShortToCheckType);
        }
    }

    #region 本地与云平台的类型转换器
    /// <summary>
    /// 性别转换器
    /// </summary>
    public class NullableBoolToSexType : IMemberValueResolver<object, object, bool?, SexType>
    {
        public SexType Resolve(object source, object destination, bool? sourceMember, SexType destinationMember, ResolutionContext context)
        {
            return ClientAndServerConverter.NullableBoolToSexType(sourceMember);
        }
    }
    /// <summary>
    /// 性别转换器
    /// </summary>
    public class SexTypeToNullableBool : IMemberValueResolver<object, object, SexType, bool?>
    {
        public bool? Resolve(object source, object destination, SexType sourceMember, bool? destinationMember, ResolutionContext context)
        {
            return ClientAndServerConverter.SexTypeToNullableBool(sourceMember);
        }
    }

    /// <summary>
    /// 证件类型转换器
    /// </summary>
    public class NullableShortToIdType : IMemberValueResolver<object, object, short?, IdType>
    {
        public IdType Resolve(object source, object destination, short? sourceMember, IdType destinationMember, ResolutionContext context)
        {
            return ClientAndServerConverter.NullableShortToIdType(sourceMember);
        }
    }
    /// <summary>
    /// 证件类型转换器
    /// </summary>
    public class IdTypeToNullableShort : IMemberValueResolver<object, object, IdType, short?>
    {
        public short? Resolve(object source, object destination, IdType sourceMember, short? destinationMember, ResolutionContext context)
        {
            return ClientAndServerConverter.IdTypeToNullableShort(sourceMember);
        }
    }

    /// <summary>
    /// 可空日期转化器
    /// </summary>
    public class FillNullableDateTime : IMemberValueResolver<object, object, DateTime?, DateTime>
    {
        public DateTime Resolve(object source, object destination, DateTime? sourceMember, DateTime destinationMember, ResolutionContext context)
        {
            return sourceMember.HasValue ? sourceMember.Value : DateTime.Now;
        }
    }
    /// <summary>
    /// 项目到云平台类型转换
    /// </summary>
    public class ClientAndServerConverter
    {
        /// <summary>
        /// 转化为项目的性别
        /// </summary>
        /// <param name="sourceMember"></param>
        /// <returns></returns>
        public static SexType NullableBoolToSexType(bool? sourceMember)
        {
            if (sourceMember.HasValue)
            {
                if (sourceMember.Value) return SexType.男;
                else return SexType.女;
            }
            else { return SexType.未知; }
        }
        /// <summary>
        /// 转化为云平台的性别
        /// </summary>
        /// <param name="sourceMember"></param>
        /// <returns></returns>
        public static bool? SexTypeToNullableBool(SexType sourceMember)
        {
            switch (sourceMember)
            {
                case SexType.未知:
                    return null;
                case SexType.男:
                    return true;
                case SexType.女:
                    return false;
                default:
                    return null;
            }
        }
        /// <summary>
        /// 转化为项目的证件类型
        /// </summary>
        /// <param name="sourceMember"></param>
        /// <returns></returns>
        public static IdType NullableShortToIdType(short? sourceMember)
        {
            if (sourceMember.HasValue)
            {
                switch (sourceMember)
                {
                    case 1:
                        return IdType.身份证;
                    default:
                        return IdType.未知;
                }
            }
            else { return IdType.未知; }
        }
        /// <summary>
        /// 转化为云平台的证件类型
        /// </summary>
        /// <param name="sourceMember"></param>
        /// <returns></returns>
        public static short? IdTypeToNullableShort(IdType sourceMember)
        {
            switch (sourceMember)
            {
                case IdType.未知:
                    return null;
                case IdType.身份证:
                    return 1;
                default:
                    break;
            }
            return null;
        }

        /// <summary>
        /// 转化为云平台的注册类型
        /// </summary>
        /// <param name="registerType"></param>
        /// <returns></returns>
        public static short RegisterTypeToShort(RegisterType registerType)
        {
            //0自动注册的、1微信注册的、2手动注册的

            switch (registerType)
            {
                case RegisterType.未知:
                    return 0;
                case RegisterType.微信注册:
                    return 1;
                case RegisterType.手动注册:
                    return 2;
                case RegisterType.刷卡注册:
                    return 0; //
                case RegisterType.人脸一体机自动注册:
                    return 0; //
                case RegisterType.人脸一体机手动注册:
                    return 2; //
                default:
                    return 0; //
            }
        }
        /// <summary>
        /// 转化为项目的注册类型
        /// </summary>
        /// <param name="registerType"></param>
        /// <returns></returns>
        public static RegisterType NullableShortToRegisterType(short? registerType)
        {
            //0自动注册的、1微信注册的、2手动注册的

            switch (registerType)
            {
                case 0:
                    return RegisterType.未知;//
                case 1:
                    return RegisterType.微信注册;
                case 2:
                    return RegisterType.手动注册;
                default:
                    return RegisterType.未知; //
            }
        }

        /// <summary>
        /// 转化为云平台的审核类型
        /// </summary>
        /// <param name="checkType"></param>
        /// <returns></returns>
        public static short? CheckTypeToNullableShort(CheckType checkType)
        {
            //-1注册失败,3待注册,0待审核,1审核通过,2审核不通过
            switch (checkType)
            {
                case CheckType.审核不通过:
                    return 2;
                case CheckType.审核通过:
                    return 1;
                case CheckType.待审核:
                    return 0;
                default:
                    return 2;
            }
        }

        /// <summary>
        /// 转化为项目的审核类型
        /// </summary>
        /// <param name="checkType"></param>
        /// <returns></returns>
        public static CheckType NullableShortToCheckType(short? checkType)
        {

            //-1注册失败,3待注册,0待审核,1审核通过,2审核不通过
            switch (checkType)
            {
                case -1:
                    return CheckType.审核不通过;//
                case 0:
                    return CheckType.待审核;
                case 1:
                    return CheckType.审核通过;
                case 2:
                    return CheckType.审核不通过;
                default:
                    return CheckType.审核不通过;//
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="relation"></param>
        /// <returns></returns>
        public static UserType RelationToUserType(string relation)
        {
            switch (relation.Trim())
            {
                case "拥有":
                    return UserType.业主_拥有;
                case "其他":
                    return UserType.未知;
                case "居住":
                    return UserType.业主_居住;
                case "租赁":
                    return UserType.业主_居住;
                case "账单":
                    return UserType.未知;
                case "分润":
                    return UserType.未知;
                case "物业管理": return UserType.工作人员;
                case "临时人员": return UserType.访客;
                default: return UserType.未知;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_type"></param>
        /// <returns></returns>
        public static string RelationToUserType(UserType user_type)
        {
            switch (user_type)
            {
                case UserType.未知:
                    return "其他";
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
                    return "其他";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDelType"></param>
        /// <returns></returns>
        public static bool IsDelTypeToBool(IsDelType isDelType)
        {
            switch (isDelType)
            {
                case IsDelType.否:
                    return false;
                case IsDelType.是:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDelType"></param>
        /// <returns></returns>
        public static IsDelType BoolToIsDelType(bool? isDelType)
        {
            if (isDelType.HasValue)
            {
                if (isDelType.Value) return IsDelType.是;
                else return IsDelType.否;
            }
            else
            {
                return IsDelType.否;
            }
        }

        /// <summary>
        /// 用户数据来源：转化成项目的数据来源
        /// </summary>
        /// <param name="dataFrom"></param>
        /// <param name="originDataFromType"></param>
        /// <returns></returns>
        public static DataFromType NullableIntToUserDataFromType(int? dataFrom, DataFromType? originDataFromType)
        {
            //数据来源，0：CRM，1：微信，2：人脸管理平台,3：云平台
            if (dataFrom.HasValue)
            {
                switch (dataFrom.Value)
                {
                    case 0:
                        return DataFromType.CRM;
                    case 1:
                        return DataFromType.微信添加;
                    case 2://人脸管理平台
                        return originDataFromType ?? DataFromType.未知;
                    case 3://云平台
                        return DataFromType.云平台添加;
                    default:
                        return originDataFromType ?? DataFromType.未知;
                }
            }
            else
            {
                return originDataFromType ?? DataFromType.未知;
            }
        }

        /// <summary>
        /// 用户数据来源：转化成云平台的数据来源
        /// </summary>
        /// <param name="dataFromType"></param>
        /// <param name="originDataFrom"></param>
        /// <returns></returns>
        public static int? UserDataFromTypeToNullableInt(DataFromType dataFromType, int? originDataFrom)
        {
            //数据来源，0：CRM，1：微信，2：人脸管理平台,3：云平台
            switch (dataFromType)
            {
                case DataFromType.未知:
                    return originDataFrom;
                case DataFromType.CRM:
                    return 0;
                case DataFromType.导入:
                    return originDataFrom ?? 2;
                case DataFromType.手动添加:
                    return originDataFrom ?? 2;
                case DataFromType.人脸一体机自动添加:
                    return originDataFrom ?? 2;
                case DataFromType.微信添加:
                    return originDataFrom ?? 1;
                case DataFromType.人脸一体机手动添加:
                    return originDataFrom ?? 2;
                case DataFromType.云平台添加:
                    return 3;
                default:
                    return originDataFrom;
            }
        }
    }
    #endregion
}
