using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Face.Common_.Base
{
    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Struct |
        AttributeTargets.Enum |
        AttributeTargets.Interface |
        AttributeTargets.Delegate |
        AttributeTargets.Method |
        AttributeTargets.Constructor |
        AttributeTargets.Property |
        AttributeTargets.Field |
        AttributeTargets.Event,
        Inherited = false)
    ]
    public class WarnAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public WarnAttribute()
        {
            IsError = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public WarnAttribute(string message)
        {
            Message = message;
            IsError = false;
        }
        public WarnAttribute(string message, bool error)
        {
            Message = message;
            error = IsError;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 获取指示编译器是否将使用已过时的程序元素视为错误的布尔值   
        /// 如果将使用已过时的元素视为错误，则为 true；否则为 false。 默认值为 false。
        /// </summary>
        public bool IsError { get; set; }
    }
}
