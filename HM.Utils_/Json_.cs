using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Utils_
{
    /// <summary>Json数据与对象的转换 
    /// <remarks>
    /// install-package Newtonsoft.Json
    /// </remarks>
    /// </summary>
    public class Json_
    {
        /// <summary>获得Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(object obj)
        {
            //DataContractJsonSerializer json = new DataContractJsonSerializer(obj.GetType());
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    json.WriteObject(stream, obj);
            //    string szJson = Encoding.UTF8.GetString(stream.ToArray()); return szJson;
            //}
            //return fastJSON.JSON.ToJSON(obj);
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 获得Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="lstExcludePropertie">要排除的属性</param>
        /// <returns></returns>
        public static string GetString(object obj, List<string> lstExcludePropertie)
        {
            return JsonConvert.SerializeObject(
                   obj,
                   Formatting.Indented,
                   new JsonSerializerSettings
                   {
                       ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                       ContractResolver = new ExcludePropertiesContractResolver(lstExcludePropertie)
                   });
        }
        /// <summary>获取Json的Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T GetObject<T>(string strJson)
        {
            //T obj = Activator.CreateInstance<T>();
            //using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
            //{
            //    DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            //    return (T)serializer.ReadObject(ms);
            //}
            //return fastJSON.JSON.ToObject<T>(strJson);
            return JsonConvert.DeserializeObject<T>(strJson);
        }

    }
    /// <summary>
    /// 用于序列化时，排除某一属性
    /// </summary>
    public class ExcludePropertiesContractResolver : DefaultContractResolver
    {
        IEnumerable<string> lstExclude;
        public ExcludePropertiesContractResolver(IEnumerable<string> excludedProperties)
        {
            lstExclude = excludedProperties;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).ToList().FindAll(p => !lstExclude.Contains(p.PropertyName));
        }
    }
}
