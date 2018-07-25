using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Text;

namespace HM.MasterControl
{
    /// <summary>
    /// 序列化帮助类
    /// </summary>
    public static class SerializationHelper
    {
        #region 将对像序列化和反序列化到字符串
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static object StringXmlDeserialize(string s, Type t)
        {
            if ("".Equals(s)) return null;
            XmlSerializer mySerializer = new XmlSerializer(t);
            StreamReader mem2 = new StreamReader(new MemoryStream(Encoding.Default.GetBytes(s)), Encoding.Default);
            return mySerializer.Deserialize(mem2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string StringXmlSerializer(object o)
        {
            if (o == null) return "";
            XmlSerializer ser = new XmlSerializer(o.GetType());
            MemoryStream mem = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mem, Encoding.Default);
            ser.Serialize(writer, o);
            writer.Close();
            return Encoding.Default.GetString(mem.ToArray());
        }
        #endregion

        #region 将对像序列化到文件
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
        public static object Load(Type type, string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filename">文件路径</param>
        public static void Save(object obj, string filename)
        {
            FileStream fs = null;
            try
            {
                DirectoryInfo di = new DirectoryInfo(filename);
                if (!Directory.Exists(di.Parent.FullName))
                    Directory.CreateDirectory(di.Parent.FullName);
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

        }
        #endregion
    }
}
