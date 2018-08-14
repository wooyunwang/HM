using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HM.FacePlatform.Model
{
    public abstract class BaseModelNotId
    {

        protected void SetDefaultToProperties<T>(T obj)
        {
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo property in props)
            {
                if (property.CanWrite)
                {
                    Type propertyType = property.PropertyType;
                    if (propertyType == typeof(string))
                    {
                        property.SetValue(obj, string.Empty, null);
                    }
                }
            }
        }
    }
}
