using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HMCommon.Functions
{
    public class XMLHelper
    {
        public static string Path
        {
            get { return String.Format(@"{0}/{1}.xml", Environment.CurrentDirectory, "ScreenMode"); }
        }

        public static bool XmlSerialize<T>(T obj)
        {
            try
            {
                using (FileStream fs = new FileStream(Path, FileMode.Create))
                {
                    Type t = obj.GetType();
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(fs, obj);
                    fs.Flush();
                    fs.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                //log
                return false;
            }
        }

        public static T DESerializer<T>() where T : class
        {
            try
            {
                if (File.Exists(Path))
                {
                    T t;
                    using (FileStream sr = new FileStream(Path, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        t = serializer.Deserialize(sr) as T;
                        sr.Flush();
                        sr.Close();
                    }
                    return t;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
