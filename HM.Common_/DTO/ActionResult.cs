
using System;
using System.Collections.Generic;
using System.Linq;

namespace HM.Common_.DTO
{
    public class ActionResult
    {
        public ActionResult()
        {
            IsSuccess = true;
            LstMsg = LstMsg ?? new List<string>();
        }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        //public string Message { get; set; }

        /// <summary>消息
        /// </summary>
        public bool Any()
        {
            return LstMsg.Any();
        }
        public bool Any(string key)
        {
            return LstMsg.Any(it => it.Contains(key));
        }
        /// <summary>
        /// 
        /// </summary>
        protected List<string> LstMsg { get; set; }
        /// <summary>添加信息
        /// </summary>
        /// <param name="str"></param>
        public virtual ActionResult Add(string str, bool isSuccess = false)
        {
            LstMsg.Add(str);
            return this;
        }
        /// <summary>添加异常信息
        /// </summary>
        /// <param name="ex"></param>
        public virtual ActionResult Add(Exception ex)
        {
            IsSuccess = false;
            LstMsg.Add(GetExceptionMessage(ex));
            return this;
        }
        /// <summary>
        /// </summary>
        /// <param name="actionResult"></param>
        public virtual ActionResult Add(ActionResult actionResult)
        {
            IsSuccess = IsSuccess && actionResult.IsSuccess;
            LstMsg.AddRange(actionResult.LstMsg);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actionResult"></param>
        public virtual ActionResult Add<T>(ActionResult<T> actionResult)
        {
            IsSuccess = IsSuccess && actionResult.IsSuccess;
            LstMsg.AddRange(actionResult.LstMsg);
            return this;
        }

        /// <summary>添加异常信息
        /// </summary>
        /// <param name="errorPrex">前缀</param>
        /// <param name="ex"></param>
        public virtual ActionResult Add(string errorPrex, Exception ex)
        {
            IsSuccess = false;
            LstMsg.Add(errorPrex + GetExceptionMessage(ex));
            return this;
        }

        /// <summary>获得深层次的错误提示
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string GetExceptionMessage(Exception ex)
        {
            string str = string.Empty;
            if (ex.InnerException != null)
            {
                if (ex.InnerException.InnerException != null)
                {
                    str = ex.InnerException.InnerException.Message;
                }
                else
                {
                    str = ex.InnerException.Message;
                }
            }
            else
            {
                str = ex.Message;
            }
            return str;
        }
        /// <summary>转换为以换行隔开的字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (LstMsg != null && LstMsg.Count > 0) ? string.Join(Environment.NewLine, LstMsg) : "";
        }
        /// <summary>转换<br/>以换行隔开的字符串
        /// </summary>
        /// <returns></returns>
        public string ToAlertString()
        {
            //return (lstMsg != null && lstMsg.Count > 0) ? string.Join("<br/>", lstMsg) : "";
            //return (lstMsg != null && lstMsg.Count > 0) ? string.Join("\u000d", lstMsg) : "";
            return (LstMsg != null && LstMsg.Count > 0) ? string.Join("\r\n", LstMsg) : "";
        }
    }

    public class ActionResult<T> : ActionResult
    {
        /// <summary>
        /// </summary>
        public ActionResult()
            : base()
        {
        }
        /// <summary>根据实际返回一个对象
        /// </summary>
        public T Obj { get; set; }

        /// <summary>添加信息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isSuccess"></param>
        public new ActionResult<T> Add(string str, bool isSuccess = false)
        {
            base.Add(str,isSuccess);
            return this;
        }
        /// <summary>添加异常信息
        /// </summary>
        /// <param name="ex"></param>
        public new ActionResult<T> Add(Exception ex)
        {
            base.Add(ex);
            return this;
        }
        /// <summary>
        /// </summary>
        /// <param name="actionResult"></param>
        public new ActionResult<T> Add(ActionResult actionResult)
        {
            base.Add(actionResult);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="actionResult"></param>
        public ActionResult<T> Add(ActionResult<T> actionResult)
        {
            IsSuccess = IsSuccess && actionResult.IsSuccess;
            Obj = actionResult.Obj;
            LstMsg.AddRange(actionResult.LstMsg);
            return this;
        }
    }
}
