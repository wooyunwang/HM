using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HM.Utils_
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 根据给定的字符串返回枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// 根据给定的整形返回枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value)
        {
            var name = Enum.GetName(typeof(T), value);
            return name.ToEnum<T>();
        }

        /// <summary>
        /// 返回枚举值的描述信息。
        /// </summary>
        /// <param name="value">要获取描述信息的枚举值。</param>
        /// <returns>枚举值的描述信息。</returns>
        public static string GetEnumDesc<T>(int value)
        {
            Type enumType = typeof(T);
            DescriptionAttribute attr = null;

            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                }
            }

            // 返回结果
            if (attr != null && !string.IsNullOrEmpty(attr.Description))
                return attr.Description;
            else
                return string.Empty;
        }

        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="e">要获取描述信息的枚举项。</param>
        /// <returns>枚举项的描述信息。</returns>
        public static string GetEnumDesc(Enum e)
        {
            if (e == null)
            {
                return string.Empty;
            }
            Type enumType = e.GetType();
            DescriptionAttribute attr = null;

            // 获取枚举字段。
            FieldInfo fieldInfo = enumType.GetField(e.ToString());
            if (fieldInfo != null)
            {
                // 获取描述的属性。
                attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
            }

            // 返回结果
            if (attr != null && !string.IsNullOrEmpty(attr.Description))
                return attr.Description;
            else
                return string.Empty;
        }

        /// <summary>
        /// 获取枚举描述列表，并转化为键值对
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isHasAll">是否包含“全部”</param>
        /// <param name="filterItem">过滤项</param>
        /// <returns></returns>
        public static List<EnumKeyValue<S>> EnumDescToList<T, S>(bool isHasAll, params string[] filterItem)
        {
            List<EnumKeyValue<S>> list = new List<EnumKeyValue<S>>();

            // 如果包含全部则添加
            if (isHasAll)
            {
                list.Add(new EnumKeyValue<S>() { Value = default(S), Name = "全部" });
            }

            #region 方式一
            foreach (var item in typeof(T).GetFields())
            {
                // 获取描述
                var attr = item.GetCustomAttribute(typeof(DescriptionAttribute), true) as DescriptionAttribute;
                if (attr != null && !string.IsNullOrEmpty(attr.Description))
                {
                    // 跳过过滤项
                    if (Array.IndexOf<string>(filterItem, attr.Description) != -1)
                    {
                        continue;
                    }
                    // 添加
                    EnumKeyValue<S> model = new EnumKeyValue<S>();
                    model.Value = (S)Enum.Parse(typeof(T), item.Name);
                    model.Name = attr.Description;
                    list.Add(model);
                }
            }
            #endregion

            #region 方式二
            //foreach (int item in Enum.GetValues(typeof(T)))
            //{
            //    // 获取描述
            //    FieldInfo fi = typeof(T).GetField(Enum.GetName(typeof(T), item));
            //    var attr = fi.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
            //    if (attr != null && !string.IsNullOrEmpty(attr.Description))
            //    {
            //        // 跳过过滤项
            //        if (Array.IndexOf<string>(filterItem, attr.Description) != -1)
            //        {
            //            continue;
            //        }
            //        // 添加
            //        EnumKeyValue model = new EnumKeyValue();
            //        model.Key = item;
            //        model.Name = attr.Description;
            //        list.Add(model);
            //    }
            //} 
            #endregion

            return list;
        }

        /// <summary>
        /// 获取枚举值列表，并转化为键值对
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isHasAll">是否包含“全部”</param>
        /// <param name="filterItem">过滤项</param>
        /// <returns></returns>
        public static List<EnumKeyValue<Nullable<S>>> EnumToList<T, S>(bool isHasAll, params string[] filterItem) where S : struct
        {
            List<EnumKeyValue<Nullable<S>>> list = new List<EnumKeyValue<Nullable<S>>>();

            // 如果包含全部则添加
            if (isHasAll)
            {
                list.Add(new EnumKeyValue<Nullable<S>>() { Value = null, Name = "全部" });
            }

            foreach (S item in Enum.GetValues(typeof(T)))
            {
                string name = Enum.GetName(typeof(T), item);
                // 跳过过滤项
                if (Array.IndexOf<string>(filterItem, name) != -1)
                {
                    continue;
                }
                // 添加
                var model = new EnumKeyValue<Nullable<S>>();
                model.Value = item;
                model.Name = name;
                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// 获取枚举值列表，并转化为键值对
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isHasAll">是否包含“全部”</param>
        /// <returns></returns>
        public static List<EnumKeyValue<Nullable<T>>> EnumToBind<T>(bool isHasAll) where T : struct
        {
            List<EnumKeyValue<Nullable<T>>> list = new List<EnumKeyValue<Nullable<T>>>();

            // 如果包含全部则添加
            if (isHasAll)
            {
                list.Add(new EnumKeyValue<Nullable<T>>() { Value = null, Name = "全部" });
            }

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                string name = Enum.GetName(typeof(T), item);
                // 添加
                var model = new EnumKeyValue<Nullable<T>>();
                model.Value = item;
                model.Name = name;
                list.Add(model);
            }

            return list;
        }

        public static string GetName<T>(T item) where T : struct
        {
            return Enum.GetName(typeof(T), item);
        }

        public static string GetValue<T>(T item) where T : struct
        {
            return (Convert.ToInt32(item)).ToString();
        }
    }

    /// <summary>
    /// 枚举键值对
    /// </summary>
    public class EnumKeyValue<T>
    {
        public T Value { get; set; }
        public string Name { get; set; }
    }
}
